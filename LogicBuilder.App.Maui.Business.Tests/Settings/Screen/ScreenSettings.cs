using LogicBuilder.App.Maui.Business.Settings.Screen;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Settings.Screen
{
    public class ScreenSettingsTest
    {
        [Fact]
        public void RoundTrip_PreservesValues()
        {
            ScreenSettings<string> source = new("form", [], ViewType.ListPage);

            ScreenSettings<string>? result = JsonSerializer.Deserialize<ScreenSettings<string>>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal("form", result.Settings);
            Assert.Equal(ViewType.ListPage, result.ViewType);
            Assert.NotNull(result.CommandButtons);
            Assert.Empty(result.CommandButtons);
        }
    }
}
