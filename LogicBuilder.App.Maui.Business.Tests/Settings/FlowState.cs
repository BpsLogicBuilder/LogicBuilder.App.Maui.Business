using LogicBuilder.App.Maui.Business.Settings;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Settings
{
    public class FlowStateTest
    {
        [Fact]
        public void RoundTrip_PreservesValues()
        {
            FlowState source = new()
            {
                Driver = "driver",
                Selection = "selection",
                CallingModuleDriverStack = ["d1", "d2"],
                CallingModuleStack = ["m1", "m2"],
                ModuleBeginName = "begin",
                ModuleEndName = "end"
            };

            FlowState? result = JsonSerializer.Deserialize<FlowState>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal("driver", result.Driver);
            Assert.Equal("selection", result.Selection);
            Assert.Equal(["d1", "d2"], result.CallingModuleDriverStack);
            Assert.Equal(["m1", "m2"], result.CallingModuleStack);
            Assert.Equal("begin", result.ModuleBeginName);
            Assert.Equal("end", result.ModuleEndName);
        }
    }
}
