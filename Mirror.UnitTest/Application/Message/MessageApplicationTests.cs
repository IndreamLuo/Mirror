using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Mirror.Application.Message;
using Mirror.Application.Message.Requests;
using Mirror.Application.Message.Responses;
using Mirror.Application.Service;
using Mirror.Data.Entities;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Message
{
    public class MessageApplicationTests : IInstanceTesting<MessageApplication, IServiceManager, HttpClient>
    {
        [Test]
        public async Task Require()
        {
            var service = new Data.Entities.Service
            {
                Key = "Test",
                Vendors = new[]
                {
                    new Vendor
                    {
                        Url = "http://unit1.test/"
                    },
                    new Vendor
                    {
                        Url = "http://unit2.test/"
                    }
                }
            };

            var serviceManagerMock = new Mock<IServiceManager>();
            serviceManagerMock.SetupGet(serviceManager => serviceManager[It.Is<string>(key => key == service.Key)]).Returns(service);

            var requestContent = "Unit=Test";
            var responseContent1 = "UnitTest1";
            var responseContent2 = "UnitTest2";

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message =>
                        message.RequestUri.AbsoluteUri == service.Vendors.First().Url
                        && message.Content.ReadAsStringAsync().Result == requestContent
                        ),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent1)
                });
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message =>
                        message.RequestUri.AbsoluteUri == service.Vendors.Last().Url
                        && message.Content.ReadAsStringAsync().Result == requestContent),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent2)
                });
            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            var request = new HttpPostRequest(Guid.NewGuid(), service.Key, new StringContent(requestContent));

            var messageApplication = NewTestInstance(serviceManagerMock.Object, httpClient);
            var responses = messageApplication.Require(request);

            var response1 = (responses.First() as HttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, response1.HttpResponseMessage.StatusCode);
            Assert.AreEqual(responseContent1, await (responses.First() as HttpResponse).HttpResponseMessage.Content.ReadAsStringAsync());

            var response2 = (responses.Last() as HttpResponse);
            Assert.AreEqual(HttpStatusCode.OK, response1.HttpResponseMessage.StatusCode);
            Assert.AreEqual(responseContent2, await (responses.Last() as HttpResponse).HttpResponseMessage.Content.ReadAsStringAsync());

            serviceManagerMock.VerifyAll();
            httpMessageHandlerMock.VerifyAll();
        }

        public MessageApplication NewTestInstance(IServiceManager serviceManager, HttpClient httpClient) => new MessageApplication(serviceManager, httpClient);
    }
}