using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedService.Ca
{
    public class FooService : BackgroundService
    {
        private readonly int _millisecondsTimeout;

        public FooService()
        {
            _millisecondsTimeout = 2000; // the value would have been injected with IOptions/Settings
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_logger.LogDebug($"FooService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogDebug($"FooService task doing background work.");

                SimulateSomeWorker();

                //await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
                await Task.Delay(_millisecondsTimeout);
            }

            //_logger.LogDebug($"GracePeriod background task is stopping.");
        }

        private void SimulateSomeWorker()
        {
            Console.WriteLine("Worker was run {0}", DateTime.Now);
        }
    }
}
