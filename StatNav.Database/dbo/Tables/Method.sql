CREATE TABLE [dbo].[Method] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [SortOrder] INT            NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Method] PRIMARY KEY CLUSTERED ([Id] ASC)
);

