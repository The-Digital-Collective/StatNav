CREATE TABLE [dbo].[ExperimentCandidate] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [ExperimentIterationId]        INT            NOT NULL,
    [CandidateName]                NVARCHAR (MAX) NOT NULL,
    [Control]                      BIT            NOT NULL,
    [CandidateTargetMetricModelId] INT            NOT NULL,
    [TargetMet]                    BIT            NOT NULL,
    [CandidateImpactMetricModelId] INT            NOT NULL,
    [ImpactMet]                    BIT            NOT NULL,
    CONSTRAINT [PK_dbo.ExperimentCandidate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentCandidate_dbo.ExperimentIteration_ExperimentIterationId] FOREIGN KEY ([ExperimentIterationId]) REFERENCES [dbo].[ExperimentIteration] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentCandidate_dbo.MetricModel_ImpactMetricModelId] FOREIGN KEY ([CandidateImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentCandidate_dbo.MetricModel_TargetMetricModelId] FOREIGN KEY ([CandidateTargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentIterationId]
    ON [dbo].[ExperimentCandidate]([ExperimentIterationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CandidateTargetMetricModelId]
    ON [dbo].[ExperimentCandidate]([CandidateTargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CandidateImpactMetricModelId]
    ON [dbo].[ExperimentCandidate]([CandidateImpactMetricModelId] ASC);

