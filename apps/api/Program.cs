var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for local web dev
var corsPolicy = "local-dev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicy);

// Health
app.MapGet("/health", () => Results.Ok(new { status = "ok" }))
   .WithName("Health")
   .WithOpenApi();

// In-memory stores for POC
var jobs = new Dictionary<string, object>();
var reports = new Dictionary<string, object>();

// Create Job (POC)
app.MapPost("/jobs", (JobCreateRequest req) =>
{
    var id = Guid.NewGuid().ToString("n");
    var job = new { id, req.title, req.responsibilities, req.mustHaves };
    jobs[id] = job;
    return Results.Created($"/jobs/{id}", job);
}).WithOpenApi();

// Upload Resume (stub)
app.MapPost("/resumes", () => Results.Ok(new { id = Guid.NewGuid().ToString("n") }))
   .WithOpenApi();

// Create Interview (enqueue generation request to storage queue for local dev)
app.MapPost("/interviews", async (InterviewCreateRequest req) =>
{
    var interviewId = Guid.NewGuid().ToString("n");
    try
    {
        var storage = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING")
                     ?? "UseDevelopmentStorage=true";
        var queueClient = new Azure.Storage.Queues.QueueClient(storage, "interview-generation");
        await queueClient.CreateIfNotExistsAsync();
        await queueClient.SendMessageAsync(System.Text.Json.JsonSerializer.Serialize(new { interviewId, req.jobId, req.resumeId }));
    }
    catch
    {
        // swallow in POC; still return queued
    }
    return Results.Accepted($"/interviews/{interviewId}", new { id = interviewId, status = "queued" });
}).WithOpenApi();

// Get Report (stub)
app.MapGet("/reports/{id}", (string id) =>
{
    if (reports.TryGetValue(id, out var report)) return Results.Ok(report);
    return Results.NotFound();
}).WithOpenApi();

// Existing sample endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record JobCreateRequest(string title, string responsibilities, string mustHaves);
public record InterviewCreateRequest(string jobId, string resumeId);
