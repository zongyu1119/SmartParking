#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081
EXPOSE 4433

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Zy.Message.WebApi/Zy.Message.WebApi.csproj", "Zy.Message.WebApi/"]
RUN dotnet restore "./Zy.Message.WebApi/./Zy.Message.WebApi.csproj"
COPY . .
WORKDIR "/src/Zy.Message.WebApi"
RUN dotnet build "./Zy.Message.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Zy.Message.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zy.Message.WebApi.dll"]

# cd /home/gitCodes/ZyMsg
# git pull origin master
# cd /home/gitCodes/ZyMsg/ZyMessage/ZyMessage
# docker build -t zymessage .
# docker stop zymsg
# docker rm zymsg
# docker run -d -p 8081:8081 --name zymsg --restart always zymessage 