// make a database name MyClassTest

CREATE SCHEMA tests;
CREATE TABLE tests.FileProcessTest(

	FileName varchar(255) NULL,
	ExpectedValue [bit] NOT NULL,
	CausesException [bit] NOT NULL


)
