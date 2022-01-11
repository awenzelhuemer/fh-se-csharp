using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace PersonApi
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> logger;
        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            this.logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var task = new Task(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    logger.LogInformation("Background service is active.");
                    stoppingToken.WaitHandle.WaitOne(5000);
                }
            }, stoppingToken);
            
            task.Start();

            return task;
        }
    }
}
