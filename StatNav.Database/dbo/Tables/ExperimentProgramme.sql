CREATE TABLE [dbo].[ExperimentProgramme] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (MAX) NULL,
    [Problem]             NVARCHAR (MAX) NULL,
    [ExperimentStatusId]  INT            NOT NULL,
    [ProblemValidation]   NVARCHAR (MAX) NULL,
    [Hypothesis]          NVARCHAR (MAX) NULL,
    [Method]              NVARCHAR (MAX) NULL,
    [TargetMetricModelId] INT            DEFAULT ((0)) NOT NULL,
    [TargetValue]         REAL           DEFAULT ((0)) NOT NULL,
    [ImpactMetricModelId] INT            DEFAULT ((0)) NOT NULL,
    [ImpactValue]         REAL           DEFAULT ((0)) NOT NULL,
    [SuccessOutcome]      NVARCHAR (MAX) NULL,
    [FailureOutcome]      NVARCHAR (MAX) NULL,
    [Notes]               NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ExperimentProgramme] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.ExperimentStatus_ExperimentStatusId] FOREIGN KEY ([ExperimentStatusId]) REFERENCES [dbo].[ExperimentStatus] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_ImpactMetricModelId] FOREIGN KEY ([ImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_TargetMetricModelId] FOREIGN KEY ([TargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentStatusId]
    ON [dbo].[ExperimentProgramme]([ExperimentStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TargetMetricModelId]
    ON [dbo].[ExperimentProgramme]([TargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ImpactMetricModelId]
    ON [dbo].[ExperimentProgramme]([ImpactMetricModelId] ASC);

