using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderManagement.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Api.BackgroundServices
{
    public class QueuedUpdateService : BackgroundService
    {
        private readonly ILogger<QueuedUpdateService> logger;
        private readonly IOrderManagementLogic logic;
        private readonly UpdateChannel channel;

        public QueuedUpdateService(ILogger<QueuedUpdateService> logger, IOrderManagementLogic logic, UpdateChannel channel)
        {
            this.logger = logger;
            this.logic = logic;
            this.channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var customerId in channel.ReadAllAsync(stoppingToken))
            {
                await logic.UpdateTotalRevenue(customerId);
                logger.LogInformation($"Totals for customer {customerId} updated");
            }
        }
    }
}
