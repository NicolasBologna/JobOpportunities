using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace EndavaCareers.API.Integrations;

public class Sender : ISender
{
    public void CreateEntity<T>(T entity) where T : class
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "job_offers_queue",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            String jsonified = JsonConvert.SerializeObject(entity);
            byte[] customerBuffer = Encoding.UTF8.GetBytes(jsonified);

            channel.BasicPublish(exchange: "",
                                 routingKey: "job_offers_queue",
                                 basicProperties: null,
                                 body: customerBuffer);

            Console.WriteLine(" [x] Sent {0}", typeof(T));
        }
    }
}

