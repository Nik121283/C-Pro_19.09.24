if DB_ID('Hospital') is null Create Database Hospital;
USE Hospital;

Create table Buildings
(
	Id int primary key identity (1, 1) check (Id>0 and Id<6),
	BuildingsName varchar(10) unique not null 
);

INSERT INTO Buildings (BuildingsName) 
VALUES 
('Building 1'),
('Building 2'),
('Building 3'),
('Building 4'),
('Building 5');

Create table Departments
(
	Id int primary key identity,
	BuildingId int,
	Financing money not null default 0 check(Financing >=0),
	DepartmentName nvarchar(100) not null unique,

	Constraint FK_Departments_To_Buildings Foreign key (BuildingId) references Buildings (Id),
);

INSERT INTO Departments (BuildingId, Financing, DepartmentName) 
VALUES 
(1, 100000, 'Cardiology'),
(2, 150000, 'Neurology'),
(3, 200000, 'Pediatrics'),
(4, 120000, 'Orthopedics'),
(5, 180000, 'Oncology'),
(3, 25000, 'Endocrinology'),
(2, 20000, 'Geriatrics'),
(4, 15000, 'Palliative Care'),
(2, 20000, 'Geriatrics'),
(3, 15000, 'Palliative Care'),
(5, 25000, 'Dermatology'),
(5, 18000, 'Rheumatology');

Create table Deseases
(
	Id int primary key identity,
	DeseaseName nvarchar(100) not null unique,
	Severity int not null default 1,
);

INSERT INTO Deseases (DeseaseName, Severity) 
VALUES 
('Influenza', 2),
('Diabetes', 3),
('Hypertension', 2),
('Asthma', 3),
('Common Cold', 1);

Create table Doctors 
(
	Id int primary key identity,
	DorctorsName varchar(max) not null,
	DoctorsSurname varchar(max) not null,
	Phone char(10),
	Salary money not null check (Salary >0),

);

INSERT INTO Doctors (DorctorsName, DoctorsSurname, Phone, Salary) 
VALUES 
('John', 'Doe', '1234567890', 50000),
('Alice', 'Smith', '2345678901', 60000),
('Michael', 'Brown', '3456789012', 55000),
('Laura', 'Wilson', '4567890123', 52000),
('James', 'Johnson', '5678901234', 58000),
('Nik', 'Novikov', '1224567890', 50000),
('Alice', 'Nilsbrov', '5545678901', 60000);

Create table Examinations
(
	Id int primary key identity,
    DayOfTheWeek int check (DayOfTheWeek between 1 and 7),
    StartTime DateTime not null check (DATEPART(HOUR, StartTime) >= 8 AND DATEPART(HOUR, StartTime) < 18),
    EndTime DateTime not null,
    ExaminationsName varchar(100) not null unique
);

Go
CREATE TRIGGER trg_Examinations_EndTime
ON Examinations
FOR INSERT, UPDATE
AS
BEGIN
    -- Проверяем, что EndTime всегда больше StartTime
    IF EXISTS (SELECT 1 FROM inserted i WHERE i.EndTime <= i.StartTime)
    BEGIN
        RAISERROR ('EndTime must be greater than StartTime.', 16, 1);
        ROLLBACK TRANSACTION; -- Отменить транзакцию
    END
END;
Go

INSERT INTO Examinations (DayOfTheWeek, StartTime, EndTime, ExaminationsName) 
VALUES 
(1, '2024-11-25 08:00:00', '2024-11-25 09:00:00', 'Blood Test'),
(2, '2024-11-26 09:00:00', '2024-11-26 10:00:00', 'MRI Scan'),
(3, '2024-11-27 10:00:00', '2024-11-27 11:00:00', 'CT Scan'),
(4, '2024-11-28 11:00:00', '2024-11-28 12:00:00', 'X-Ray'),
(5, '2024-11-29 12:00:00', '2024-11-29 13:00:00', 'Ultrasound'),
(1, '2024-11-25 12:00:00', '2024-11-25 13:00:00', 'Blood Test2'),
(2, '2024-11-26 12:00:00', '2024-11-26 12:30:00', 'MRI Scan2');

Create table Wards
(
	Id int primary key identity,
	BuildingsId int not null,
	WardsFloor int not null check(WardsFloor >0),
	WardsName nvarchar(20) not null unique,

	Constraint FK_Wards_To_Buildings foreign key (BuildingsId) references Buildings(Id)
);

INSERT INTO Wards (BuildingsId, WardsFloor, WardsName) 
VALUES 
(1, 1, 'Ward A1'),
(2, 2, 'Ward B1'),
(3, 1, 'Ward C1'),
(4, 3, 'Ward D1'),
(5, 1, 'Ward E1');

--1. Вивести вміст таблиці палат.
Select * from wards;

--2. Вивести прізвища та телефони усіх лікарів.
Select DorctorsName, DoctorsSurname, Phone from Doctors;

--3. Вивести усі поверхи без повторень, де розміщуються палати.
Select distinct WardsFloor from Wards;

--4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
Select DeseaseName as Name_of_Disease, Severity as Severity_of_Disease from Deseases;

--5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.

--6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
Select DepartmentName
From Departments
where BuildingId = 5 and Financing < 30000;

--7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
Select DepartmentName
From Departments
where BuildingId = 3 and Financing between 12000 and 15000;

--8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
Select WardsName
from Wards
Where (BuildingsId = 4 or BuildingsId = 5) and WardsFloor = 1;

--9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
Select WardsName, BuildingsName, DepartmentName, Financing
from Wards
Left join Buildings on Buildings.Id = Wards.BuildingsId
Left join Departments on Buildings.Id = Departments.BuildingId
where (Buildings.Id =3 or Buildings.Id = 6) and (Departments.Financing < 11000 or Departments.Financing > 25000)

--10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
--Doctors (DorctorsName, DoctorsSurname, Phone, Salary)
Select DoctorsSurname from Doctors where Salary > 1500;

--11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.

--12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
Select distinct ExaminationsName from Examinations
where DayOfTheWeek < 4 and (DATEPART(HOUR, StartTime) >= 12 AND DATEPART(HOUR, EndTime) < 15);

--13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
Select Buildings.Id, Buildings.BuildingsName, Departments.DepartmentName
From Buildings
Left join Departments on Departments.BuildingId = Buildings.Id
where Buildings.Id in (1, 3, 8, 10);

--14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
Select DeseaseName
From Deseases
Where Severity not in (1, 2);

--15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
--Departments (BuildingId, Financing, DepartmentName)
Select DepartmentName
from Departments
where BuildingId not in (1, 3);

--16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
Select DepartmentName
from Departments
where BuildingId = 1 or BuildingId = 3;


--17. Вивести прізвища лікарів, що починаються з літери «N».
--Doctors (DorctorsName, DoctorsSurname, Phone, Salary) 
Select DorctorsName, DoctorsSurname
From Doctors
Where DoctorsSurname like 'N%';