## Phonebook Register
Install the following before deploying to your machine:
* Angular 8 CLI
* SQL Server 2017
* Visual Studio 2019
* .Net Core 3

## Deploy locally
* Build the entire solution in Visual Studio 2019 or later. 
* Create a database on your local SQL server instance - `Catalog=Phonebook`.
* Deploy database - `"$SqlServerInstallDir\140\DAC\bin\SqlPackage.exe" /Action:Publish /SourceFile:"$PhonebookRegisterSourceDir\PhonebookDatabase\bin\Debug\PhonebookDatabase.dacpac" /Profile:"$PhonebookRegisterSourceDir\PhonebookDatabase\PhonebookDatabase.publish.xml"`
* Run REST API - `dotnet run --project "$PhonebookRegisterSourceDir\PhonebookWebApi\PhonebookWebApi.csproj"`
* Run the Web UI:
    - `cd $PhonebookRegisterSourceDir\AngularWebUi\` 
    - `npm install`
    - `npm start`

Open http://localhost:4200/ to explore the site.
