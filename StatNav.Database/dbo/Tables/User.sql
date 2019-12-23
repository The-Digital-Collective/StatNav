CREATE TABLE [dbo].[User] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [TeamId]   INT            NOT NULL,
    [RoleId]   INT            NOT NULL,
    [Username] NVARCHAR (MAX) NULL,
    [Shared]   BIT            NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.User_dbo.Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]),
    CONSTRAINT [FK_dbo.User_dbo.UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[UserRole] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TeamId]
    ON [dbo].[User]([TeamId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[User]([RoleId] ASC);

