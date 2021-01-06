


# Technology Stack
 1. Visual studio 2017 
 2. .Net framework 7.1
 3. Azure SQL Server 
 4. NLOg
 5. Entity Framewor
 6. Language version C# 7.1
 
# Solution Architecture
The solution contains 5 projects
1. ProjAssignment  - This is the main project which contains business logic
2. ProjDAL - This project acts as DAL
3. ProjDB - This acts as the DB schema project
4. ProjSharedLib - This is shared library
5. ProjUnitTest - This contains all Unit tests

NLog is used for logging. 
   a. The log file is created in the {shortdate} folder of "bin" folder of ProjAssignment project i.e. "ProjAssignment\bin\2021-01-07" in case of "ProjAssignment" project and 
   "ProjUnitTest\bin\2021-01-07" - in case of unit tests

# Database diagram
  The database diagram is uploaded @ URL:  https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/EC%20Database%20diagram.PNG
  
  The database creation script along with the sql statement for master data insertion is given in file https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/Database%20Schema%20along%20with%20Master%20Data%20Script.sql
# Unit Tests
All unit test results are uploaded @ URL: https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/AssignLog-UnitTest.txt.log
# Steps to Build Solution
1. Download the Code
2. Open in Visual Studio 2017. 
3. Make the settings as mentioned in #Technology Stack
4. Download the Nuget packages ( if needed)
5. Create your own SQL Server database. Note down the user name and password while creating the database.
6. Use the below given script to create the schema and insert rows in it 
   URL : https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/Database%20Schema%20along%20with%20Master%20Data%20Script.sql
7. Replace the SQL Server name, database name, User name and password in the 'connectionStrings' section of below given files.
   URL: https://github.com/skladhe/SolAssignment/blob/master/ProjAssignment/App.config ( App.Config file of 'ProjAssignment' project )
   and 
   URL: https://github.com/skladhe/SolAssignment/blob/master/ProjDAL/App.config files ( App.Config file of 'ProjDAL' project )
   
  `<add name="ECModel" connectionString="metadata=res://*/ECModel.csdl|res://*/ECModel.ssdl|res://*/ECModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={your sql server name},1433;initial catalog={your database name};persist security info=True;user id={your user name};password={your password};MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />`
  
 8. Build the solution
 9. Run the solution
 
 
