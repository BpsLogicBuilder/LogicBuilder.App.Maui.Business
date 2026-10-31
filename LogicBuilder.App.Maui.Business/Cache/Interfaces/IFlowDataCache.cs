using LogicBuilder.App.Maui.Forms.Configuration.Navigation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Business.Cache.Interfaces
{
    public interface IFlowDataCache
    {
        Dictionary<string, object> Items { get; set; }
        NavigationBarDescriptor NavigationBar { get; set; }
        List<string> PersistentKeys { get; set; }
    }
}