FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY simplified-english-helheim.sln ./
COPY BusinessLogic/*.csproj ./BusinessLogic/
COPY BusinessLogic.Interface/*.csproj ./BusinessLogic.Interface/
COPY DataAccess/*.csproj ./DataAccess/
COPY DataAccess.Interface/*.csproj ./DataAccess.Interface/
COPY Domain/*.csproj ./Domain/
COPY Exceptions/*.csproj ./Exceptions/
COPY WebApi/*.csproj ./WebApi/

RUN dotnet restore
COPY . .
WORKDIR /src/BusinessLogic
RUN dotnet build -c Release -o /app

WORKDIR /src/BusinessLogic.Interface
RUN dotnet build -c Release -o /app

WORKDIR /src/DataAccess
RUN dotnet build -c Release -o /app

WORKDIR /src/DataAccess.Interface
RUN dotnet build -c Release -o /app

WORKDIR /src/Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Exceptions
RUN dotnet build -c Release -o /app

WORKDIR /src/WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.dll"]