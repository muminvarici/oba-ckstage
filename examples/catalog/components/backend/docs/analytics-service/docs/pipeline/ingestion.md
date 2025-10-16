# Data Ingestion

## Veri Kaynakları

### Uygulama Event'leri

- Web/Mobile app events
- API çağrıları
- User interactions

### Database CDC

- PostgreSQL WAL
- MySQL binlog
- MongoDB oplog

### External APIs

- Payment gateways
- Shipping providers
- Third-party integrations

### Log Files

- Application logs
- Access logs
- Error logs

## Ingestion Yöntemleri

### 1. Event Streaming (Kafka)

```python
from kafka import KafkaProducer
import json

producer = KafkaProducer(
    bootstrap_servers=['kafka:9092'],
    value_serializer=lambda v: json.dumps(v).encode('utf-8')
)

# Send event
producer.send('user-events', {
    'event_type': 'page_view',
    'user_id': 'user-123',
    'page': '/products',
    'timestamp': '2025-10-16T10:30:00Z'
})
```

**Topics:**

- `user-events`: User interaction events
- `order-events`: Order lifecycle events
- `payment-events`: Payment transactions
- `system-events`: System metrics

### 2. Batch Upload (S3)

```python
import boto3

s3 = boto3.client('s3')

# Upload daily data
s3.upload_file(
    'daily_orders_2025-10-16.parquet',
    'data-lake',
    'raw/orders/date=2025-10-16/data.parquet'
)
```

**Directory Structure:**

```
s3://data-lake/
├── raw/
│   ├── orders/date=YYYY-MM-DD/
│   ├── users/date=YYYY-MM-DD/
│   └── events/date=YYYY-MM-DD/hour=HH/
├── processed/
└── models/
```

### 3. Database CDC

```sql
-- PostgreSQL logical replication
CREATE PUBLICATION analytics_pub FOR TABLE orders, users;

-- Debezium connector
{
  "name": "orders-connector",
  "config": {
    "connector.class": "io.debezium.connector.postgresql.PostgresConnector",
    "database.hostname": "postgres",
    "database.port": "5432",
    "database.user": "replicator",
    "database.dbname": "production",
    "table.include.list": "public.orders,public.users",
    "topic.prefix": "cdc"
  }
}
```

### 4. API Webhooks

```javascript
// Express webhook endpoint
app.post('/webhooks/payment', async (req, res) => {
  const event = req.body;

  // Validate signature
  const isValid = validateSignature(event, req.headers['x-signature']);

  if (isValid) {
    await kafka.send('payment-events', event);
    res.status(200).send('OK');
  } else {
    res.status(401).send('Invalid signature');
  }
});
```

## Schema Registry

Avro schema yönetimi:

```json
{
  "type": "record",
  "name": "Order",
  "namespace": "com.example.analytics",
  "fields": [
    { "name": "id", "type": "string" },
    { "name": "user_id", "type": "string" },
    { "name": "amount", "type": "double" },
    { "name": "status", "type": "string" },
    { "name": "created_at", "type": "long", "logicalType": "timestamp-millis" }
  ]
}
```

## Data Quality Checks

```python
from great_expectations import DataContext

# Validation rules
expectations = {
    'orders': [
        ('expect_column_values_to_be_unique', {'column': 'id'}),
        ('expect_column_values_to_be_between', {
            'column': 'amount',
            'min_value': 0
        }),
        ('expect_column_values_to_not_be_null', {'column': 'user_id'})
    ]
}

# Run validation
context = DataContext()
batch = context.get_batch('orders')
results = batch.validate(expectations)
```

## Ingestion Metrikleri

| Metric                   | Value        | Alert Threshold |
| ------------------------ | ------------ | --------------- |
| Kafka lag                | <1000 msgs   | >10000          |
| Ingestion rate           | 50k events/s | <10k            |
| Error rate               | 0.1%         | >1%             |
| Schema validation errors | <100/day     | >1000           |
| Data freshness           | <5 min       | >15 min         |

## Monitoring

```python
from prometheus_client import Counter, Histogram

events_ingested = Counter(
    'events_ingested_total',
    'Total events ingested',
    ['source', 'event_type']
)

ingestion_latency = Histogram(
    'ingestion_latency_seconds',
    'Time from event creation to ingestion'
)

# Usage
events_ingested.labels(source='kafka', event_type='page_view').inc()
ingestion_latency.observe(latency)
```

## Error Handling

### Dead Letter Queue

```python
try:
    process_event(event)
except ValidationError as e:
    # Send to DLQ
    dlq_producer.send('events-dlq', {
        'original_event': event,
        'error': str(e),
        'timestamp': datetime.now()
    })
```

### Retry Policy

```python
@retry(
    stop=stop_after_attempt(3),
    wait=wait_exponential(multiplier=1, min=1, max=10),
    retry=retry_if_exception_type(TransientError)
)
def ingest_event(event):
    # Ingestion logic
    pass
```

## Backfill Process

Geçmiş veri yükleme:

```bash
# Run backfill job
spark-submit \
  --master yarn \
  --deploy-mode cluster \
  --conf spark.sql.adaptive.enabled=true \
  backfill_orders.py \
  --start-date 2025-01-01 \
  --end-date 2025-10-01 \
  --parallelism 100
```

## Best Practices

1. **Idempotency**: Her event unique ID ile işlenmeli
2. **Schema Evolution**: Backward/forward compatible schema'lar
3. **Partitioning**: Zaman bazlı partitioning (date, hour)
4. **Compression**: Parquet/ORC formatlarını kullan
5. **Monitoring**: Her aşamayı monitor et
6. **Testing**: Data quality testleri yaz
