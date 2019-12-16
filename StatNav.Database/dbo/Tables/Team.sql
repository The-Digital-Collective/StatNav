CREATE TABLE [dbo].[Team] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [OrganisationId] INT            NOT NULL,
    [TeamName]       NVARCHAR (MAX) NULL,
    [Shared]         BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Team] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Team_dbo.Organisation_OrganisationId] FOREIGN KEY ([OrganisationId]) REFERENCES [dbo].[Organisation] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OrganisationId]
    ON [dbo].[Team]([OrganisationId] ASC);

