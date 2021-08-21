using NUnit.Framework;
using RestSharp;
using TestSendSmsAPI;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using System;

namespace TestRouteeAPI.Steps
{
    [Binding]
    [TestFixture]
    public class VerifyInsufficientBalanceMessageSteps : Base
    {


        [Test]
        [Given(@"I am an authorized user of Routee\.net")]

        public void GivenIAmAnAuthorizedUserOfRoutee_Net()
        {

            this.GenerateToken();

        }

        [Test]
        [Given(@"I perform POST action for Routee\.net Send SMS API")]
        public void GivenIPerformPOSTActionForRoutee_NetSendSMSAPI()
        {
            this.PostWithBody();


        }

        [Test]
        [Then(@"System must display proper error message i\.e Insufficient Balance")]
        public void ThenSystemMustDisplayProperErrorMessageI_EInsufficientBalance()
        {
            this.VerifyResponseMessageTxt();
        }

        [Test]
        [Then(@"System must display proper error code as (.*)")]
        public void ThenSystemMustDisplayProperErrorCodeAs()
        {
            VerifyStatusCode();
        }

    }
}
