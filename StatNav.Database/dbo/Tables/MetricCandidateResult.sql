CREATE TABLE [dbo].[MetricCandidateResult] (
    [Id]                    INT  IDENTITY (1, 1) NOT NULL,
    [MetricId]              INT  NOT NULL,
    [ExperimentCandidateId] INT  NOT NULL,
    [Value]                 REAL NOT NULL,
    [SampleSize]            REAL NOT NULL,
    CONSTRAINT [PK_dbo.MetricCandidateResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MetricCandidateResult_dbo.ExperimentCandidate_ExperimentCandidateId] FOREIGN KEY ([ExperimentCandidateId]) REFERENCES [dbo].[ExperimentCandidate] ([Id]),
    CONSTRAINT [FK_dbo.MetricCandidateResult_dbo.MetricModel_MetricId] FOREIGN KEY ([MetricId]) REFERENCES [dbo].[MetricModel] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MetricId]
    ON [dbo].[MetricCandidateResult]([MetricId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentCandidateId]
    ON [dbo].[MetricCandidateResult]([ExperimentCandidateId] ASC);

