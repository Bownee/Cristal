FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled AS runtime
WORKDIR /app
EXPOSE 8080
COPY ./publish .
ENTRYPOINT ["dotnet", "Api.dll"]