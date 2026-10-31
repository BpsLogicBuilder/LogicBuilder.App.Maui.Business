using LogicBuilder.App.Maui.Business.Cache;
using LogicBuilder.App.Maui.Business.Settings.Screen;
using LogicBuilder.App.Maui.Business.Tests.Settings.Screen;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Cache
{
    public class ScreenDataTest
    {
        private static readonly JsonSerializerOptions Options = new() { Converters = { new ScreenSettingsStringConverter() } };

        [Fact]
        public void RoundTrip_PreservesScreenSettings()
        {
            ScreenData source = new() { ScreenSettings = new ScreenSettings<string>("form", [], ViewType.EditForm) };

            ScreenData? result = JsonSerializer.Deserialize<ScreenData>(JsonSerializer.Serialize(source, Options), Options);

            Assert.NotNull(result);
            ScreenSettings<string> screenSettings = Assert.IsType<ScreenSettings<string>>(result.ScreenSettings);
            Assert.Equal("form", screenSettings.Settings);
            Assert.Equal(ViewType.EditForm, screenSettings.ViewType);
        }

        [Fact]
        public void RoundTrip_PreservesNullScreenSettings()
        {
            ScreenData? result = JsonSerializer.Deserialize<ScreenData>(JsonSerializer.Serialize(new ScreenData()));

            Assert.NotNull(result);
            Assert.Null(result.ScreenSettings);
        }
    }
}
