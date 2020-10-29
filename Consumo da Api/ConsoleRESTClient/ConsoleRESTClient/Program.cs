using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting;

namespace ConsoleRESTClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44350/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("GET \n Informe o Id desejado:");
                string id = Console.ReadLine();
                HttpResponseMessage response = await client.GetAsync("api/produtos/"+ id);
                Console.Clear();
                if (response.IsSuccessStatusCode)
                {
                    Produto produto = await response.Content.ReadAsAsync<Produto>();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", produto.Id, produto.Nome, produto.Categoria, produto.Preco);
                    Console.ReadLine();
                }
                
            }
        }
    }
}
