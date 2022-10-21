﻿using Humanizer;
using MedApp.Application.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Logging.Decorators
{
    internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly ILogger<ICommandHandler<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ILogger<ICommandHandler<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }
        public async Task HandleAsync(TCommand command)
        {
            var commandName = typeof(TCommand).Name.Underscore();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _logger.LogInformation("Processing a command: {commandName}...", commandName);
            await _commandHandler.HandleAsync(command);
            stopwatch.Stop();
            _logger.LogInformation("Completed handling a command: {commandName} in {Elapsed}.", commandName, stopwatch.Elapsed);
        }
    }
}
