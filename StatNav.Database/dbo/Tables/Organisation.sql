CREATE TABLE [dbo].[Organisation] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [OrganisationName] NVARCHAR (MAX) NULL,
    [Shared]           BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Organisation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

