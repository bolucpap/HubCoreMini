FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HubCoreMini/HubCoreMini.csproj", "HubCoreMini/"]
RUN dotnet restore "HubCoreMini/HubCoreMini.csproj"
COPY . .
WORKDIR "/src/HubCoreMini"
RUN dotnet build "HubCoreMini.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HubCoreMini.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HubCoreMini.dll"]