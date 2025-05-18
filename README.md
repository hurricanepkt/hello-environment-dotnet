# hello-environment-dotnet
A simple debugging docker container that dumps a json object with all the available configuration variables


Sample files

compose.yaml

```yaml
name: sample-compose
services:
    hello-environment-dotnet:
        ports:
            - 8080:8080
        image: ghcr.io/hurricanepkt/hello-environment-dotnet:latest
        restart: unless-stopped
        environment:
            - From=inline
        env_file:
            - network.env
```

network.env
```
TZ=America/New_York
```