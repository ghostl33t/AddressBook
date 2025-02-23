# Address Book
### CASE 1: Database Import
###### 1. Clone the repository.
###### 2. Open MSSQL Management Studio.
###### 3. Log in to the SQL server.
###### 4. Right-click on Databases → Import Data Tier Application → Select the AddressBook.bacpac file from the project files.
###### 5. Update the DbConnection string property in the appsettings.

### CASE 2: EXECUTE MIGRATIONS - New Database
###### 1. Clone the repository.
###### 2. Update the DbConnection property in appsettings with your DB connection string.
###### 3. Execute the following command in the Package Manager Console: dotnet ef database update to update the database and fill the countries and cities tables with dummy data.
###### 4. A new database should be created with the specified name (currently "AddressBook").


#### Application Demo link: https://youtu.be/8lCFcjF8bCc
