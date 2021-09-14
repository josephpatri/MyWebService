using Microsoft.Extensions.Hosting;
using PeliculasAPI.CrossCutting;
using NUnit.Framework;
using PeliculasAPI.ServiceInfo;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PeliculasAPI.Test
{
    public class Tests
    {
        public ILogger<IApiClient> logger;

        public IApiClient client { get; set; }
        public IHost server { get; set; }

        public bool Starting;        

        public Tests()
        {
            
        }

        private void SetUpServer()
        {
            if(Starting)
            {
                return;
            }

            Starting = true;
            try
            {
                server = PeliculasAPI.Program.CreateHostBuilder(Array.Empty<string>()).Build();
                server.StartAsync().GetAwaiter().GetResult();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        ~Tests()
        {
            server.StopAsync().GetAwaiter().GetResult();
        }

        [SetUp]
        public void Setup()
        {
            SetUpServer();
            client = server.GetServiceFromHostContext<IApiClient>();
            logger = server.GetServiceFromHostContext<ILogger<IApiClient>>();
        }

        [Test]
        public void Test1()
        {            
            var get = client.Get().GetAwaiter().GetResult();            
            Assert.IsTrue(get.StatusCode == System.Net.HttpStatusCode.OK && get.Content.Count > 0 );
        }
    }
}
