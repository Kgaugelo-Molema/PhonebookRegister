using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhonebookUI
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
                Console.WriteLine("Get");
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/phonebook");
                if(response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(data);
                }
            }
        }
    }
}
