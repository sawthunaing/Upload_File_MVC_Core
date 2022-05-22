# Upload_File_MVC_Core
A small project for techincal test for Net Core C# (2.1).  Can upload different data formats of CSV and XML files and Generate data via Web API.

VERSIONS
The main branch is currently running ASP.NET Core 2.1 and Visual studio 2019 
SQL script (schema and data) ( need to run MSSQL server 2019)

It is small project file upload and generate data via Web API. Sorry Raw UI.
Use Dependency injection for Loosely coupling in Logging function and DataAccess.
(Loosely coupling means two objects are independent of each other. That means if we change one object then it will not affect another object. The loosely coupled nature of software development allows us to manage future changes easily and also allows us to manage the complexity of the application.)

Added Logging function with Dependecy injection. So can easily maintain and testable.

Added Read DataAccess for high traffic data.

Configuring the sample to use SQL Server

When you clone this source code, you will get default connection string. So, need to change your own MSSQL server connection string.

  "ConnectionStrings": {
   "DefaultConnection": "Server={Server Host};Database=Transaction_DB;Persist Security Info=True;User ID={UserID};Password={Password};MultipleActiveResultSets=True;App=EntityFramework",
 "ReadConnection": "Server={Server Host};Database=Transaction_DB;Persist Security Info=True;User ID={UserID};Password={Password};MultipleActiveResultSets=True;App=EntityFramework"
   
  },

