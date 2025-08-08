using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace functions;

public class ScoreInterview
{
    private readonly ILogger<ScoreInterview> _logger;

    public ScoreInterview(ILogger<ScoreInterview> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ScoreInterview))]
    public void Run([QueueTrigger("myqueue-items", Connection = "")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}