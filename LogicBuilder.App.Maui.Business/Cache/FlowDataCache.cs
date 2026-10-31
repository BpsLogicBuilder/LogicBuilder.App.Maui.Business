using LogicBuilder.App.Maui.Business.Cache.Interfaces;
using LogicBuilder.App.Maui.Forms.Configuration.Navigation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Business.Cache
{
    public class FlowDataCache : IFlowDataCache
    {
        public List<string> PersistentKeys { get; set; } = [];
        public Dictionary<string, object> Items { get; set; } = [];
        public NavigationBarDescriptor NavigationBar { get; set; } = new NavigationBarDescriptor("", "", []);
    }
}
