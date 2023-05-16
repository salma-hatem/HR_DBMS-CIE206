--USE master; --is put ontop of every other create
--CREATE SCHEMA DataBasePROj ;
--CREATE DATABASE HR_DBMS
USE HR_DBMS 

CREATE TABLE Personal (
	id INT PRIMARY KEY,
	SSN INT UNIQUE,
	Team nvarchar(100),
	Sex nvarchar(20),
	FName nvarchar(100) NOT NULL,
	LName nvarchar(100) NOT NULL,
	Age INT NOT NULL,
	Email nvarchar(100),
	Work_Email nvarchar(100),
	Person_Password char(9),
	Person_Address nvarchar(200),
	Person_Status varchar(50),
	Salary INT NOT NULL,
	Person_Role nvarchar(50),
	Contact_Num INT,
	Person_IMG nvarchar(200),
	Holidays INT,
	check(Email like '%_@_%.%'),
	check(Work_Email like '%_@_%.%')
);

CREATE TABLE Manager(
	Manager_ID int NOT NULL,
	CONSTRAINT Mang_PK PRIMARY KEY (Manager_ID),
	CONSTRAINT Mang_FK_PK FOREIGN KEY (Manager_ID) REFERENCES Personal (ID)
);

CREATE TABLE Recruitment_Manager (
	Recruitment_Mang_ID INT NOT NULL,
	CONSTRAINT RMang_PK PRIMARY KEY (Recruitment_Mang_ID),
	CONSTRAINT RMang_FK_PK FOREIGN KEY (Recruitment_Mang_ID) REFERENCES Personal (ID)
);

CREATE TABLE Training_Manager(
	Training_Mang_ID INT NOT NULL,
	CONSTRAINT TMang_PK PRIMARY KEY (Training_Mang_ID),
	CONSTRAINT TMang_FK_PK FOREIGN KEY (Training_Mang_ID) REFERENCES Personal (ID)
);

CREATE TABLE Personal_Manager (
	--diagram:
	--Personal_Mang_ID ,
	--Person_ID FOREIGN KEY REFERENCES Manager INT PRIMARY KEY
	--making the primary key a foreign key
	Personal_Mang_ID INT NOT NULL,
	CONSTRAINT PMang_PK PRIMARY KEY (Personal_Mang_ID),
	CONSTRAINT PMang_FK_PK FOREIGN KEY (Personal_Mang_ID) REFERENCES Personal (ID)
);

CREATE TABLE Employee (
	EmployeeID INT NOT NULL,
	CONSTRAINT E_PK PRIMARY KEY (EmployeeID),
	CONSTRAINT E_FK_PK FOREIGN KEY (EmployeeID) REFERENCES Personal (ID),
	PMID INT FOREIGN KEY REFERENCES Personal_Manager NOT NULL,
	RMID INT FOREIGN KEY REFERENCES Recruitment_Manager NOT NULL
);

--DOCUMENTS
CREATE TABLE Documents(
	ID INT PRIMARY KEY,
	Doc_Type VARCHAR(50),
	Doc_ize INT,
	Doc_Name VARCHAR(50),
	PersonID INT FOREIGN KEY (PersonID) REFERENCES PERSONAL
);

--Attendance
CREATE TABLE Attendance(
	ID int PRIMARY KEY,
	Atendance_Date Date NOT NULL,
	Clock_in Date,
	Clock_out Date,
	Person_ID int,
	FOREIGN KEY (Person_ID) REFERENCES Personal
);

CREATE TABLE Dependencies(
	Dep_Name nvarchar(100) PRIMARY KEY,
	Person_ID int,
	Age int,
	Relation nvarchar(50),
	Sex nvarchar(50),
	Education nvarchar(100),
	FOREIGN KEY (Person_ID) REFERENCES Personal
);

/* Hamzas Part*/
CREATE TABLE Project (
	ID INT PRIMARY KEY,
	PName VARCHAR(40) NOT NULL UNIQUE,
	PDescription VARCHAR(1000),
	PGoal VARCHAR(250) NOT NULL,
	StartDate DATETIME DEFAULT GETDATE(),
	--1900 -01 -01 00 :00 :00
	EndDate DATETIME NULL,
	DeadLine DATETIME NOT NULL CHECK (DeadLine > GETDATE()),
	--Cant set deadline in past 
	Status_ VARCHAR(30) DEFAULT 'Just Started',
	Progress_Percentage INT DEFAULT 0,
	PMID INT FOREIGN KEY REFERENCES Personal_Manager NOT NULL
);

CREATE TABLE Works_On (
	PMID INT FOREIGN KEY REFERENCES Personal_Manager NOT NULL,
	EID INT FOREIGN KEY REFERENCES Employee NOT NULL,
	Time_Spent INT DEFAULT 0,
	CONSTRAINT Work_On_ID PRIMARY KEY (PMID, EID)
);

CREATE TABLE Training(
	ID INT PRIMARY KEY,
	Training_Name VARCHAR(100) NOT NULL,
	Training_Location VARCHAR(100) NOT NULL,
	Created_by INT,
	Training_Description VARCHAR(300),
	Training_Status INT DEFAULT 0,
	FOREIGN KEY (Created_by) REFERENCES Training_Manager
);




CREATE TABLE Attend_Training(
	TrainingID INT FOREIGN KEY REFERENCES Training NOT NULL,
	E_ID INT FOREIGN KEY REFERENCES Employee NOT NULL,
	Time_Spent INT DEFAULT 0,
	CONSTRAINT ID PRIMARY KEY (TrainingID, E_ID)
);

CREATE TABLE Training_Date(
	ID int,
	Training_Time Time NOT NULL,
	Training_StartDate DATETIME NOT NULL,
	Training_EndDate DATETIME NOT NULL ,
	FOREIGN KEY (ID) REFERENCES Training,
	PRIMARY KEY (ID, Training_StartDate,Training_EndDate),
	constraint check_dates check (Training_StartDate < Training_EndDate)
	
);

CREATE TABLE PenaltiesBonuses (
	ID INT PRIMARY KEY,
	Type_ VARCHAR(20) NOT NULL,
	Percentage_Change FLOAT NOT NULL,
	EmployeeID INT FOREIGN KEY REFERENCES Employee NOT NULL,
	Given_by INT FOREIGN KEY REFERENCES Personal_Manager NOT NULL
);

CREATE TABLE Requests (
	ID INT PRIMARY KEY,
	R_Type VARCHAR(50) NOT NULL,
	R_Status VARCHAR(10) DEFAULT 'Pending' NOT NULL,
	R_Description VARCHAR (300),
	EmployeeID INT FOREIGN KEY REFERENCES Employee NOT NULL,
	Approved_by INT FOREIGN KEY REFERENCES Personal_Manager NOT NULL
);

CREATE TABLE Announcements (
	ID INT PRIMARY KEY,
	Mgs_text VARCHAR(100) NOT NULL,
	Mgs_Date DATETIME NOT NULL,
	M_ID INT FOREIGN KEY REFERENCES Manager NOT NULL
);

CREATE TABLE CurrentUser (ID INT PRIMARY KEY);