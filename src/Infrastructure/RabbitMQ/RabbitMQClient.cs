using Atomiv.Core.Common.Serialization;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Atomiv.Infrastructure.RabbitMQ
{
    public class RabbitMQClient
    {
        public RabbitMQClient(IOptions<RabbitMQConfiguration> options)
        {
            var connectionFactory = GetConnectionFactory(options);
            var connection = CreateConnection(connectionFactory);

            Channel = connection.CreateModel();
        }

        public void DeclareQueue(string queueName)
        {
            Channel.QueueDeclare(queueName);
        }

        public void PublishBasic(string exchange, string routingKey, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            Channel.BasicPublish(exchange: exchange,
                routingKey: routingKey,
                basicProperties: null,
                body: body);
        }

        public IModel Channel { get; }

        protected virtual IConnectionFactory GetConnectionFactory(IOptions<RabbitMQConfiguration> options)
        {
            var configuration = options.Value;

            return new ConnectionFactory
            {
                HostName = configuration.HostName,
                UserName = configuration.UserName,
                Password = configuration.Password,
                Port = configuration.Port,
            };
        }

        protected virtual IConnection CreateConnection(IConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }
    }
}
