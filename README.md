# LogicBuilder.App.Maui.Business

A .NET Standard 2.0 library that defines the shared contracts (business objects) used by different MAUI client applications to interact with a workflow defined in [Logic Builder](https://github.com/BpsLogicBuilder/LogicBuilder). It consolidates the flow metadata structures so that a MAUI client and the service hosting the flow exchange the same types.

The library depends on `LogicBuilder.App.Maui.Forms.Configuration`, which supplies the form, command button and navigation bar descriptors referenced by these types.

## Contents

### Requests (`Requests`)
Payloads a client sends to the flow service.
- `NewFlowRequest` - starts a new flow; `InitialModuleName` names the module to begin with.
- `CommandButtonRequest` - reports a command button press; `NewSelection` carries the selection that drives the next step of the flow.

### Settings (`Settings`)
The flow state and screen definitions returned to the client.
- `FlowSettings` - aggregate of `FlowState`, `FlowDataCache` and the optional `ScreenSettingsBase` for the current step.
- `FlowState` - the position in the workflow: `Driver`, `Selection`, `ModuleBeginName`, `ModuleEndName`, and the `CallingModuleStack` and `CallingModuleDriverStack` used to return from nested modules.

### Screen settings (`Settings.Screen`)
- `ScreenSettingsBase` - abstract base exposing the `ViewType` and the `CommandButtons` (`CommandButtonDescriptor`) for the screen.
- `ScreenSettings<TFormDescriptor>` - concrete settings holding the screen's form descriptor (`Settings`), command buttons and view type.
- `ViewType` - enum of supported screen kinds: `EditForm`, `DetailForm`, `ListPage`, `SearchPage`, `TextPage`.

### Cache (`Cache`, `Cache.Interfaces`)
State kept across flow steps.
- `IFlowDataCache` / `FlowDataCache` - `Items` (flow data by key), `PersistentKeys` (keys retained between steps) and the `NavigationBar` descriptor.
- `IScreenData` / `ScreenData` - holds the current `ScreenSettingsBase`.

## Usage

Reference this package from both the MAUI client and the service that runs the Logic Builder flow, then serialize these types (for example with `System.Text.Json`) to exchange flow state. Because `ScreenSettingsBase` is abstract, serializers need a converter that maps it to the concrete `ScreenSettings<T>` form descriptor type in use (see the test project for an example).

## Tests

`LogicBuilder.App.Maui.Business.Tests` verifies that `FlowState`, `FlowSettings` and `ScreenSettings<T>` round-trip through JSON serialization.

## License

MIT