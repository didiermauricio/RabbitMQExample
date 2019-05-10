using System;

namespace RequestRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Directmessages directmessages = new Directmessages();
            for (int i = 0; i <= 250; i++)
            {
                String message = "Message Number: " + i;
                directmessages.SendMessage(message);
            }
            Console.ReadLine();
        }
    }
}
