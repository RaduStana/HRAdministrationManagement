CREATE TABLE [dbo].[Project]
(
	[ProjectId] INT NOT NULL PRIMARY KEY, 
    [ProjectName] NCHAR(10) NULL, 
    [Dep_Id] NCHAR(10) NULL, 
    [DeadLine] DATETIME NULL
)
