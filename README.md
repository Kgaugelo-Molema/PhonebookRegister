## Phonebook Register
Install the following before deploying to your machine:
* Angular 8 CLI
* SQL Server 2017
* Visual Studio 2019
* .Net Core 3

## Deploy locally
* Build solution `$PhonebookRegisterSourceDir\PhonebookRegister.sln` in Visual Studio 2019 or later. 
* Create empty database on localhost SQL server - `sqlcmd -Q "CREATE DATABASE Phonebook"`.
* Deploy database - `$SqlServerInstallDir\140\DAC\bin\SqlPackage.exe /Action:Publish /SourceFile:$PhonebookRegisterSourceDir\PhonebookDatabase\bin\Debug\PhonebookDatabase.dacpac /Profile:$PhonebookRegisterSourceDir\PhonebookDatabase\PhonebookDatabase.publish.xml`
* Run REST API - `dotnet run --project $PhonebookRegisterSourceDir\PhonebookWebApi\PhonebookWebApi.csproj`
* Run Web UI:
    - `cd $PhonebookRegisterSourceDir\AngularWebUi\` 
    - `npm install`
    - `npm start`

Open http://localhost:4200/ to explore the site.
