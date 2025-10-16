using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
{%- if values.enableHealthChecks %}
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
{%- endif %}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

{%- if values.enableSwagger %}
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { 
        Title = "${{ values.name }} API", 
        Version = "v1",
        Description = "${{ values.description }}"
    });
});
{%- endif %}

{%- if values.enableHealthChecks %}
builder.Services.AddHealthChecks();
{%- endif %}

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    {%- if values.enableSwagger %}
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "${{ values.name }} API v1"));
    {%- endif %}
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

{%- if values.enableHealthChecks %}
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = _ => false
});
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false
});
{%- endif %}

app.Run();
