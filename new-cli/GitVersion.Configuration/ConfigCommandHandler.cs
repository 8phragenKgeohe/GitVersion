﻿using System.Threading.Tasks;
using GitVersion.Command;
using GitVersion.Infrastructure;

namespace GitVersion.Configuration
{
    public class ConfigCommandHandler : CommandHandler<ConfigSettings>
    {
        private readonly ILogger logger;
        private readonly IService service;

        public ConfigCommandHandler(ILogger logger, IService service)
        {
            this.logger = logger;
            this.service = service;
        }

        public override Task<int> InvokeAsync(ConfigSettings settings)
        {
            var value = service.Call();
            logger.LogInformation($"Command : 'config', LogFile : '{settings.LogFile}', WorkDir : '{settings.WorkDir}' ");
            return Task.FromResult(value);
        }
    }
}