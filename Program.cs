using System;
using System.Net;
using StackExchange.Redis;

namespace ConsoleApp1
{
    class Program
    {

        public static RedisChannel canal = "perguntas";
        public static IConnectionMultiplexer client = ConnectionMultiplexer.Connect("191.232.234.20:8000");
        static void Main(string[] args)
        {
            Console.WriteLine("=============== BOT RESPONSE INICIADO ================");
            var db = client.GetDatabase();

            var sub = client.GetSubscriber();
            sub.Subscribe(canal, (ch, msg) =>
            {
                Console.WriteLine("================== PEGUEI UMA PERGUNTA ============ ");
                if(msg.ToString().StartsWith("p"))
                    GeraResposta(msg.ToString());
            });

            Console.ReadKey();
        }

        public static void GeraResposta(string msg)
        {
            var pub = client.GetSubscriber();
            var resposta = getRespostaGoogle(msg);
            pub.Publish(canal, resposta);
        }

        public static string getRespostaGoogle(string msg)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");

            string apiKey = "AIzaSyDiRCI-3Djsw8qTrXIYF7AIqnCSyyHmFmM";
            string cx = "009431853094902135308:axmjfgvmaam";


               //var results = webClient.DownloadString(String.Format("https://www.google.com.au/search?q={0}&alt=json", msg));
            var results = webClient.DownloadString(String.Format("https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}&alt=json", apiKey, cx, msg));

            // web.Dispose();
            return results;
        }
    }
}
