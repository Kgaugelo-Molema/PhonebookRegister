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
                //client.BaseAddress = new Uri("http://localhost:62437/phonebook");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth","xyz");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue());

                Console.WriteLine("Get");
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/phonebook");
                if(response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(data);
                    //Console.WriteLine("Name: " + sites.name + "," + "Year: " + sites.yearInscribed);
                }

                Console.WriteLine("Post");

                /*
                Sites newsite = new Sites();
                newsite.name = "Ryan";
                newsite.yearInscribed = "2019";
                response = await client.PostAsJsonAsync("api/sites", newsite);
                if(response.IsSuccessStatusCode)
                {
                    Uri siteUrl = response.Headers.Location;
                    Console.WriteLine(siteUrl);
                }
                */
            }
        }
    }
}
