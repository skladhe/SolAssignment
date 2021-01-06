# Technology Stack
1. Visual studio 2017 is used to develop this solution
2. .Net framework 7.1
3.  Azure SQL Server 
4. NLOg
5. Entity Framewor
6. Language version C# 7.1
# Solution Architecture
8. The solution contains 5 projects as given below.
	a. ProjAssignment  - This is the main project which contains business logic
	b. ProjDAL - This project acts as DAL
	c. ProjDB - This acts as the DB schema project
	d. ProjSharedLib - This is shared library
	e. ProjUnitTest - This contains all Unit tests
9. NLog is used for logging. 
   a. The log file is created @ in the {shortdate} folder of "bin" folder of ProjAssignment project

# Database diagram
  The database diagram is uploaded @ https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/EC%20Database%20diagram.PNG
  The script for database creation along with the sql statement for master data insertion is given in file https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/Database%20Schema%20along%20with%20Master%20Data%20Script.sql
# Unit Tests
All unit test results are uploaded @ https://github.com/skladhe/SolAssignment/blob/master/Miscellaneous/AssignLog-UnitTest.txt.log

