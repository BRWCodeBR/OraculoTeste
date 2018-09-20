using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BotResponse
    {
        public static string Response(string pergunta)
        {
            try
            {
                string[] respose = new string[] { "A Resposta eu sabia mais não sei mais.",
                   "O Diogo disse que era 3 só que ta errado",
                   "A resposta de " + pergunta + " é http://Google.com",
                   "O pergunta é da hora a resposta é eu não sei.",
                   "A resposta é 23",
                   "Atendimento das 08 ás 17 Horas."
                };

                Random rnd = new Random();

                return respose[rnd.Next(0,6)];
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
