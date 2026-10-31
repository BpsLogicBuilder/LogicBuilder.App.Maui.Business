using LogicBuilder.App.Maui.Business.Requests;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Requests
{
    public class CommandButtonRequestTest
    {
        [Fact]
        public void RoundTrip_PreservesValues()
        {
            CommandButtonRequest source = new() { NewSelection = "next" };

            CommandButtonRequest? result = JsonSerializer.Deserialize<CommandButtonRequest>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal("next", result.NewSelection);
        }

        [Fact]
        public void RoundTrip_PreservesNull()
        {
            CommandButtonRequest? result = JsonSerializer.Deserialize<CommandButtonRequest>(JsonSerializer.Serialize(new CommandButtonRequest()));

            Assert.NotNull(result);
            Assert.Null(result.NewSelection);
        }
    }
}
