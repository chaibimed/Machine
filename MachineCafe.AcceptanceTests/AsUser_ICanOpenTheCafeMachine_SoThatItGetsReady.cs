using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MachineCafe.WebApi;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace MachineCafe.AcceptanceTests
{
    public class AsUser_ICanOpenTheCafeMachine_SoThatItGetsReady
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            var server = TestServer.Create<Startup>();
            _client = server.HttpClient;
            _client.BaseAddress = new Uri("http://localhost:2000/api/user/getReady");
        }
        [Test]
        public async Task GivenTheMachineClosed_WhenAttemptToOpenIt_IShouldGetOkResult()
        {
            var result = await _client.PostAsync("http://localhost:2000/api/user/getReady",null);
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GivenTheMachineOpen_WhenIOpenIt_ItShouldReturnConfilct()
        {
            var result = await _client.PostAsync("http://localhost:2000/api/user/getReady", null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result.ReasonPhrase, Is.EqualTo(HttpStatusCode.Conflict));

        }


    }
}
