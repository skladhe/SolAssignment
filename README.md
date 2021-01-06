
# Technology Stack
 1. Visual studio 2017 is used to develop this solution
 2. .Net framework 7.1
 3.  Azure SQL Server 
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

