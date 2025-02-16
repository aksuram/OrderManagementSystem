# How to run the project
* Inside `src\WebAPI\appsettings.json` change the `DefaultConnection` connection string to point to your own postgres database.
* Check if the `dotnet-ef` tool is installed by typing `dotnet ef` in the main project folder. If not - execute the command below to install it
  `dotnet tool install --global dotnet-ef`
* Inside the main project(where the solution file is located) folder run the command below to create the database structure.
  `dotnet ef database update --project src\Infrastructure --startup-project src\WebApi`
* Should be possible to build and run the project now.
