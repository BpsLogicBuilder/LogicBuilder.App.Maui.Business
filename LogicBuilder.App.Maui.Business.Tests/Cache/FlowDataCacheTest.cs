using LogicBuilder.App.Maui.Business.Cache;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Business.Tests.Cache
{
    public class FlowDataCacheTest
    {
        [Fact]
        public void RoundTrip_PreservesValues()
        {
            FlowDataCache source = new()
            {
                PersistentKeys = ["k1", "k2"],
                Items = new Dictionary<string, object> { ["a"] = "value" }
            };

            FlowDataCache? result = JsonSerializer.Deserialize<FlowDataCache>(JsonSerializer.Serialize(source));

            Assert.NotNull(result);
            Assert.Equal(["k1", "k2"], result.PersistentKeys);
            Assert.Single(result.Items);
            Assert.Equal("value", ((JsonElement)result.Items["a"]).GetString());
            Assert.NotNull(result.NavigationBar);
        }
    }
}
