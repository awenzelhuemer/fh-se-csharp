FROM mcr.microsoft.com/dotnet/runtime:5.0-alpine
COPY ./fdd /app
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/PrimeCalc.Client.dll"]