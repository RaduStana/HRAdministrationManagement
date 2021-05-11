CREATE TABLE [dbo].[Department]
(
	[DepId] INT NOT NULL PRIMARY KEY, 
    [DepName] NVARCHAR(50) NULL, 
    [ManId] NVARCHAR(50) NULL, 
    [ManDateStart] DATETIME NULL
)
