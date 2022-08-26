using JobOpportunities.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

class NewJobOffer
{
    public static void Main(string[] args)
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

            var message = GetMessage(args);
            var body = Encoding.UTF8.GetBytes(message);

            JobOffer newJobOffer = new()
            {
                Title = "test rabitmq",
                ValidUntil = DateTime.Now.AddDays(30),
            };

            String jsonified = JsonConvert.SerializeObject(newJobOffer);
            byte[] customerBuffer = Encoding.UTF8.GetBytes(jsonified);

            channel.BasicPublish(exchange: "",
                                 routingKey: "job_offers_queue",
                                 basicProperties: null,
                                 body: customerBuffer);
            Console.WriteLine(" [x] Sent {0}", message);
        }
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }

    private static string GetMessage(string[] args)
    {
        return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
    }
}