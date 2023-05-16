FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 3000/tcp
ENV ASPNETCORE_URLS=http://*:3000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["111.csproj", "./"]
RUN dotnet restore "111.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "111.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "111.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "111.dll"]