using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Inventory.API.Helper;

public class RabbitMqQueueReader
{
    private ConnectionFactory connectionFactory;

    public RabbitMqQueueReader()
    {
        connectionFactory = new ConnectionFactory();
    }
    
    public void ReadMessage()
    {
        connectionFactory.Uri = new Uri("amqp://guest:guest@10.0.0.29:5672");
        connectionFactory.ClientProvidedName = "Inventory Service";
        //This is call IDisposable at the end, so it will automaticly call garbage collector
        using (var connection = connectionFactory.CreateConnection())
        {
            var channel = connection.CreateModel();
            string exchange = "OrderAPIExchange";
            string routingKey = "order-api-routing-key";
            string queueName = "order-api-queue";
            channel.ExchangeDeclare(exchange, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchange, routingKey, null);
            channel.BasicQos(0,1,false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                channel.BasicAck(args.DeliveryTag,false);
            };
            string str = channel.BasicConsume(queueName, false, consumer);
            channel.BasicCancel(str);
            channel.Close();
            connection.Close();
        }
    }
}