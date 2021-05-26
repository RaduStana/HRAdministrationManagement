CREATE TABLE [dbo].[Dependent] (
    [UserID]       INT           NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [PhoneNumber]  NVARCHAR (50) NULL,
    [Relationship] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Dependent_User] FOREIGN KEY ([UserID]) REFERENCES [User]([UserID])
);

