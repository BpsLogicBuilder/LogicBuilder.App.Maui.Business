using LogicBuilder.App.Maui.Business.Cache;
using LogicBuilder.App.Maui.Business.Settings.Screen;

namespace LogicBuilder.App.Maui.Business.Settings
{
    public class FlowSettings(FlowState flowState, FlowDataCache flowDataCache, ScreenSettingsBase? screenSettings)
    {
        public FlowState FlowState { get; set; } = flowState;
        public FlowDataCache FlowDataCache { get; set; } = flowDataCache;
        public ScreenSettingsBase? ScreenSettings { get; set; } = screenSettings;
    }
}
