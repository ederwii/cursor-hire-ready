using Azure.Messaging.ServiceBus;
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
    public void Run([QueueTrigger("interview-generation", Connection = "ServiceBusConnection")] string message)
    {
        _logger.LogInformation("GenerateInterview received: {Message}", message);
        // TODO: enqueue work or call API in future
    }
}
