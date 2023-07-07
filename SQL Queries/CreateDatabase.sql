CREATE DATABASE CourseReport;
GO

USE CourseReport;

CREATE TABLE [dbo].[Course] (
	CourseId INT IDENTITY(1,1) NOT NULL,
	CourseCode VARCHAR(10) NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
	PRIMARY KEY (CourseId)
);

CREATE TABLE [dbo].[Student] (
	StudentId INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PRIMARY KEY (StudentId)
);

CREATE TABLE [dbo].[Enrollments] (
	EnrollmentId INT IDENTITY(1,1) NOT NULL,
	StudentId INT NOT NULL,
	CourseId INT NOT NULL,
	PRIMARY KEY (EnrollmentId),
	FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
	FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);
GO

INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('AF', 'Accounting and Finance');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('ME', 'Aeronautical and Manufacturing Engineering');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('AF', 'Agriculture and Forestry');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('AS', 'American Studies');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('APSY', 'Anatomy and Physiology');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('ANT', 'Anthropology');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('ARC', 'Archaelogy');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES('ARCH', 'Architecture');

INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Millard', 'Lamb');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Gayle', 'Reid');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Quinton', 'Beltran');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Eusebio', 'Moyer');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Imelda', 'Shea');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES('Ellsworth', 'Fletcher');

INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(1, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(2, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(3, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(1, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(3, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(4, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(5, 3);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES(6, 4);
