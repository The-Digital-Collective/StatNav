CREATE TABLE [dbo].[ExperimentIteration] (
    [Id]                              INT            IDENTITY (1, 1) NOT NULL,
    [ExperimentProgrammeId]           INT            NOT NULL,
    [RequiredDurationForSignificance] NVARCHAR (MAX) NULL,
    [IterationNumber]                 INT            NOT NULL,
    [StartDateTime]                   DATETIME       NOT NULL,
    [EndDateTime]                     DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.ExperimentIteration] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentIteration_dbo.ExperimentProgramme_ExperimentProgrammeId] FOREIGN KEY ([ExperimentProgrammeId]) REFERENCES [dbo].[ExperimentProgramme] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentProgrammeId]
    ON [dbo].[ExperimentIteration]([ExperimentProgrammeId] ASC);

