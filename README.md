# E Corp backend demo application

[![GitLab Pipeline Status](https://gitlab.20.101.158.124.sslip.io/ecorp/ecorp-backend-demo/badges/develop/pipeline.svg)](https://gitlab.20.101.158.124.sslip.io/ecorp/ecorp-backend-demo/-/pipelines)
[![Quality Gate Status](https://sonarqube.20.101.158.124.sslip.io/api/project_badges/measure?project=ecorp_ecorp-backend-demo&metric=alert_status&token=4dddb4d0fa579d83231a24bfff069fa3ea3c71ae)](https://sonarqube.20.101.158.124.sslip.io/dashboard?id=ecorp_ecorp-backend-demo)

Demonstration of a simple backend for E Corp (from [Mr Robot](https://en.wikipedia.org/wiki/Mr._Robot)). It is a web service application (a REST API to be precise), written in C#, using .NET Framework (free, open source, cross platform).

## How to run

### Container image

Container images are automatically built and available on [Harbor](https://harbor.20.101.158.124.sslip.io/harbor/projects/2/repositories/ecorp-backend-demo/artifacts-tab).

Execute the following command line to run a container locally.

```bash
docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development -e AllowedOrigins__0=http://localhost:4200 -e Application__IsHttpsRedirectionEnabled=false -e Application__IsSwaggerEnabled=true harbor.20.101.158.124.sslip.io/ecorp/ecorp-backend-demo:1.0.17
```

Navigate to [localhost:9001/swagger](http://localhost:9001/swagger) to open Swagger page to view the REST API definitions and do API calls.

### Helm chart

The best way to deploy and run this application is by executing the workload as containers orchestrated Kubernetes, thanks to the [Helm chart](https://devpro.github.io/helm-charts/).

Execute the following command lines to deploy the definitions to your Kubernetes cluster.

```bash
# adds devpro Helm repository
helm repo add devpro https://devpro.github.io/helm-charts

# installs E Corp applications
helm install ecorp-demo
```

## How to build

### Requirements

* .NET SDK
* Docker (or Podman)
* Visual Studio 2022 or any other IDE

### Build & test

Execute the following command lines to build and test the solution.

```bash
# builds the solution
dotnet build

# executes the tests via xUnit (not implemented for the moment)
dotnet test
```

### Run the development server

Execute the following command line to run the API.

```bash
dotnet run --project src/WebApi
```

Navigate to [localhost:7148/swagger](https://localhost:7148/swagger).

### Run in a local container

Execute the following command line to build and run the API in a container.

```bash
docker build . -t ecorp-backend-demo -f src/WebApi/Dockerfile
docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development -e AllowedOrigins__0=http://localhost:4200 -e Application__IsHttpsRedirectionEnabled=false -e Application__IsSwaggerEnabled=true ecorp-backend-demo
```

Navigate to [localhost:9001/swagger](http://localhost:9001/swagger) to open Swagger page to view the REST API definitions and do API calls.
