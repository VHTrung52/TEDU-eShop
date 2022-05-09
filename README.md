# ASP.NET Core 3.1 project from TEDU

## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1

## Tools Used
- Dot NET Core SDK 3.1
- SourceTree
- Visual Studio 2022
- SQL Server 2021

## Youtube tutorial
- Video list: https://www.youtube.com/playlist?list=PLRhlTlpDUWsyN_FiVQrDWMtHix_E2A_UD
- Github link (course project): https://github.com/teduinternational/eShopSolution
- Github link (my project): https://github.com/VHTrung52/TEDU-eShop

## How to configure and run
### Require software
- Visual Studio 2022
- SQL Server 2021
- Dot Net core 3.1
### Configure and run
- Clone code from Github: git clone https://github.com/teduinternational/eShopSolution
- Open solution eShopSolution.sln in Visual Studio 2022
- Set startup project is eShopSolution.Data
- Change connection string in Appsetting.json in eShopSolution.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is eShopSolution.WebApp
- Change database connection in appsettings.Development.json in eShopSolution.WebApp project.
- You need to change 3 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 3 Projects: BackendApi, WebApp and AdminApp.
- Choose profile to run or press F5

## Admin template: https://startbootstrap.com/templates/sb-admin/
## Portal template: https://www.free-css.com/free-css-templates/page194/bootstrap-shop
