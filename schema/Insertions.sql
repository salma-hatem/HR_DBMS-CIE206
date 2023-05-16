

INSERT INTO Personal (
        	id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    ) VALUES
    (
        1,
        1234567890,
        'The wolfs',
        'Male',
        'Omar',
        'Ahmed',
        '20',
        'tt@hr.com',
        'e-omar@hr.com',
        'try1234',
        '11-street clock, sun city, Egypt',
        'Working',
        12000,
        'Accountant',
        123456789,
        '~/images/1/ProfilePic.jepg',
        10
);


INSERT INTO
    Personal (
        	id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    )
VALUES
    (
        2,
        987654321,
        'The wolfs',
        'Male',
        'Othman',
        'Ahmed',
        '27',
        'Oth@hr.com',
        'e-othman@hr.com',
        'try1234',
        '11-street clock, moon city, Egypt',
        'Working',
        20000,
        'Manager',
        1029384756,
        '~/images/2/ProfilePic.jepg',
        12
    )
;


-- Person 3 is recruitment manager
--Person 2 in personal manager
INSERT INTO
    Personal (
    id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    )
VALUES
    (
        3,
        1357908642,
        'The Night',
        'Male',
        'Zaid',
        'Hasan',
        '22',
        'Zd@hr.com',
        'e-zaid@hr.com',
        'try1234',
        '11-street oval, moon city, Egypt',
        'Working',
        15000,
        'Manager',
        123456789,
        '~/images/3/ProfilePic.jepg',
        6
);


INSERT INTO
    Personal (
        	id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    )
VALUES
    (
        4,
        12547899,
        'hero team',
        'Male',
        'Ali',
        'Hasan',
        '25',
        'aali@hr.com',
        'e-ali@hr.com',
        'try5678',
        '13-street oval, Maadi city, Egypt',
        'Working',
        15600,
        'Employee',
        125698874,
        '~/images/6/ProfilePic.jepg',
        2
);

INSERT INTO
    Personal (
    id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    )
VALUES
    (
        5,
        25896314,
        'dream team',
        'female',
        'Nada',
        'Ali',
        '24',
        'nali@hr.com',
        'e-nada@hr.com',
        'try9978',
        '13-street oval, Nasr city, Egypt',
        'Working',
        30000,
        'Employee',
        36985214,
        '~/images/4/ProfilePic.jepg',
        2
);

INSERT INTO
    Personal (
        	id ,
	SSN ,
	Team ,
	Sex ,
	FName ,
	LName,
	Age ,
	Email ,
	Work_Email ,
	Person_Password ,
	Person_Address ,
	Person_Status ,
	Salary ,
	Person_Role ,
	Contact_Num ,
	Person_IMG ,
	Holidays 
    )
VALUES
    (
        6,
        558746996,
        'Team 5',
        'female',
        'Soha',
        'Mahgoub',
        '21',
        'sMahgoub@hr.com',
        'e-soha@hr.com',
        'try5578',
        '13-street oval, Zayed city, Egypt',
        'Working',
        40000,
        'Employee',
        369874563,
        '~/images/1/ProfilePic.jepg',
        7
);
--Creating 2 managers for employee
INSERT INTO Manager(
    Manager_ID 
)
VALUES(1);

INSERT INTO
    Manager(Manager_ID)
VALUES
    (
	2);

INSERT INTO
    Manager(Manager_ID)
VALUES
    (
	3
);


--Create Personal Manager

INSERT INTO Personal_Manager
(
    Personal_Mang_ID
)
VALUES 
(
    1
);

--INSERT INTO Personal_Manager
--(
--    Personal_Mang_ID
--)
--VALUES 
--(
--    2
--);

--INSERT INTO Personal_Manager
--(
--    Personal_Mang_ID
--)
--VALUES 
--(
--    3
--);

--Create Recruitment Manager 
INSERT INTO Recruitment_Manager (
        Recruitment_Mang_ID
        )
VALUES
(
   2
);

INSERT INTO Training_Manager(Training_Mang_ID)
VALUES (3);

--6 person , 3 mnagers, 3 employees
--INSERT INTO Training_Manager(Training_Mang_ID)
--VALUES (2);

--INSERT INTO Training_Manager(Training_Mang_ID)
--VALUES (3);


--Create Employee
INSERT INTO
    Employee (
EmployeeID,       
        PMID ,
        RMID 
    )
VALUES
(
    4,
    1,
    2
);

INSERT INTO
    Employee (
     EmployeeID,
        PMID ,
        RMID 
    )
VALUES
(
    5,

    1,
    2
);

INSERT INTO
    Employee (
    EmployeeID,
        PMID ,
        RMID 
    )
VALUES
(
    6,
    1,
    2
);

-- Project
INSERT INTO Project(
   	ID ,
	PName,
	PDescription ,
	PGoal ,
	StartDate ,
	--1900 -01 -01 00 :00 :00
	EndDate ,
	DeadLine ,
	--Cant set deadline in past 
	Status_ ,
	Progress_Percentage ,
	PMID 
)
VALUES 
(
    1,
    'Project Mathew',
	'Project about mathew',
	'The goal is to succeed',
    '20120618 10:34:09 AM',
	'20230618 10:34:09 AM',
	'20240618 10:34:09 AM',
    'Half-Way',
    57,
    1
);




INSERT INTO Attendance
(
    id ,
    Atendance_Date,
    Person_id 
)
VALUES
(1,'2008 -09 -05',1),
(2, '2008 -09 -05', 2),
(3, '2008 -09 -05', 3);



-- Employees Documents

