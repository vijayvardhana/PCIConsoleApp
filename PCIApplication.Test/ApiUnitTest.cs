using NUnit.Framework;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Moq.Protected;
using System.Linq;
using System.Net;

namespace PCIApplication.Test
{
    public class Tests
    {
        [TestFixture]
        public class ApiTests
        {
            private HttpClient _httpClient;
            private APIService _apiService;

            [SetUp]
            public void Setup()
            {
                // Initialize HttpClient mock
                var mockHttpClient = new Mock<HttpClient>();
                _httpClient = mockHttpClient.Object;

                // Initialize ApiService with mocked HttpClient
                _apiService = new APIService();
            }
            [Test]
            public async Task TestApiReturnsSuccessCode()
            {
                // Arrange
                string apiUrl = "https://rndfiles.blob.core.windows.net/pizzacabininc/2015-12-14.json";

                // Act
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // Assert
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            [Test]
            public async Task TestApiReturnsData()
            {
                // Arrange
                string expectedData = "Daniel Billsus";
                var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(expectedData)
                };
                var mockHttpHandler = new Mock<HttpMessageHandler>();
                mockHttpHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                    .ReturnsAsync(mockResponse);

                _httpClient = new HttpClient(mockHttpHandler.Object);
                _apiService = new APIService();

                // Act
                var response = await _apiService.GetSchedulesAsync();
                var result = response.FirstOrDefault(r => r.Name == expectedData);
                // Assert
                Assert.AreEqual(expectedData, result.Name);
            }

            
        }
    }
}