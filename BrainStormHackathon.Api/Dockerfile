FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app

COPY . .

RUN dotnet restore "BrainStormHackathon.Api/BrainStormHackathon.Api.csproj"
RUN dotnet publish "BrainStormHackathon.Api/BrainStormHackathon.Api.csproj" -c Release -o /dist

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runner
WORKDIR /app

COPY --from=builder /dist .

ENTRYPOINT ["dotnet", "BrainStormHackathon.Api.dll"]
