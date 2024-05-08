namespace Zy.User.WebApi.BackGroundServices
{
    /// <summary>
    /// 后台进程
    /// </summary>
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {Time}", DateTime.Now);
                //await _hub.Clients.All.SendAsync("ReceiveMessage",DateTime.Now.ToString());
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
