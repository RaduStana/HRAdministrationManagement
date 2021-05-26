CREATE TABLE [dbo].[Holiday] (
    [HolidayId]    INT           NOT NULL,
    [DateOfStart]  DATETIME      NULL,
    [DateOfFinish] DATETIME      NULL,
    [Type]         NVARCHAR (50) NULL,
    [Reason]       NVARCHAR (50) NULL,
    [UserId]       INT           NOT NULL,
    CONSTRAINT [FK_Holiday_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [PK_Holiday] PRIMARY KEY ([UserId])
);

