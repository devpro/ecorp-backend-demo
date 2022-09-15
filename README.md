# E Corp backend demo application

[![Docker Image Version (latest semver)](https://img.shields.io/docker/v/devprofr/ecorp-backend-demo?label=Docker)](https://hub.docker.com/r/devprofr/ecorp-backend-demo)

Demonstration of a simple backend for E Corp (from [Mr Robot](https://en.wikipedia.org/wiki/Mr._Robot)). It is a web service application (a REST API to be precise), written in C#, using .NET Framework (free, open source, cross platform).

## Requirements

* .NET SDK
* Docker (or Podman)
* Visual Studio 2022 or any other IDE

## Development server

* Run `dotnet run --project src/WebApi` for a dev server
* Navigate to `https://localhost:7148/swagger`

## Build

* Run `dotnet build` to build the solution

## Unit tests

* Run `dotnet test` to execute the unit test via xUnit (not implemented for the moment)

## End-to-end tests

* Run `dotnet test` to execute the end-to-end tests (not implemented for the moment)

## Local container

* Run `docker build . -t ecorp-backend-demo -f src/WebApi/Dockerfile` to build a new image
* Run `docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development -e AllowedOrigins__0=http://localhost:4200 -e Application__IsHttpsRedirectionEnabled=false -e Application__IsSwaggerEnabled=true ecorp-backend-demo` to run the image locally
* Navigate to `http://localhost:9001/swagger`
