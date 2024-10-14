# Library

Change the DefaultConnectionString in appsettings.json
Delete Migration folder in Library.Server

open package manager console, run the following command:
dotnet tool install --global dotnet-ef --version 8.0.10
cd [location of the server project]
dotnet-ef migrations add InitialCreate
dotnet-ef database update

Start Server and Client Project
Local Running Default Urls:
swagger Url: https://localhost:7173/swagger/index.html
App Url: https://127.0.0.1:4200/
