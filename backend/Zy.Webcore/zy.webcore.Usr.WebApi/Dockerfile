#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["zy.webcore.Usr.WebApi/zy.webcore.Usr.WebApi.csproj", "zy.webcore.Usr.WebApi/"]
COPY ["zy.webcore.Share.WebApi/zy.webcore.Share.WebApi.csproj", "zy.webcore.Share.WebApi/"]
COPY ["zy.webcore.Share.Application/zy.webcore.Share.Application.csproj", "zy.webcore.Share.Application/"]
COPY ["zy.webcore.Share.Cache/zy.webcore.Share.Cache.csproj", "zy.webcore.Share.Cache/"]
COPY ["zy.webcore.Share.Redis/zy.webcore.Share.Redis.csproj", "zy.webcore.Share.Redis/"]
COPY ["zy.webcore.Share/zy.webcore.Share.csproj", "zy.webcore.Share/"]
COPY ["zy.webcore.Share.Constraint/zy.webcore.Share.Constraint.csproj", "zy.webcore.Share.Constraint/"]
COPY ["zy.webcore.Share.DistributedLock/zy.webcore.Share.DistributedLock.csproj", "zy.webcore.Share.DistributedLock/"]
COPY ["zy.webcore.share.Repository/zy.webcore.Share.Repository.csproj", "zy.webcore.share.Repository/"]
COPY ["zy.webcore.Share.Config/zy.webcore.Share.Config.csproj", "zy.webcore.Share.Config/"]
COPY ["zy.webcore.Share.Rpc/zy.webcore.Share.Rpc.csproj", "zy.webcore.Share.Rpc/"]
COPY ["zy.webcore.Share.Yitter/zy.webcore.Share.Yitter.csproj", "zy.webcore.Share.Yitter/"]
COPY ["zy.webcore.Share.ZyCap/zy.webcore.Share.ZyCap.csproj", "zy.webcore.Share.ZyCap/"]
COPY ["zy.webcore.Share.Nacos/zy.webcore.Share.Nacos.csproj", "zy.webcore.Share.Nacos/"]
COPY ["zy.webcore.Usr.Application/zy.webcore.Usr.Application.csproj", "zy.webcore.Usr.Application/"]
COPY ["zy.webcore.Usr.Constraint/zy.webcore.Usr.Constraint.csproj", "zy.webcore.Usr.Constraint/"]
COPY ["zy.webcore.Usr.Repository/zy.webcore.Usr.Repository.csproj", "zy.webcore.Usr.Repository/"]
RUN dotnet restore "zy.webcore.Usr.WebApi/zy.webcore.Usr.WebApi.csproj"
COPY . .
WORKDIR "/src/zy.webcore.Usr.WebApi"
RUN dotnet build "zy.webcore.Usr.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zy.webcore.Usr.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zy.webcore.Usr.WebApi.dll"]