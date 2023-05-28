#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["cicdweb/cicdweb.csproj", "cicdweb/"]
RUN dotnet restore "cicdweb/cicdweb.csproj"
COPY . .
WORKDIR "/src/cicdweb"
RUN dotnet build "cicdweb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cicdweb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cicdweb.dll"]