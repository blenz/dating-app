FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /usr/src/app

COPY DatingApp.csproj .
COPY Directory.Build.props .
RUN dotnet restore

ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]