using System;

namespace RequestRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Directmessages directmessages = new Directmessages();
            directmessages.SendMessage();
            Console.ReadLine();
        }
    }
}
