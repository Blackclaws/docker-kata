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

This application has a very simple configuration. Builtin secret is read from environment variable ```SECRET__SECRET``` and is a Guid.
Secret storage path is read from 
```json
{
  "Secret": {
    "SecretPath": 10
  }
}
```


# Exercise

Create a Dockerfile that builds this application and can be deployed as an image. By default it should listen on port 8080.

Secrets must not be kept in Dockerfile