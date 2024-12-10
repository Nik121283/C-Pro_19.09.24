Create database BarberShop;

Use BarberShop

Create table Gender
(
	Id int primary key identity,
	GenderName nvarchar(10)
);

INSERT INTO Gender (GenderName)
VALUES
('Male'),
('Female');


Create table Position
(
	Id int primary key identity,
	PositionName nvarchar(50)
);

INSERT INTO Position (PositionName)
VALUES
('Manager'),
('Junior'),
('Senior');

--Update Position
--Set PositionName = 'Senior'
--where id = 3

Create table ServicesOfBarbers
(
	Id int primary key identity,
	ServiceName nvarchar(50) not null,
	Price Money not null check (Price <10000),
	Duration Time(0) not null,
);

INSERT INTO ServicesOfBarbers (ServiceName, Price, Duration)
VALUES
('Haircut', 200, '00:30:00'),          -- �������
('Shave', 100, '00:15:00'),            -- ������
('Haircut and Shave', 250, '00:45:00'),-- ������� � ������
('Beard Trim', 150, '00:20:00'),       -- ������� ������
('Hair Coloring', 300, '01:00:00'),    -- ����������� �����
('Hair Treatment', 350, '00:45:00'),   -- ������� �����
('Facial Treatment', 200, '00:40:00'); -- ���� �� ����� ����

