using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ComsumindoWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

            Console.WriteLine("Bem vindo ao gerador de piadas, deseja ler uma piada?");
            Console.WriteLine("Sim: Digite S");
            Console.WriteLine("Não: Digite N");

            string choice = Console.ReadLine();

            if (choice == "n" || choice == "N") break;

                Console.WriteLine("Escolha a categoria da sua piada");
                Console.WriteLine("Miscellaneous: Digite 1");
                Console.WriteLine("Programming: Digite 2");
                Console.WriteLine("Dark: Digite 3");
                Console.WriteLine("Pun: Digite 4");

                string info = Console.ReadLine();

                getJokes(info);
                Console.ReadKey();
             
            }
        }


        public static async void getJokes(string info)
        {
    
            HttpClient httpClient = new HttpClient();

            string category = "";

            if (info == "1") category = "Miscellaneous";
            else if (info == "2") category = "Programming";
            else if (info == "3") category = "Dark";
            else if (info == "4") category = "Pun";

            string url = $"https://sv443.net/jokeapi/v2/joke/{category}?blacklistFlags=nsfw,religious,political,racist,sexist";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string dados = await response.Content.ReadAsStringAsync();
            MyJokes j = JsonConvert.DeserializeObject<MyJokes>(dados);

            Console.WriteLine("Sua Piada:");

            if (j.type == "single") Console.WriteLine($"{j.joke}");
            else
            {
                Console.WriteLine($"{j.setup}");
                Console.WriteLine($"{j.delivery}");
            }

        }
    }
}
