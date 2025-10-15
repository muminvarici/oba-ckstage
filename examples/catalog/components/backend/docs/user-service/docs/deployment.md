# Deployment Guide

## Deployment Options

- Docker Container
- Kubernetes
- Serverless (AWS Lambda/Google Cloud Functions)

## Docker Deployment

### Build Image

```bash
docker build -t user-service:latest .
```

### Run Container

```bash
docker run -d \
  --name user-service \
  -p 3000:3000 \
  -e DATABASE_URL=postgresql://... \
  -e REDIS_URL=redis://... \
  -e JWT_SECRET=... \
  user-service:latest
```

### Docker Compose

```yaml
version: '3.8'

services:
  user-service:
    build: .
    ports:
      - "3000:3000"
    environment:
      DATABASE_URL: postgresql://postgres:password@db:5432/userdb
      REDIS_URL: redis://redis:6379
      JWT_SECRET: ${JWT_SECRET}
    depends_on:
      - db
      - redis

  db:
    image: postgres:14
    environment:
      POSTGRES_DB: userdb
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: password
    volumes:
      - postgres_data:/var/lib/postgresql/data

  redis:
    image: redis:7
    volumes:
      - redis_data:/data

volumes:
  postgres_data:
  redis_data:
```

## Kubernetes Deployment

### Deployment Manifest

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: user-service
  labels:
    app: user-service
spec:
  replicas: 3
  selector:
    matchLabels:
      app: user-service
  template:
    metadata:
      labels:
        app: user-service
    spec:
      containers:
      - name: user-service
        image: user-service:latest
        ports:
        - containerPort: 3000
        env:
        - name: DATABASE_URL
          valueFrom:
            secretKeyRef:
              name: user-service-secrets
              key: database-url
        - name: JWT_SECRET
          valueFrom:
            secretKeyRef:
              name: user-service-secrets
              key: jwt-secret
        resources:
          requests:
            memory: "256Mi"
            cpu: "250m"
          limits:
            memory: "512Mi"
            cpu: "500m"
        livenessProbe:
          httpGet:
            path: /health
            port: 3000
          initialDelaySeconds: 30
          periodSeconds: 10
        readinessProbe:
          httpGet:
            path: /health/ready
            port: 3000
          initialDelaySeconds: 5
          periodSeconds: 5
```

### Service Manifest

```yaml
apiVersion: v1
kind: Service
metadata:
  name: user-service
spec:
  selector:
    app: user-service
  ports:
    - protocol: TCP
      port: 80
      targetPort: 3000
  type: ClusterIP
```

### Deploy

```bash
kubectl apply -f k8s/
```

## ArgoCD Deployment

Add to ArgoCD application:

```yaml
apiVersion: argoproj.io/v1alpha1
kind: Application
metadata:
  name: user-service
  namespace: argocd
spec:
  project: default
  source:
    repoURL: https://github.com/example-org/user-service
    targetRevision: main
    path: k8s
  destination:
    server: https://kubernetes.default.svc
    namespace: production
  syncPolicy:
    automated:
      prune: true
      selfHeal: true
```

## Environment Variables

### Required

| Variable | Description | Example |
|----------|-------------|---------|
| `DATABASE_URL` | PostgreSQL connection string | `postgresql://user:pass@host:5432/db` |
| `REDIS_URL` | Redis connection string | `redis://host:6379` |
| `JWT_SECRET` | JWT signing secret | `your-secret-key` |

### Optional

| Variable | Description | Default |
|----------|-------------|---------|
| `PORT` | Server port | `3000` |
| `NODE_ENV` | Environment | `production` |
| `LOG_LEVEL` | Logging level | `info` |

## Health Checks

### Liveness Probe

```
GET /health
```

Returns `200 OK` if service is running.

### Readiness Probe

```
GET /health/ready
```

Returns `200 OK` if service is ready to accept traffic (database and Redis connected).

## Monitoring

- **Prometheus metrics**: `/metrics`
- **Grafana dashboard**: Pre-configured for service monitoring
- **Logs**: Structured JSON logs to stdout

## Scaling

### Horizontal Scaling

```bash
kubectl scale deployment user-service --replicas=5
```

### Auto-scaling

```yaml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: user-service-hpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: user-service
  minReplicas: 3
  maxReplicas: 10
  metrics:
  - type: Resource
    resource:
      name: cpu
      target:
        type: Utilization
        averageUtilization: 70
```

## Rollback

```bash
kubectl rollout undo deployment/user-service
```

## Troubleshooting

### Pod not starting

```bash
kubectl describe pod <pod-name>
kubectl logs <pod-name>
```

### Database connection issues

Check database connectivity:
```bash
kubectl exec -it <pod-name> -- nc -zv db-host 5432
```

### Performance issues

Check metrics:
```bash
kubectl top pods
```
