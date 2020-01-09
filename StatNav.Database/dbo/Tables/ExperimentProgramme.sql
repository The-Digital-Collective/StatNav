CREATE TABLE [dbo].[ExperimentProgramme] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [ProgrammeName]                NVARCHAR (MAX) NOT NULL,
    [Problem]                      NVARCHAR (MAX) NULL,
    [ExperimentStatusId]           INT            NOT NULL,
    [ProblemValidation]            NVARCHAR (MAX) NULL,
    [Hypothesis]                   NVARCHAR (MAX) NULL,
    [Method]                       NVARCHAR (MAX) NULL,
    [ProgrammeTargetMetricModelId] INT            DEFAULT ((0)) NOT NULL,
    [TargetValue]                  REAL           DEFAULT ((0)) NOT NULL,
    [ProgrammeImpactMetricModelId] INT            DEFAULT ((0)) NOT NULL,
    [ImpactValue]                  REAL           DEFAULT ((0)) NOT NULL,
    [SuccessOutcome]               NVARCHAR (MAX) NULL,
    [FailureOutcome]               NVARCHAR (MAX) NULL,
    [Notes]                        NVARCHAR (MAX) NULL,
    [UserId]                       INT            NULL,
    [TeamId]                       INT            NULL,
    CONSTRAINT [PK_dbo.ExperimentProgramme] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.ExperimentStatus_ExperimentStatusId] FOREIGN KEY ([ExperimentStatusId]) REFERENCES [dbo].[ExperimentStatus] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_ImpactMetricModelId] FOREIGN KEY ([ProgrammeImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_TargetMetricModelId] FOREIGN KEY ([ProgrammeTargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentStatusId]
    ON [dbo].[ExperimentProgramme]([ExperimentStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProgrammeTargetMetricModelId]
    ON [dbo].[ExperimentProgramme]([ProgrammeTargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProgrammeImpactMetricModelId]
    ON [dbo].[ExperimentProgramme]([ProgrammeImpactMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[ExperimentProgramme]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeamId]
    ON [dbo].[ExperimentProgramme]([TeamId] ASC);

