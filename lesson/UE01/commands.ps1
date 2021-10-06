dockercompletion -scope currentuser
import-module dockercompletion
dotnet new globaljson --sdk-version 5.0.0
dotnet --list-runtimes
dotnet new console -- output <dirname>
dotnet build
dotnet run
dotnet .\bin\Debug\net5.0\<projectname>.dll
dotnet sln add .\PrimeCalc.Client\PrimeCalc.Client.csproj .\PrimeCalc.Math\PrimeCalc.Math.csproj
dotnet add .\PrimeCalc.Client.csproj  reference ..\PrimeCalc.Math\PrimeCalc.Math.csproj
dotnet run --project PrimeCalc.Client
dotnet add .\PrimeCalc.Client.csproj package Newtonsoft.Json
dotnet publish --configuration release --output ./fdd
dotnet publish --configuration release --output ./scd --self-contained --runtime win-x64
dotnet publish --configuration release --output ./sfe --self-contained --runtime win-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
docker run --rm -it mcr.microsoft.com/dotnet/runtime:5.0-alpine sh
docker run --rm --volume ${pwd}/fdd:/app  mcr.microsoft.com/dotnet/runtime:5.0-alpine ls -l /app
docker run --rm --volume ${pwd}/fdd:/app  mcr.microsoft.com/dotnet/runtime:5.0-alpine dotnet /app/PrimeCalc.Client.dll 40
dotnet publish --configuration release --output ./scd-linux --self-contained --runtime linux-musl-x64
docker run --rm --volume ${pwd}/scd-linux:/app  mcr.microsoft.com/dotnet/runtime:5.0-alpine /app/PrimeCalc.Client 40
docker build --tag prime-calculator .
docker run --rm prime-calculator 5000  