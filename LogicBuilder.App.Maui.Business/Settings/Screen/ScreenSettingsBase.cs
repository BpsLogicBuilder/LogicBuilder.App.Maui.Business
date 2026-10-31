using LogicBuilder.App.Maui.Forms.Configuration;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Business.Settings.Screen
{
    public abstract class ScreenSettingsBase
    {
        abstract public ViewType ViewType { get; }
        public IEnumerable<CommandButtonDescriptor>? CommandButtons { get; set; }
    }
}
