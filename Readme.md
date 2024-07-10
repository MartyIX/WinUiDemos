Publish:

 ```
dotnet publish -f net8.0-windows10.0.19041.0 -r win-x64 -p:PlatformTarget=x64 -c Release -p:PublishReadyToRun=False  -p:PublishTrimmed=false -p:WindowsPackageType=None
```

Trace:

```
 dotnet trace collect --format speedscope -- bin\Release\net8.0-windows10.0.19041.0\win-arm64\publish\WinUiDemos.exe
```