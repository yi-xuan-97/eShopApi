using System.Text;
using RabbitMQ.Client;

namespace Order.API.Helper;

public class Notification
{
    private ConnectionFactory connectionFactory;

    public Notification()
    {
        connectionFactory = new ConnectionFactory();
    }

    public void AddMessageToQueue(string message)
    {
        connectionFactory.Uri = new Uri("amqp://guest:guest@10.0.0.29:5672");
        connectionFactory.ClientProvidedName = "Order Service";
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
            byte[] messageBtyes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange, routingKey, null, messageBtyes);
            channel.Close();
            connection.Close();
        }
        
        
    }
}