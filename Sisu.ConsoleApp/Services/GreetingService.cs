using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sisu.ConsoleApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisu.ConsoleApp.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> logger;
        private readonly IConfiguration config;

        public GreetingService(ILogger<GreetingService> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
        }
        public void Run()
        {

            for (int i = 0; i < config.GetValue<int>("LoopTimes"); i++)
            {
                logger.LogInformation($"This is the {i} loop {i}");
                logger.LogError($"This is the {i} loop");
                logger.LogWarning($"This is the {i} loop");
                Console.WriteLine($"This is the {i} loop");
            }
        }
    }
}
