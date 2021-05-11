CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(10) NULL, 
    [LastName] NVARCHAR(10) NULL, 
    [Adress] NVARCHAR(50) NULL, 
    [CNP] INT NULL, 
    [Bday] DATETIME NULL ,
    [Id_batch] NVARCHAR(2) NULL, 
    [Id_number] INT NULL, 
    [E-mail] NVARCHAR(10) NULL, 
    [Phone_number] INT NULL, 
    [Salary] MONEY NULL, 
    [Gender] NVARCHAR(10) NULL, 
    [CivilStatus] NVARCHAR(50) NULL, 
    [Nationality] NVARCHAR(50) NULL, 
    [Languages] NVARCHAR(50) NULL ,
    [Position] NVARCHAR(50) NULL ,
    [EmploymentDate] DATETIME NULL, 
    [Schedule] NVARCHAR(50) NULL, 
    [Man_Id] INT NULL, 
    [Dep_Id] INT NULL, 
    [Hol_id] INT NULL
)
