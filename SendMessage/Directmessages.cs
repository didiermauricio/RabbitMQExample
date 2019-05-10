using RabbitMQ.Client;
using System;
using System.Text;

namespace RequestRabbitMQ
{
    public class Directmessages
    {
        private const string UName = "guest";
        private const string PWD = "guest";
        private const string HName = "localhost";
        public void SendMessage(String message)
        {
            //Main entry point to the RabbitMQ .NET AMQP client
            var connectionFactory = new ConnectionFactory()
            {
                UserName = UName,
                Password = PWD,
                HostName = HName
            };
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;
            byte[] messagebuffer = Encoding.Default.GetBytes(message);
            model.BasicPublish("request.exchange", "directexchange?key", properties, messagebuffer);
            Console.WriteLine("Message Sent");
            Console.WriteLine("*********************************************************************************************************");
        }

    }

}
