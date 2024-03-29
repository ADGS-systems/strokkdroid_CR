#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal-arm64v8 AS base
FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
#EXPOSE 6500

#FROM mcr.microsoft.com/dotnet/sdk:3.1-focal-arm64v8 AS build
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["IntegrationTest/IntegrationTest.csproj", "IntegrationTest/"]
RUN dotnet restore "IntegrationTest/IntegrationTest.csproj"
COPY . .
WORKDIR "/src/IntegrationTest"
RUN dotnet build "IntegrationTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationTest.dll"]