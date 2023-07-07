USE CourseReport;
GO

CREATE VIEW [dbo].[EnrollmentReport] AS
	SELECT
		t1.EnrollmentId,
		t2.FirstName,
		t2.LastName,
		t3.CourseCode,
		t3.[Description]
	FROM 
		[dbo].[Enrollments] t1
	INNER JOIN
		[dbo].[Student] t2 ON t1.StudentId = t2.StudentId
	INNER JOIN
		[dbo].[Course] t3 ON t1.CourseId = t3.CourseId
GO

CREATE PROCEDURE [dbo].[EnrollmentReport_GetList] AS
	SELECT
		EnrollmentId,
		FirstName,
		LastName,
		CourseCode,
		[Description]
	FROM [dbo].[EnrollmentReport]
GO


	 