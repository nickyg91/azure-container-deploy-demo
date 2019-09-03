FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY Azure.Docker.Demo.Api/bin/Release/netcoreapp2.2/publish app/
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "app/Azure.Docker.Demo.Api.dll"]