INSERT INTO Documents
(ID ,
	Doc_Type ,
	Doc_ize ,
	Doc_Name )
VALUES
(1,'pdf',20,'Birth Certificate'),
(2,'word',31,'College Degree'),
(3,'pdf',15,'Military Certificate');




INSERT INTO Dependencies
(
    DEP_Name,
    Person_id,
    Age,
    Relation,
    Sex,
    Education
)
VALUES
('Hamza', 1 , 19, 'Son', 'Male', 'College'),
('Omar', 1, 23, 'Son', 'Male', 'Working');

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description 
 )
VALUES (123,'Leadership Workshop','Maadi',3,'Training to explain the leadership skills');

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description 
)
VALUES (456,'Presentaion Workshop','Maadi',3,'Workshop for presentation skills');

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description 
)
VALUES (789,'Finance Workshop','October Gardens',3,'Workshop to explain the introduction for finance');

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description ,Training_Status
)
VALUES (147,'Python Workshop','Sheikh Zayed',3,'Intro to Python',1);

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description ,Training_Status
)
VALUES (258,'Writing Workshop','Giza',3,'How to Write Professionally',1);

INSERT INTO Training(ID ,
	Training_Name ,
	Training_Location ,
	Created_by ,
	Training_Description ,Training_Status
)
VALUES (369,'Networking Workshop','Nasr City',3,'Networking Event',1);

INSERT INTO Attend_Training(TrainingID,E_ID,Time_Spent)
VALUES(123,4,2)

INSERT INTO Attend_Training(TrainingID,E_ID,Time_Spent)
VALUES(456,5,7)
INSERT INTO Attend_Training(TrainingID,E_ID,Time_Spent)
VALUES(789,6,9)


INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate  )
VALUES(123,'05:12:00','06-22-2021 05:12:00','08-18-2023 08:12:00');
--how to initialize datetime??

INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate)
VALUES(456,'08:30:00','12-22-2020 08:30:00','06-12-2023 11:30:00');

INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate)
VALUES(789,'12:30:00','07-15-2023 12:30:00','09-12-2023 12:30:00');

INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate)
VALUES(147,'09:30:00','08-22-2021 09:30:00','11-12-2021 12:30:00');

INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate)
VALUES(789,'07:30:00','02-15-2022 07:30:00','05-10-2022 11:30:00');

INSERT INTO Training_Date(ID,Training_Time,Training_StartDate,Training_EndDate)
VALUES(789,'09:30:00','03-30-2020 09:30:00','07-25-2020 01:30:00');
INSERT INTO Works_on(PID,EID,Time_spent)
VALUES (1,4,12);

INSERT INTO Works_on(PID,EID,Time_spent)
VALUES (1, 6, 8);

INSERT INTO Works_on(PID,EID,Time_spent)
VALUES (1, 5, 8);

INSERT INTO Requests(ID ,
	R_Type ,
	R_Status,
	R_Description,
	EmployeeID,
	Approved_by)
VALUES (1,'Holiday','Pending' ,'Holiday Request for 5 days',5,1);

INSERT INTO Requests(ID ,
	R_Type ,
	R_Status,
	R_Description,
	EmployeeID,
	Approved_by)
VALUES (2,'Break','Approved','Break Request for 2 hours',4,1);

INSERT INTO Requests(ID ,
	R_Type ,
	R_Status,
	R_Description,
	EmployeeID,
	Approved_by)
VALUES (3,'Holiday','Approved','Holiday Request for christmas',6,1);

INSERT INTO PenaltiesBonuses(ID,Type_,Percentage_Change,EmployeeID, Given_By)
VALUES(1,'Late', 2.5, 4, 1);

INSERT INTO PenaltiesBonuses(ID,Type_,Percentage_Change,EmployeeID, Given_By)
VALUES(2,'Absence', 5, 5, 1);

INSERT INTO PenaltiesBonuses(ID,Type_,Percentage_Change,EmployeeID, Given_By)
VALUES(3,'Late', 2.5,6,1);

INSERT INTO CurrentUser VALUES (1);


--- TESTS ---

--UPDATE CurrentUser set ID = 2

select * from CurrentUser

SELECT * FROM [dbo].[PERSONAL]

SELECT DEP_Name, D.Age, Education , P.FName, P.EMAIL  FROM [dbo].[DEPENDENCIES] AS D , [dbo].[PERSONAL] AS P WHERE D.Person_id = P.id; 

SELECT * FROM [dbo].[PERSONAL]

select* from Training

select * from Training_Manager

select * from Personal where ID=3;

select * from Training_Date
select Training_Time, (CONVERT(date, Training_StartDate)), (CONVERT(date, Training_EndDate)) from Training_Date
SELECT CONVERT(date, Training_StartDate) from Training_Date

select FName,LName from Personal as P join Attend_Training as A on P.id=A.E_ID where A.TrainingID=123

select * from Attend_Training inner join Training on ID = TrainingID
where E_ID = 5 And Training_Status = 1

select ID, Training_Name, Training_Location, Training_Description from Training except (select ID, Training_Name, Training_Location, Training_Description from Attend_Training inner join Training on ID = TrainingID
where E_ID = 5)

select ID, PName, Status_ from Project inner join Works_On on ID = PID where EID = 5

select concat(FName, ' ', LName) as fullname from Works_On inner join Personal on id = EID where PID = 1

--update Training set Training_Status = 0 where ID = 123
select * from Project where Status_ != 'Complete'

--update Project set Status_ = 'Half-Way' where ID = 1

