# expAvaloniaLumos

Demo project for Lumos profiler.

# How to use

## Start server
``` bash
dotnet tool restore
dotnet lumos start // it will start the profiler server
```

## Start the desktop app

You can just press the 'Start' button in the IDE or just run via CLI inside expAvaloniaLumos.Desktop.
When you are done, you can close the app. The server should produce the `` telemetry.json `` file that you can open on the speedscope website.

## Start the android app

Not in the moment. I am working on it. I need to figure out how to inject modified assemblies.


# Hot it works

The command `` dotnet lumos start `` starts server that will listen to the connection from the client app. The client app has the 'Lumos.Profiler.Client' nuget.
Then, in the main method, we have the next snippet:
``` C# 
var profiler = new ProfilerClient();
_ = profiler.Connect(IPAddress.Parse("127.0.0.1"), 15000);
```
It will try to connect to the Lumos Profiler Server via IP address and port at the start of the app. 
Also, inside the csproj we have the following target that will modify assemblies to send telemetry:
``` xml
<Target Name="MakeItMeta" AfterTargets="AfterBuild">
    <Exec Command="dotnet makeitmeta inject --config .\makeitmeta.json" />
</Target>
```
The makeitmeta.json looks like that:
``` json
{
  "$schema": "https://raw.githubusercontent.com/byme8/MakeItMeta/main/schema.verified.json",
  "targetAssemblies": [
    "./bin/Debug/net6.0/Avalonia.Base.dll",
    "./bin/Debug/net6.0/Avalonia.Controls.dll",
    "./bin/Debug/net6.0/Avalonia.Desktop.dll"
  ],
  "additionalAssemblies": [
    "./bin/Debug/net6.0/Lumos.Profiler.dll"
  ],
  "attributes": [
    {
      "name": "Lumos.Profiler.Attributes.TelemetryAttribute"
    }
  ]
}
```
The `targetAssemblies` is the list of assemblies to modify.

The `additionalAssemblies` is the list of additional assemblies that will be injected.

The `attributes` is the list of attributes that should be injected.

In our case, it is `` Lumos.Profiler.Attributes.TelemetryAttribute ``, because there are no limitations, it is injected in every method and property.
As a result, every method or property will produce telemetry. 

[Here](https://github.com/byme8/Lumos.Profiler/blob/main/src/Lumos.Profiler/Attributes/TelemetryAttribute.cs) you can have a quick look how the attribute is implemented.
