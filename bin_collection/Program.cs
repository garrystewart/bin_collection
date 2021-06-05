using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bin_collection
{
    public class Program
    {
        private const string _host = "192.168.18.33";
        private const string _username = "7-T1xsMKMiHWXiypIfybpwbsc0jRlM1p2mLaj2fq";

        private static readonly HttpClient _httpClient = new HttpClient();

        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();

            //CreateHostBuilder(args).Build().Run();
        }

        private static async Task MainAsync()
        {
            // turn all lights blue
            string requestUri = $"http://{_host}/api/{_username}/groups/9/action";

            StringContent content = new StringContent("{\"on\": true, \"bri\": 254, \"hue\": 46920}");

            HttpResponseMessage response = await _httpClient.PutAsync(requestUri, content);
            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
