using LogicBuilder.App.Maui.Business.Requests;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Requests
{
    public class NewFlowRequestTest
    {
        [Fact]
        public void RoundTrip_PreservesValues()
        {
            NewFlowRequest source = new() { InitialModuleName = "start" };

            NewFlowRequest? result = JsonSerializer.Deserialize<NewFlowRequest>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal("start", result.InitialModuleName);
        }

        [Fact]
        public void RoundTrip_PreservesNull()
        {
            NewFlowRequest? result = JsonSerializer.Deserialize<NewFlowRequest>(JsonSerializer.Serialize(new NewFlowRequest()));

            Assert.NotNull(result);
            Assert.Null(result.InitialModuleName);
        }
    }
}
