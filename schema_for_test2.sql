USE MyClassTests
GO
CREATE SCHEMA tests
GO

CREATE TABLE tests.FileProcessTest
(
	FileName varchar(255) NULL,
	ExpectedValue [bit] NOT NULL,
	CausesException [bit] NOT NULL
)
GO

-- true cause no exception
insert into tests.FileProcessTest
VALUES('C:\Windows\Regedit.exe',1,0);

-- true because we dont expecting anythnig
insert into tests.FileProcessTest
VALUES('C:\notexists',0,0);

-- false cause error
insert into tests.FileProcessTest
VALUES(null,0,1);
