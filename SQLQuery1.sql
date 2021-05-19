CREATE DATABASE StudentDB
GO

USE StudentDB
GO

CREATE TABLE Students
(
	ID INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Gender NVARCHAR(15) NOT NULL,
	Address NVARCHAR(200) NOT NULL
)
GO

INSERT INTO Students VALUES('Jerome','Smith','Male','13')
INSERT INTO Students VALUES('Peter','Cruise','Male','12')
INSERT INTO Students VALUES('Sam','Allen','Male','13')
INSERT INTO Students VALUES('Leo','Son','Male','12')
INSERT INTO Students VALUES('Mary','Williams','Female','12')
GO