using System;
using System.Net.Http;

namespace A_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var requestTask = httpClient.GetAsync("https://www.baidu.com");
            Console.WriteLine($"the request was sent, status:{requestTask.Status}");
            Console.WriteLine(requestTask.Result.Headers);
        }
    }
}
