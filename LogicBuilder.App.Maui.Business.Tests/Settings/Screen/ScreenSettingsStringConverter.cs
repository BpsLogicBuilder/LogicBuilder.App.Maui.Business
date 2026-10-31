using LogicBuilder.App.Maui.Business.Settings.Screen;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.App.Maui.Business.Tests.Settings.Screen
{
    internal sealed class ScreenSettingsStringConverter : JsonConverter<ScreenSettingsBase>
    {
        public override ScreenSettingsBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => JsonSerializer.Deserialize<ScreenSettings<string>>(ref reader, options);

        public override void Write(Utf8JsonWriter writer, ScreenSettingsBase value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, (ScreenSettings<string>)value, options);
    }
}
