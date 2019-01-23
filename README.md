# Automatic registration extensions for Microsoft.Extensions.DependencyInjection

Scans assemblies looking for the custom attribute `[AutoRegister]` to register types in the container.

## Setup
To use with an `IWebHostBuilder` instance:
```
  WebHost.CreateDefaultBuilder(args)
    .AutoRegisterServices()
    .UseStartup<Startup>();
```

To use with an `IHostBuilder` instance (Generic host model):
```
  var host = new HostBuilder()
      .AutoRegisterServices()
      .Build();
```

## Usage
To register a type without an interface:
```
[AutoRegister(ServiceLifetime.Scoped)]
public class MyService {
}
```

To register a type with all interfaces:
```
[AutoRegister(ServiceLifetime.Scoped)]
public class MyService: IMyService, IAnotherService {
}
```

To register a type with a specific interface:
```
[AutoRegister(ServiceLifetime.Scoped, typeof(IAnotherService))]
public class MyService: IMyService, IAnotherService {
}
```
