CREATE TABLE [dbo].[Holiday]
(
	[HolidayId] INT NOT NULL PRIMARY KEY, 
    [DateOfStart] DATETIME NULL, 
    [DateOfFinish] DATETIME NULL, 
    [Type] NVARCHAR(50) NULL, 
    [Reason] NVARCHAR(50) NULL, 
    [User_Id] INT NULL
)
