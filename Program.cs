using System;
using System.Net;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {

        public static RedisChannel canal = "perguntas";
        public static IConnectionMultiplexer client = ConnectionMultiplexer.Connect("191.232.234.20");
        static void Main(string[] args)
        {
            Console.WriteLine("=============== BOT RESPONSE INICIADO ================");
            var db = client.GetDatabase();

            var sub = client.GetSubscriber();
            sub.Subscribe(canal, (ch, msg) =>
            {
                Console.WriteLine("================== PEGUEI UMA PERGUNTA ============ ");
                string chave = msg.ToString().Replace("{","").Replace("}","").Split(':')[0] ;
                db.HashSet(chave,"MATHEUS OLIVEIRA - RODRIGO BELMONTE - DIOGO C.", BotResponse.Response(msg.ToString()));
            });

            Console.ReadKey();
        }
    }
}