Create table Barbers
(
	Id int primary key identity,
	BarbersName nvarchar(50) not null,
	BarbersSurname nvarchar(50) not null,
	GenderId int not null,

	--format (067) 123-45-67
	PhoneNumber nvarchar(30) not null Check (PhoneNumber LIKE '(%[0-9][0-9][0-9]%) %[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),

	--'_%@_%._%' ���� �� 1 ������ ����� @, ����� @ � ����� "."
	--CHARINDEX(' ', Email) = 0 �������� �� ���������� ��������
	Email nvarchar(50) not null Check  (Email LIKE '_%@_%._%' AND CHARINDEX(' ', Email) = 0),

	DateOfBirth Date not null,
	HireDate Date not null,

	PositionId int not null,

	BarbersRating int,

	Constraint FK_Barbers_to_Gender foreign key (GenderId) references Gender(Id),
	Constraint FK_Barbers_to_Positions foreign key (PositionId) references Position(Id)
);

INSERT INTO Barbers (BarbersName, BarbersSurname, GenderId, PhoneNumber, Email, DateOfBirth, HireDate, PositionId, BarbersRating)
VALUES
('John', 'Doe', 1, '(067) 123-45-67', 'john.doe@email.com', '1990-05-15', '2023-01-10', 1, NULL),  -- ������ 1
('Jane', 'Smith', 2, '(067) 234-56-78', 'jane.smith@email.com', '1985-03-25', '2023-03-20', 2, NULL), -- ������ 2
('Mike', 'Johnson', 1, '(067) 345-67-89', 'mike.johnson@email.com', '1992-07-30', '2023-06-01', 3, NULL), -- ������ 3
('Emily', 'Taylor', 2, '(067) 456-78-90', 'emily.taylor@email.com', '1988-09-10', '2023-02-14', 1, NULL), -- ������ 4
('Chris', 'Wilson', 1, '(067) 567-89-01', 'chris.wilson@email.com', '1995-12-01', '2023-05-05', 2, NULL), -- ������ 5
('Sarah', 'Brown', 2, '(067) 678-90-12', 'sarah.brown@email.com', '1982-10-22', '2023-04-15', 3, NULL); -- ������ 6

Create table Many_to_Many_Barbers_Services
(	
	BarbersId int not null,
	ServicesOfBarbersId int not null,

	Primary key (BarbersId, ServicesOfBarbersId),

	Constraint FK_ManyToMany_Barbers_Services_to_Barbers foreign key (BarbersId) references Barbers(Id),
	Constraint FK_ManyToMany_Barbers_Services_to_ServicesOfBarbers foreign key (ServicesOfBarbersId) references ServicesOfBarbers(Id),
);

INSERT INTO Many_to_Many_Barbers_Services (BarbersId, ServicesOfBarbersId)
VALUES
-- John Doe (BarbersId = 1) �� ��������� ������ 1
(1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7),

-- Jane Smith (BarbersId = 2) �� ��������� ������ 2
(2, 1), (2, 3), (2, 4), (2, 5), (2, 6), (2, 7),

-- Mike Johnson (BarbersId = 3) �� ��������� ������ 3
(3, 1), (3, 2), (3, 4), (3, 5), (3, 6), (3, 7),

-- Emily Taylor (BarbersId = 4) �� ��������� ������ 4
(4, 1), (4, 2), (4, 3), (4, 5), (4, 6), (4, 7),

-- Chris Wilson (BarbersId = 5) �� ��������� ������ 5
(5, 1), (5, 2), (5, 3), (5, 4), (5, 6), (5, 7),

-- Sarah Brown (BarbersId = 6) �� ��������� ������ 6
(6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 7);

Create table Customer
(
	Id int primary key identity,
	CustomersName nvarchar(50) not null,
	CustomersSurname nvarchar(50) not null,

	--format (067) 123-45-67
	PhoneNumber nvarchar(15) not null Check (PhoneNumber LIKE '(%[0-9][0-9][0-9]%) %[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
);

INSERT INTO Customer (CustomersName, CustomersSurname, PhoneNumber)
VALUES
('Alice', 'Johnson', '(067) 123-45-67'),
('Bob', 'Smith', '(067) 234-56-78'),
('Charlie', 'Brown', '(067) 345-67-89'),
('Diana', 'Jones', '(067) 456-78-90'),
('Eve', 'Taylor', '(067) 567-89-01'),
('Frank', 'Miller', '(067) 678-90-12'),
('Grace', 'Williams', '(067) 789-01-23'),
('Henry', 'Davis', '(067) 890-12-34'),
('Ivy', 'Wilson', '(067) 901-23-45'),
('Jack', 'Moore', '(067) 012-34-56'),
('Kate', 'Anderson', '(067) 123-45-67'),
('Leo', 'Thomas', '(067) 234-56-78'),
('Mia', 'Harris', '(067) 345-67-89'),
('Noah', 'Martin', '(067) 456-78-90'),
('Olivia', 'Garcia', '(067) 567-89-01');

Create table BarberAppointments
(
	Id int primary key identity,

	BarbersId int not null,
	CustomerId int not null,
	ServicesOfBarbersId int not null, 

	StartTime DATETIME NOT NULL,

	Constraint FK_BarberAppointments_to_Customer foreign key (CustomerId) references Customer(Id),
	Constraint FK_BarberAppointments_to_Barbers foreign key (BarbersId) references Barbers(Id),
	Constraint FK_BarbersWorkingTime_to_Services foreign key (ServicesOfBarbersId) references ServicesOfBarbers(Id)
);

Create table BarbersWorkingTime
(
	Id int primary key identity,

	BarberId int not null,
	StartOfWork DateTime not null,
	EndOfWork DateTime not null,
	Constraint FK_BarbersWorkingTime_to_Barbers foreign key (BarberId) references Barbers(Id)
);

INSERT INTO BarbersWorkingTime (BarberId, StartOfWork, EndOfWork)
VALUES
(1, '2024-12-02 09:00:00', '2024-12-02 18:00:00'),  -- �����������
(1, '2024-12-04 09:00:00', '2024-12-04 18:00:00'),  -- �����
(2, '2024-12-03 10:00:00', '2024-12-03 19:00:00'),  -- �������
(2, '2024-12-05 10:00:00', '2024-12-05 19:00:00'),  -- �������
(3, '2024-12-02 08:00:00', '2024-12-02 17:00:00'),  -- �����������
(3, '2024-12-06 08:00:00', '2024-12-06 17:00:00'),  -- �������
(4, '2024-12-03 09:30:00', '2024-12-03 18:30:00'),  -- �������
(4, '2024-12-07 09:30:00', '2024-12-07 18:30:00'),  -- �������
(5, '2024-12-02 08:00:00', '2024-12-02 17:00:00'),  -- �����������
(5, '2024-12-04 08:00:00', '2024-12-04 17:00:00'),  -- �����
(6, '2024-12-03 10:00:00', '2024-12-03 19:00:00'),  -- �������
(6, '2024-12-05 10:00:00', '2024-12-05 19:00:00');  -- �������

--������ �������� ������� ����� ����� ��� � ������������� � ����� ������� + �������� �� ������ �� ����� ������������ + �� ������ �� ��� ��� �����
go
CREATE TRIGGER BarbersWorkingTimeAndServiceCheck
ON BarberAppointments
INSTEAD OF INSERT
AS
BEGIN
    -- �������� ������� �������� ������� �������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN BarbersWorkingTime bwt
          ON i.BarbersId = bwt.BarberId
         AND CAST(i.StartTime AS DATE) BETWEEN CAST(bwt.StartOfWork AS DATE) AND CAST(bwt.EndOfWork AS DATE) -- ���� ������ � �������� ������� ����
         AND CAST(i.StartTime AS TIME) >= CAST(bwt.StartOfWork AS TIME) -- ����� ����� ��� ����� ������ �������� �������
         AND CAST(i.StartTime AS TIME) < CAST(bwt.EndOfWork AS TIME) -- ����� ������ ����� �������� �������
    )
    BEGIN
        -- �������� ��������������� ������
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN Many_to_Many_Barbers_Services m2m
              ON i.BarbersId = m2m.BarbersId
             AND i.ServicesOfBarbersId = m2m.ServicesOfBarbersId
        )
        BEGIN
            -- ��������, ��� �� ��� ������ �� ��� ����� � ������� �������
            IF NOT EXISTS (
                SELECT 1
                FROM inserted i
                JOIN BarberAppointments ba
                  ON i.BarbersId = ba.BarbersId
                 AND i.StartTime = ba.StartTime
            )
            BEGIN
                -- ������� ������, ���� ��� �������� ��������
                INSERT INTO BarberAppointments (BarbersId, CustomerId, ServicesOfBarbersId, StartTime)
                SELECT BarbersId, CustomerId, ServicesOfBarbersId, StartTime
                FROM inserted;
            END
            ELSE
            BEGIN
                -- ������: ����� ������
                RAISERROR('������ ��� ����� �� ��������� �����.', 16, 1);
                ROLLBACK TRANSACTION;
            END;
        END
        ELSE
        BEGIN
            -- ������: ������ �� ������������� ������
            RAISERROR('������ �� ������������� ��� ������.', 16, 1);
            ROLLBACK TRANSACTION;
        END;
    END
    ELSE
    BEGIN
        -- ������: ������ �� ����� �� ������������� �������� �������
        RAISERROR('������ �� ����� �� ������������� �������� ������� �������.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

Create table Feedback
(
	Id int primary key identity,
	BarberAppointmentsId int not null,
	Feedback nvarchar(max),
	FeedbackMark int check(FeedbackMark between 1 and 5),
	
	Constraint FK_Feedback_to_BarberAppointments foreign key (BarberAppointmentsId) references BarberAppointments(Id)
);

--���������� ������ � ���� ������ ������ � Feedback(�) �������� ������������� �� ������ BarberAppointment
go
Create procedure LeftFeedback
@feedbackId int, @feedbackMark int, @feedBackText nvarchar(max)
as
Begin
	Update Feedback
	Set Feedback.Feedback = @feedBackText, Feedback.FeedbackMark = @feedbackMark
	where Feedback.Id = @feedbackId
End;
go


--������� ����� ���� ������� ��� ��������� ������������
go
Create trigger FeedbackOnEveryAppointment on BarberAppointments
After insert
as
Begin
insert into Feedback (BarberAppointmentsId)
Select Id from inserted
End;
go


--������� ����� �������� ������ �� BarberAppointments, ServicesOfBarbers, Feedback
Create table Visits_archive
(
	Id int primary key identity,
	BarberId int not null,
	CustomerId int not null,
	ServicesOfBarbersId int not null,
	StartTime DATETIME NOT NULL,
	EndTime DATETIME NOT NULL,
	Price money not null,
	FeedbackId int not null

	Constraint FK_Visits_archive_to_Barbers foreign key (BarberId) references Barbers(Id),
	Constraint FK_Visits_archive_to_Customer foreign key (CustomerId) references Customer(Id),
	Constraint FK_Visits_archive_to_ServicesOfBarbersId foreign key (ServicesOfBarbersId) references ServicesOfBarbers(Id),
	Constraint FK_Visits_archive_to_Feedback foreign key (FeedbackId) references Feedback(Id)
);


--������� ����� ���� �������� ��� ��������� ������������
go
Create trigger ArchiveEveryAppointment on BarberAppointments
After insert
as
Begin
insert into Visits_archive (BarberId, CustomerId, ServicesOfBarbersId, StartTime, EndTime, Price, FeedbackId)
Select
        i.BarbersId, -- ID �������
        i.CustomerId, -- ID �������
        i.ServicesOfBarbersId, -- ID ������
        i.StartTime, -- ����� ������
        DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00:00', s.Duration), i.StartTime) AS EndTime, -- ����� ��������� ������
        s.Price, -- ���� ������
        f.Id AS FeedbackId -- ID ������
    FROM 
        inserted i
	Left join Many_to_Many_Barbers_Services on Many_to_Many_Barbers_Services.BarbersId = i.BarbersId
    Left join ServicesOfBarbers s ON s.Id = Many_to_Many_Barbers_Services.ServicesOfBarbersId -- ����� � �������
    LEFT JOIN 
        Feedback f ON f.BarberAppointmentsId = i.Id; -- ����� � �������
End;
go

CREATE TRIGGER AverageMarkOfBarbers
ON Feedback
AFTER INSERT, UPDATE
AS
BEGIN
    -- ��������� ������� �������, ������������ ������� ������
    UPDATE Barbers
    SET Barbers.BarbersRating = subquery.AverageMark
    FROM Barbers
    INNER JOIN (
        SELECT ba.BarbersId, AVG(f.FeedbackMark) AS AverageMark
        FROM Feedback f
        INNER JOIN BarberAppointments ba ON f.BarberAppointmentsId = ba.Id
        WHERE f.FeedbackMark IS NOT NULL
        GROUP BY ba.BarbersId
    ) AS subquery ON Barbers.Id = subquery.BarbersId
    WHERE Barbers.Id IN (
        SELECT ba.BarbersId
        FROM inserted i
        INNER JOIN BarberAppointments ba ON i.BarberAppointmentsId = ba.Id
    );
END;
GO



INSERT INTO BarberAppointments (BarbersId, CustomerId, ServicesOfBarbersId, StartTime)
VALUES
-- ������ 1 (John Doe) �������� � ����������� � �����
(1, 1, 2, '2024-12-02 09:00:00'),  -- Alice Johnson, ������� �����
(1, 2, 3, '2024-12-02 10:30:00'),  -- Bob Smith, ������
(1, 3, 4, '2024-12-02 13:00:00'),  -- Charlie Brown, �������
(1, 4, 5, '2024-12-04 09:00:00'),  -- Diana Jones, �������
(1, 5, 6, '2024-12-04 14:00:00'),  -- Eve Taylor, ������ ������

-- ������ 2 (Jane Smith) �������� �� ������� � �������
(2, 6, 1, '2024-12-03 10:00:00'),  -- Frank Miller, �������
(2, 7, 3, '2024-12-03 11:30:00'),  -- Grace Williams, ������
(2, 8, 4, '2024-12-05 11:00:00'),  -- Henry Davis, �������
(2, 9, 5, '2024-12-05 15:00:00'),  -- Ivy Wilson, �������
(2, 10, 6, '2024-12-05 17:30:00'),  -- Jack Moore, ������ ������

-- ������ 3 (Mike Johnson) �������� � ����������� � �������
(3, 11, 1, '2024-12-02 08:00:00'),  -- Kate Anderson, �������
(3, 12, 2, '2024-12-02 09:30:00'),  -- Leo Thomas, ������� �����
(3, 13, 4, '2024-12-06 10:00:00'),  -- Mia Harris, �������
(3, 14, 5, '2024-12-06 12:30:00'),  -- Noah Martin, �������
(3, 15, 6, '2024-12-06 14:00:00'),  -- Olivia Garcia, ������ ������

-- ������ 4 (Emily Taylor) �������� �� ������� � �������
(4, 1, 1, '2024-12-03 09:30:00'),  -- Alice Johnson, �������
(4, 2, 2, '2024-12-03 11:00:00'),  -- Bob Smith, ������� �����
(4, 3, 3, '2024-12-07 10:00:00'),  -- Charlie Brown, ������
(4, 4, 5, '2024-12-07 14:30:00'),  -- Diana Jones, �������
(4, 5, 6, '2024-12-07 16:00:00'),  -- Eve Taylor, ������ ������

-- ������ 5 (Chris Wilson) �������� � ����������� � �����
(5, 6, 1, '2024-12-02 08:00:00'),  -- Frank Miller, �������
(5, 7, 2, '2024-12-02 10:30:00'),  -- Grace Williams, ������� �����
(5, 8, 3, '2024-12-04 11:00:00'),  -- Henry Davis, ������
(5, 9, 4, '2024-12-04 13:30:00'),  -- Ivy Wilson, �������
(5, 10, 5, '2024-12-04 16:00:00');  -- Jack Moore, ������ ������


-- ������ 1 (John Doe) �������� � ����������� � �����
EXEC LeftFeedback 1, 5, '����� �������� �������� �����. ������ ��� ����������.';  -- Alice Johnson
EXEC LeftFeedback 2, 4, '������� ������, �� ������� ��� ������� ������.';        -- Bob Smith
EXEC LeftFeedback 3, 3, '������� ��� ����������, �� ����� �������� ��������.';   -- Charlie Brown
EXEC LeftFeedback 4, 5, '����� ���������� �������, ������ ��� ��������������.';  -- Diana Jones
EXEC LeftFeedback 5, 4, '������ ������ ��� �����, �� ������� ������� � ������.'; -- Eve Taylor

-- ������ 2 (Jane Smith) �������� �� ������� � �������
EXEC LeftFeedback 6, 5, '�������� �������, �������� ���� ����������!';            -- Frank Miller
EXEC LeftFeedback 7, 3, '������ �������, �� ������� ������ � ��������� ������.';  -- Grace Williams
EXEC LeftFeedback 8, 5, '������� ��� ���������, ��� ������� �� ������ ������.';    -- Henry Davis
EXEC LeftFeedback 9, 4, '������� �������, �� ����� �������� ����� ����� �������.'; -- Ivy Wilson
EXEC LeftFeedback 10, 5, '������ ������ ��� �������������, ������ ����� ����������.'; -- Jack Moore

-- ������ 3 (Mike Johnson) �������� � ����������� � �������
EXEC LeftFeedback 11, 5, '������� ���� �������������, ������ ���� ��� ���������.'; -- Kate Anderson
EXEC LeftFeedback 12, 4, '������� ����� ���� �������, �� ������� �� ���, ��� �������.'; -- Leo Thomas
EXEC LeftFeedback 13, 5, '������� ��� ��������, ���� �������������.'; -- Mia Harris
EXEC LeftFeedback 14, 3, '������� ��� ����������, �� ������������ ���������� ������������.'; -- Noah Martin
EXEC LeftFeedback 15, 4, '������ ������ �������, �� ������ ��� ������� ���������.'; -- Olivia Garcia

-- ������ 4 (Emily Taylor) �������� �� ������� � �������
EXEC LeftFeedback 16, 4, '������� ���� ����������, �� �� ���, ��� � ���� ������������.'; -- Alice Johnson
EXEC LeftFeedback 17, 5, '����� ����������� ������� �����, ������ �����������.'; -- Bob Smith
EXEC LeftFeedback 18, 3, '������ ���� ����������, �� � ������� �������� ��������.'; -- Charlie Brown
EXEC LeftFeedback 19, 5, '������� ��� ������������, ���� ��������� ���� �������.'; -- Diana Jones
EXEC LeftFeedback 20, 5, '������ ������ ��� �������������, ������ ����� ��������������.'; -- Eve Taylor

-- ������ 5 (Chris Wilson) �������� � ����������� � �����
EXEC LeftFeedback 21, 4, '������� ���� �������, �� ���� ������� �����������.'; -- Frank Miller
EXEC LeftFeedback 22, 5, '������� ����� ���� ���������, ������ �������� ������������.'; -- Grace Williams
EXEC LeftFeedback 23, 3, '������ ����������, �� �� ��� ����� ���� ��������� �������.'; -- Henry Davis
EXEC LeftFeedback 24, 5, '������� ��� �� ������, ������ ����� ���� ������.'; -- Ivy Wilson
EXEC LeftFeedback 25, 4, '������ ������ ��� �������, �� �������� �� ������� ������ ������������.'; -- Jack Moore


--��������� ϲ� ��� ������� ������.
go
Create procedure GetAllBarbers as
Begin
	Select BarbersName, BarbersSurname
	From Barbers
End
go

--��������� ���������� ��� ��� �������-�������.
go
Create procedure GetAllSeniorBarbers as
Begin
	Select Barbers.BarbersName, Barbers.BarbersSurname
	From Barbers
	Left join Position on Position.Id = Barbers.PositionId
	Where Position.PositionName = 'Senior'
End
go

--��������� ���������� ��� ��� �������, �� ������ ������ ������� ������������ ������ ������.
go
Create procedure GetAllBarbersWhoCanBlade as
Begin
	Select BarbersName, BarbersSurname
	From Barbers
	Left join Many_to_Many_Barbers_Services on Many_to_Many_Barbers_Services.BarbersId = Barbers.Id
	Left join ServicesOfBarbers on ServicesOfBarbers.Id = Many_to_Many_Barbers_Services.ServicesOfBarbersId
	Where ServicesOfBarbers.ServiceName = 'Shave'
End
go



--��������� ������� �������-������� �� ������� ������-�������.
go
Create procedure GetAllSeniorAndJuniorBarbers as
Begin
	Select Barbers.BarbersName, Barbers.BarbersSurname
	From Barbers
	Left join Position on Position.Id = Barbers.PositionId
	Where Position.PositionName = 'Senior' or Position.PositionName = 'Junior'
End
go

exec GetAllSeniorAndJuniorBarbers;


--��������� ���������� ��� ��� �������, �� ������ ������ ��������� �������. 
--���������� ��� ������� ������� �������� �� ��������.
Create procedure
GetBarbersWhoCanDoSomeService
@ServicesOfBarbersId int
as
Begin
	Select * from Barbers
	Left join Many_to_Many_Barbers_Services on Many_to_Many_Barbers_Services.BarbersId = Barbers.Id
	where Many_to_Many_Barbers_Services.ServicesOfBarbersId = @ServicesOfBarbersId;
End;

Exec GetBarbersWhoCanDoSomeService @ServicesOfBarbersId = 2;

--��������� ���������� ��� �������� �볺���. ������� ��������� �볺���: 
	--��� � ����� ������ ������� ����. ʳ������ ���������� �� ��������.
	--Customer (CustomersName, CustomersSurname, PhoneNumber)
go
Create procedure
ClientVisitedAmountTimes
@timesOfVisiting int
as
Begin
	Select CustomersName, CustomersSurname, PhoneNumber, COUNT(BarberAppointments.Id) as TimesOfVisits from BarberAppointments
	Left join Customer on Customer.Id = BarberAppointments.CustomerId
	Group by CustomersName, CustomersSurname, PhoneNumber
	Having COUNT(BarberAppointments.Id) >= @timesOfVisiting
END;

Exec ClientVisitedAmountTimes 1;






--Select * from Visits_archive;

--Select * from Customer;

--Select * from Barbers;

--Select * from Position;

--Select * from Feedback;

--Select * from BarberAppointments;

--���������� �������� ������� ������� 21 ����
--Barbers (BarbersName, BarbersSurname, GenderId, PhoneNumber, Email, DateOfBirth, HireDate, PositionId, BarbersRating)

go
Alter table Barbers
Add Constraint BarbersMustBeNotYounger21 Check ((DATEDIFF(YEAR, DateOfBirth, GETDATE())) >= 21);

--�������� ����������� �� �������� � 21 ���
Insert into Barbers (BarbersName, BarbersSurname, GenderId, PhoneNumber, Email, DateOfBirth, HireDate, PositionId, BarbersRating)
values 
('Test', 'Test', 2, '(067) 678-11-12', 'test@email.com', '2005-10-22', '2023-04-15', 3, NULL); -- ������ 7

-- ���������� ��������� ��������� ���������� ��� ���-������, ���� �� ������ ������ ���-������. 
go
Create trigger ControlManagerDelete
on Barbers
Instead of delete
as
Begin
	Declare @BarbersManagersCount int;
	
	Select @BarbersManagersCount=Count(*)
	from Barbers
	where Barbers.PositionId = 1;

	if @BarbersManagersCount <= 1 
	Begin
	    Raiserror('��������� ���������: �� ����� �������� ������� ��� ���-�������.',16,1);
		Rollback transaction;
		return;
    END;

	Delete from Barbers
	Where Id in (Select Id from deleted)
End;
go

-- ������� ����������� ������� ������ � ���� �Hello, ��'�!� 
--�� ��'� ���������� �� ��������. ���������, ���� �������� Nick, �� ���� Hello, Nick! 
Create function Hello_Name(@name nvarchar(100))
Returns nvarchar(200)
as
Begin
	Return Concat('Hello ', @name, ' !');
End;
go

--Drop function Hello_Name;

SELECT *
FROM sys.objects
WHERE type = 'FN' AND name = 'Hello_Name';


Select dbo.Hello_Name('Igor');

--������� ����������� ������� ���������� ��� ������� ������� ������;
go
Create Function MinuteFromSomeDate (@startingDate DateTime)
Returns Int
As
Begin
	Declare @result int;
	Set @result = DATEDIFF(MINUTE, @startingDate, GETDATE());
	Return @result;
End;
go

Select dbo.MinuteFromSomeDate('2024-12-09 12:00:00');

--������� ����������� ������� ���������� ��� �������� ��
go
Create Function CurrentYear()
Returns int
as
Begin
	Declare @result int;
	Set @result = Year(GETDATE());
	return @result;
End;
go

Select dbo.CurrentYear();

--������� ����������� ������� ���������� ��� ��: ������ ��� �������� ��;
go
Create function evenYear()
Returns nvarchar(50)
as
Begin
	Declare @currentYear int;
	Set @currentYear = Year(GETDATE());

	if @currentYear % 2 =0 
		return 'even Year';
	else 
		return 'odd Year';
	
	RETURN ''; 
End;

Select dbo.evenYear();

--������� ����������� ������ ����� � ������� yes, ���� ����� ������ � no, ���� ����� �� ������; 
go
Create function SimpleNumbers(@checkingNumber int)
Returns nvarchar(30)
as
Begin
	IF @checkingNumber <= 1
    RETURN 'Not simple';

	Declare @i int = 2;

	while @i < @checkingNumber
		Begin

			if @checkingNumber % @i= 0
			Return 'Not simple';

			else
			Set @i = @i + 1;
		End;
	Return 'Simple'
End;

go
Select dbo.SimpleNumbers(13);

--������� ����������� ������ �� ��������� �'��� �����. ������� ���� ���������� �� ������������� �������� � ��������� �'��� ���������;
go
Create function SummOfMinAndMax (@number1 int, @number2 int, @number3 int, @number4 int, @number5 int)
Returns int
as
Begin
	declare @min int;
	declare @max int;

	declare @NewTable table (allNumbers int);
	insert into @NewTable(allNumbers)
	VALUES (@number1), (@number2), (@number3), (@number4), (@number5);
	
	SET @min = (SELECT MIN(allNumbers) From @NewTable);
	SET @max = (SELECT MAX(allNumbers) From @NewTable);

	return @min + @max;
End;

Select dbo.SummOfMinAndMax(1,2,3,4,5);

--������� ����������� ������ �� ���� ��� ������ ����� � ���������� �������. 
--������� ������ ��� ���������: ������� ��������, ����� ��������, ����� �� ������� ����������.
Create function OddAndEvenNumbers (@startingNumber int, @endingNumber int)
Returns @result table (id int identity, even int, odd int)
as
Begin
	declare @i int
	set @i = @startingNumber

	while @i < @endingNumber
		begin
			if @i % 2 = 0
			insert into @result (even, odd)
			values (@i, null)

			else
			insert into @result (even, odd)
			values (null, @i)

			set @i = @i + 1;
		end;
	return;
End;

SELECT * FROM dbo.OddAndEvenNumbers(1, 12);

 --��������� ��������� �������� �Hello, world!�;
 go
 Create procedure returnHelloWorld
 as
 Begin
	Print 'Hello world'	
 End;
 go

 exec returnHelloWorld;

--��������� ��������� ������� ���������� ��� �������� ���;
go
Create procedure currentDate
as
Begin
	Print GETDATE();
End;

exec currentDate;

--��������� ��������� ������� ���������� ��� ������� ����; 
go
Create procedure currentDateOnly
as
Begin
	Print Year(GETDATE());
	Print Month(GETDATE());
	Print Day(GETDATE());
End;

exec currentDateOnly;

--��������� ��������� ������ ��� ����� � ������� ���� ����;
go
Create procedure SummOfThreeNumbers  @number1 int, @number2 int, @number3 int
as
Begin
	declare @result int
	set @result = @number1 + @number2 + @number3;
	return @result;
End;


declare @output int;
exec @output = SummOfThreeNumbers 1, 2, 3;
print @output;

--��������� ��������� ������ ��� ����� � ������� ������������������� ����� �����; 
go
Create procedure AvgOfThreeNumbers
@number1 FLOAT, @number2 FLOAT, @number3 FLOAT, @avgResult FLOAT OUTPUT
as
Begin
	declare @result table (numbers FLOAT);

	insert into @result(numbers)
	values(@number1), (@number2), (@number3);

	Select @avgResult = AVG(numbers) from @result;
End;
go

go
declare @output2 float;
exec AvgOfThreeNumbers 1.5, 2.2, 3.3, @output2 output;
print @output2;

--Drop procedure AvgOfThreeNumbers


--��������� ��������� ������ ��� ����� � ������� ����������� ��������; 
go
Create procedure MaxOfThreeNumbers
@number1 FLOAT, @number2 FLOAT, @number3 FLOAT, @avgResult FLOAT OUTPUT
as
Begin
	declare @result table (numbers FLOAT);

	insert into @result(numbers)
	values(@number1), (@number2), (@number3);

	Select @avgResult = Max(numbers) from @result;
End;
go

go
declare @output2 float;
exec MaxOfThreeNumbers 1.5, 2.2, 3.3, @output2 output;
print @output2;

-- ��������� ��������� ������ ��� ����� � ������� �������� ��������; 
go
Create procedure MinOfThreeNumbers
@number1 FLOAT, @number2 FLOAT, @number3 FLOAT, @avgResult FLOAT OUTPUT
as
Begin
	declare @result table (numbers FLOAT);

	insert into @result(numbers)
	values(@number1), (@number2), (@number3);

	Select @avgResult = MIN(numbers) from @result;
End;
go

go
declare @output2 float;
exec MinOfThreeNumbers 1.5, 2.2, 3.3, @output2 output;
print @output2;

--��������� ��������� ������ ����� �� ������.
--� ��������� ������ ��������� ��������� ������������  ��� ��������, �� ������� �����.
--˳�� ���������� �� �������, ��������� � ������� ��������. 
go
Create procedure RepeatChar
@char Char(1), @repeatNumber int
as
Begin
	declare @result nvarchar(max)
	Set @result =  Replicate(@char, @repeatNumber);
	Print @result
End;

go
--Drop procedure RepeatChar

go
exec RepeatChar '_', 10;

--��������� ��������� ������ �� �������� ����� � ������� ���� ��������.
go
Create procedure Factorial
@numberForFactorial int, @result int output
as
Begin
	declare @i int;
	set @i = 1;
	set @result = 1;

	While @i <=@numberForFactorial
		Begin
			set @result = @result * @i;
			set @i = @i + 1;
		End;

	return @result;
End;

declare @out1 int;
exec Factorial 6, @out1 output;
print @out1;

--��������� ��������� ������ ��� ������ ���������. ������ �������� � �� �����
--������ �������� � �� ������. ��������� ������� �����, ������� �� �������. 
--���������, ���� ��������� ��������� 2 � 3, ��� ����������� 2 � �������� ������, ����� 8.
go
Create procedure NumberInStepen
@number int, @stepen int, @result int output
as
Begin
	Select @result = POWER(@number, @stepen);
End;

--Drop procedure NumberInStepen

declare @out3 int;
exec NumberInStepen 6, 2, @out3 output;
print @out3;