using System;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MachineCafe.WebApi;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace MachineCafe.AcceptanceTests
{
    public class AsUser_ICanTurnOff_Machine
    {
        private HttpClient _client;
        private readonly string _getReadyUrl = "http://localhost:2000/api/user/getReady";

        [SetUp]
        public void SetUp()
        {
            var server = TestServer.Create<Startup>();
            Database.SetInitializer(new DbTestInitializer());
            _client = server.HttpClient;
            _client.BaseAddress = new Uri(_getReadyUrl);
        }
        [Test]
        public async Task GivenTheMachineClosed_WhenAttemptToOpenIt_IShouldGetOkResult()
        {
            var result = await _client.PostAsync(_getReadyUrl, null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}