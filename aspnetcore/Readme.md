# Simple Web Api

This simple web api can be started from the command line via
```shell
dotnet run
```

It can be built into an app via
```shell
dotnet publish -o OUTPUT_DIR
```

The published app can be run inside the published directory via:
```shell
dotnet aspnetcore.dll --urls "http://*:port"
```

# Configuration

This application has a very simple configuration. You can change the amount of forecasts by setting within appsettings.json which must be in the same folder as the dll:
```json
{
  "Weather": {
    "ForecastAmount": 10
  }
}
```


# Exercise

Create a Dockerfile that builds this application and can be deployed as an image. By default it should listen on port 8080.

The default amount of forecasts should be 5.