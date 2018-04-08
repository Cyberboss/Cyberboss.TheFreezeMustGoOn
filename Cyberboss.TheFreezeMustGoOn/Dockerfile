FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Cyberboss.TheFreezeMustGoOn/Cyberboss.TheFreezeMustGoOn.csproj Cyberboss.TheFreezeMustGoOn/
RUN dotnet restore
COPY . .
WORKDIR /src/Cyberboss.TheFreezeMustGoOn
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cyberboss.TheFreezeMustGoOn.dll"]
