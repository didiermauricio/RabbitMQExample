using System;
using RabbitMQ.Client;



namespace RabbitMQConsumer
{
    class Program
    {
        private const string UName = "guest";
        private const string Pwd = "guest";
        private const string HName = "localhost";

        static void Main(string[] args)
        {
            Console.WriteLine($"Starting");
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HName,
                UserName = UName,
                Password = Pwd,
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            // accept only one unack-ed message at a time

            // uint prefetchSize, ushort prefetchCount, bool global

            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            Console.WriteLine("Receiver created!");
            channel.BasicConsume("request.queue", false, messageReceiver);
            Console.ReadLine();

        }

    }

}
