FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY . /app

RUN dotnet restore
RUN dotnet build

CMD ["dotnet", "run"]

docker build -t RansomSharp:v1 .

docker run -d RansomSharp:v1