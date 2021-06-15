using RabbitMQ.Client;
using System;
using System.Text;

namespace ProducerConsumerRabbitMQ
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string msg = "Getting started with .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(msg);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent message {0}...", msg);
            }
            Console.WriteLine("Press [enter] to exit the SenderApp");
            Console.ReadLine();
        }
    }
}
