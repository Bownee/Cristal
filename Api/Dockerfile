# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS puboutput
ARG VERSION
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "./Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
#RUN dotnet build "./Api.csproj" -c Release -o /app/build

# This stage is used to publish the service project to be copied to the final stage
#FROM build AS publish
RUN dotnet publish "./Api.csproj" -c Release -o /app/publish /p:UseAppHost=false -p:IncludeSourceRevisionInInformationalVersion=false -p:Version=$VERSION

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled AS final
WORKDIR /app
EXPOSE 8080
COPY --from=puboutput /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]