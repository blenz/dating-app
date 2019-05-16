FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /usr/src/app

COPY *.csproj .
RUN dotnet restore

COPY . .

ENTRYPOINT [ "dotnet", "watch", "run", "--no-restore", "--urls", "http://0.0.0.0:5000"]