using LogicBuilder.App.Maui.Business.Cache;
using LogicBuilder.App.Maui.Business.Settings;
using LogicBuilder.App.Maui.Business.Settings.Screen;
using LogicBuilder.App.Maui.Business.Tests.Settings.Screen;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Settings
{
    public class FlowSettingsTest
    {
        private static readonly JsonSerializerOptions Options = new() { Converters = { new ScreenSettingsStringConverter() } };

        [Fact]
        public void RoundTrip_PreservesScreenSettings()
        {
            FlowSettings source = new(
                new FlowState { Driver = "driver" },
                new FlowDataCache(),
                new ScreenSettings<string>("form", [], ViewType.DetailForm));

            FlowSettings? result = JsonSerializer.Deserialize<FlowSettings>(JsonSerializer.Serialize(source, Options), Options);

            Assert.NotNull(result);
            ScreenSettings<string> screenSettings = Assert.IsType<ScreenSettings<string>>(result.ScreenSettings);
            Assert.Equal("form", screenSettings.Settings);
            Assert.Equal(ViewType.DetailForm, screenSettings.ViewType);
        }

        [Fact]
        public void RoundTrip_PreservesValues()
        {
            FlowSettings source = new(
                new FlowState { Driver = "driver", Selection = "selection" },
                new FlowDataCache { PersistentKeys = ["k1"] },
                null);

            FlowSettings? result = JsonSerializer.Deserialize<FlowSettings>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal("driver", result.FlowState.Driver);
            Assert.Equal("selection", result.FlowState.Selection);
            Assert.Equal(["k1"], result.FlowDataCache.PersistentKeys);
            Assert.Null(result.ScreenSettings);
        }
    }
}
