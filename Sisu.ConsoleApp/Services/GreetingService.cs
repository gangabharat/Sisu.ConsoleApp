using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sisu.ConsoleApp.Model;
using Sisu.ConsoleApp.Services.Interface;
using System;
using System.Linq;
using System.Collections;
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
        private readonly IHttpClientHelper<Photos> httpClient;

        public GreetingService(ILogger<GreetingService> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
            this.httpClient = new HttpClientHelper<Photos>(); //need to chage DI for TYpe
        }
        public async Task Run()
        {

            string? apiUrl = config.GetValue<string>("ApiUrl");
            if (!string.IsNullOrWhiteSpace(apiUrl))
            {
                var response = await httpClient.GetMultipleItemsRequest(apiUrl, default);

                if (response != null)
                {

                    #region "Parallel Task Execution"
                    Parallel.ForEach(response, item =>
                    {
                        logger.LogInformation($"{item.Id}");
                        StreamWriter sw = File.AppendText($"c:\\temp\\test\\sample-Parallerl-{item.Id}.csv");
                        sw.WriteLineAsync(item.ToString());
                        sw.Close();                       
                    });
                    #endregion

                    #region "Create Task & Execution"
                    var tasks = response.Select(async item =>
                    {                       
                        await Task.Run(() =>
                        {
                            //AppDomain.CurrentDomain.BaseDirectory
                            logger.LogInformation($"{item.Id}");
                            StreamWriter sw = File.AppendText($"c:\\temp\\test\\sample-{item.Id}.txt");

                            sw.WriteLineAsync(item.ToString());
                            sw.Close();
                            //Console.WriteLine($"{item.Id}\t{item.Title} has {item.ThumbnailUrl} with {item.Url}");
                        });
                    });

                    await Task.WhenAll(tasks);
                    #endregion
                }
            }           
        }
    }
}
