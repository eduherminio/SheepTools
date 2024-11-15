﻿using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace SheepTools.Moq.Test;

public class MoqGenericLoggerExtensionsTest
{
    private readonly FixtureServiceGenericLogger _service;
    private readonly Mock<ILogger<FixtureServiceGenericLogger>> _logger;

    public MoqGenericLoggerExtensionsTest()
    {
        _logger = new Mock<ILogger<FixtureServiceGenericLogger>>();
        _service = new FixtureServiceGenericLogger(_logger.Object);
    }

    [Fact]
    public void VerifyLogMessage()
    {
        var dictionary = new Dictionary<string, LogLevel>
        {
            ["Error"] = LogLevel.Error,
            ["Critical"] = LogLevel.Critical,
            ["Trace"] = LogLevel.Trace
        };

        foreach (var entry in dictionary)
        {
            _service.LogMessage(entry.Value, entry.Key);

            _logger.VerifyLog(entry.Value);
            _logger.VerifyLog(entry.Value, entry.Key);
            _logger.VerifyLog(entry.Value, Times.Once);
            _logger.VerifyLog(entry.Value, Times.Once());
            _logger.VerifyLog(entry.Value, Times.Once, entry.Key);
            _logger.VerifyLog(entry.Value, Times.Once(), entry.Key);
            _logger.VerifyLog(entry.Value, entry.Key, Times.Once);
            _logger.VerifyLog(entry.Value, entry.Key, Times.Once());

            _service.LogMessage(entry.Value, entry.Key);

            _logger.VerifyLog(entry.Value);
            _logger.VerifyLog(entry.Value, entry.Key);
            _logger.VerifyLog(entry.Value, Times.Exactly(2));
            _logger.VerifyLog(entry.Value, Times.Exactly(2), entry.Key);
        }
    }

    [Fact]
    public void VerifyLogException()
    {
        var dictionary = new Dictionary<string, Tuple<LogLevel, StackOverflowException>>
        {
            ["Error"] = new Tuple<LogLevel, StackOverflowException>(LogLevel.Error, new StackOverflowException(nameof(LogLevel.Error))),
            ["Critical"] = new Tuple<LogLevel, StackOverflowException>(LogLevel.Critical, new StackOverflowException(nameof(LogLevel.Critical))),
            ["Trace"] = new Tuple<LogLevel, StackOverflowException>(LogLevel.Trace, new StackOverflowException(nameof(LogLevel.Trace))),
        };

        foreach (var entry in dictionary)
        {
            _service.LogException(entry.Value.Item1, entry.Value.Item2, entry.Key);

            _logger.VerifyLog(entry.Value.Item2, Times.Once);
            _logger.VerifyLog(entry.Value.Item2, Times.Once());
            _logger.VerifyLog(entry.Value.Item2, entry.Key, Times.Once);
            _logger.VerifyLog(entry.Value.Item2, entry.Key, Times.Once());
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, Times.Once);
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, Times.Once());
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, entry.Key, Times.Once);
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, entry.Key, Times.Once());
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, entry.Key);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Once);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Once());
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Once, entry.Key);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Once(), entry.Key);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, entry.Key, Times.Once());
            _logger.VerifyLog(entry.Value.Item1, entry.Key, Times.Once);

            _service.LogException(entry.Value.Item1, entry.Value.Item2, entry.Key);

            _logger.VerifyLog(entry.Value.Item2, Times.Exactly(2));
            _logger.VerifyLog(entry.Value.Item2, entry.Key, Times.Exactly(2));
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, Times.Exactly(2));
            _logger.VerifyLog(entry.Value.Item1, entry.Value.Item2, entry.Key, Times.Exactly(2));
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, entry.Key);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Exactly(2));
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, Times.Exactly(2), entry.Key);
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, entry.Key, Times.Exactly(2));
            _logger.VerifyLog<FixtureServiceGenericLogger, StackOverflowException>(entry.Value.Item1, entry.Key, Times.Exactly(2));
        }
    }
}

#pragma warning disable CA2254 // Template should be a static expression

public class FixtureServiceGenericLogger
{
    private readonly ILogger _logger;

    public FixtureServiceGenericLogger(ILogger<FixtureServiceGenericLogger> logger)
    {
        _logger = logger;
    }

    public void LogMessage(LogLevel level, string message)
    {
        _logger.Log(level, message);
    }

    public void LogException(LogLevel level, Exception e, string message)
    {
        _logger.Log(level, e, message);
    }
}

#pragma warning restore CA2254 // Template should be a static expression
