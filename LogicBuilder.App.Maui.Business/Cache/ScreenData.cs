using LogicBuilder.App.Maui.Business.Cache.Interfaces;
using LogicBuilder.App.Maui.Business.Settings.Screen;

namespace LogicBuilder.App.Maui.Business.Cache
{
    public class ScreenData : IScreenData
    {
        public ScreenSettingsBase? ScreenSettings { get; set; }
    }
}
