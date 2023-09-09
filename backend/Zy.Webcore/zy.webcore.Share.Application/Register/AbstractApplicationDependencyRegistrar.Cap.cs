using DotNetCore.CAP;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using zy.webcore.Share.ZyCap.Registrar;

namespace zy.webcore.Share.Application.Registrar;
public abstract partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// 注册CAP
    /// </summary>
    protected virtual void AddCapEventBus()
    {
        this.Services.AddCap(s =>
        {
            //this.RabbitMqSection.Get<RabbitMQOptions>()
            s.UseEntityFramework<MySqlDbContext>();
            //s.UseRabbitMQ("127.0.0.1");
            s.UseRabbitMQ(option =>
            {
                var rabbitMqConfig = RabbitMqSection.Get<RabbitMqOptions>();
                option.HostName = rabbitMqConfig.HostName;
                option.VirtualHost = rabbitMqConfig.VirtualHost;
                option.Port = rabbitMqConfig.Port;
                option.UserName = rabbitMqConfig.UserName;
                option.Password = rabbitMqConfig.Password;
                option.ConnectionFactoryOptions = (facotry) =>
                {
                    facotry.ClientProvidedName = ServiceInfo.Id;
                };
            });
            s.Version = ServiceInfo.Version;
            //默认值：cap.queue.{程序集名称},在 RabbitMQ 中映射到 Queue Names。
            s.DefaultGroupName = $"cap.{ServiceInfo.ShortName}.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}";
            //默认值：60 秒,重试 & 间隔
            //在默认情况下，重试将在发送和消费消息失败的 4分钟后 开始，这是为了避免设置消息状态延迟导致可能出现的问题。
            //发送和消费消息的过程中失败会立即重试 3 次，在 3 次以后将进入重试轮询，此时 FailedRetryInterval 配置才会生效。
            s.FailedRetryInterval = 60;
            //默认值：50,重试的最大次数。当达到此设置值时，将不会再继续重试，通过改变此参数来设置重试的最大次数。
            s.FailedRetryCount = 50;
            //默认值：NULL,重试阈值的失败回调。当重试达到 FailedRetryCount 设置的值的时候，将调用此 Action 回调
            //，你可以通过指定此回调来接收失败达到最大的通知，以做出人工介入。例如发送邮件或者短信。
            s.FailedThresholdCallback = (failed) =>
            {
                //todo
            };
            //默认值：24*3600 秒（1天后),成功消息的过期时间（秒）。
            //当消息发送或者消费成功时候，在时间达到 SucceedMessageExpiredAfter 秒时候将会从 Persistent 中删除，你可以通过指定此值来设置过期的时间。
            s.SucceedMessageExpiredAfter = 24 * 3600;
            //默认值：1,消费者线程并行处理消息的线程数，当这个值大于1时，将不能保证消息执行的顺序。
            s.ConsumerThreadCount = 1;
          
        });
        this.Services.AddZyCap();
    }
}