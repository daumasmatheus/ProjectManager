using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ProjectManager.API.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;

namespace ProjectManager.Infrastructure.Tests.IntegrationTests
{
    public class TaskIntegrationTests : IDisposable
    {
        private TestServer server;
        private HttpClient client;

        public TaskIntegrationTests()
        {
            var webBuilder = new WebHostBuilder().UseStartup<Startup>();
            server = new TestServer(webBuilder);
            client = server.CreateClient();
        }

        [Fact]
        public async void Task_ShouldNotFoundEndpoint()
        {
            var response = await client.GetAsync("/api/task/blabla");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async void Task_ShoudPostNewTask()
        {
            var taskSample = new TaskDto
            {
                TaskId = Guid.NewGuid(),
                Title = "Task Test",
                StatusId = 1,
                PriorityId = 1,
                Description = "Task Test",
                CreatedDate = DateTime.Now
            };

            HttpRequestMessage postRequest = new HttpRequestMessage(HttpMethod.Post, "api/task/PostNewTask");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(taskSample), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            var responseStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<TaskDto>(responseStr);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<TaskDto>(responseObj);
            Assert.NotNull(responseObj);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
