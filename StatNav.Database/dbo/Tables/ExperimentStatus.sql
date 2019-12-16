CREATE TABLE [dbo].[ExperimentStatus] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [StatusName]   NVARCHAR (MAX) NULL,
    [DisplayOrder] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ExperimentStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

