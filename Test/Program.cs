using RestClient.Builders.Interfaces;
using RestClient.Serializers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        class Request
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        class Response
        {
            public string Data { get; set; }
        }

        static async Task Test(IRestClientBuilder builder)
        {
            var client = builder
                .WithSerializer(new JsonSerializer())
                //.WithExtenders(new )
                .Build();
            var response = await client.PostAsync<Request, Response>(new Uri(""), new Request());

        }
    }
}
