using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions;

public class GenerateInterview
{
    private readonly ILogger<GenerateInterview> _logger;

    public GenerateInterview(ILogger<GenerateInterview> logger)
    {
        _logger = logger;
    }

    [Function("GenerateInterview")]
    public void Run([QueueTrigger("interview-generation", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("GenerateInterview received: {Message}", message);
        // TODO: perform generation work
    }
}
