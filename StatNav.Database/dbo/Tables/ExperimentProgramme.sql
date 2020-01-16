CREATE TABLE [dbo].[ExperimentProgramme] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [UserId]                       INT            NULL,
    [TeamId]                       INT            NULL,
    [ProgrammeName]                NVARCHAR (MAX) NOT NULL,
    [Problem]                      NVARCHAR (MAX) NULL,
    [ProblemValidation]            NVARCHAR (MAX) NULL,
    [Hypothesis]                   NVARCHAR (MAX) NULL,
    [MethodId]                     INT            NOT NULL,
    [ProgrammeTargetMetricModelId] INT            NOT NULL,
    [TargetValue]                  REAL           NOT NULL,
    [ProgrammeImpactMetricModelId] INT            NOT NULL,
    [ImpactValue]                  REAL           NOT NULL,
    [ExperimentStatusId]           INT            NOT NULL,
    [Notes]                        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ExperimentProgramme] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.ExperimentStatus_ExperimentStatusId] FOREIGN KEY ([ExperimentStatusId]) REFERENCES [dbo].[ExperimentStatus] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.Method_Method] FOREIGN KEY ([MethodId]) REFERENCES [dbo].[Method] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_ProgrammeImpactMetricModelId] FOREIGN KEY ([ProgrammeImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.MetricModel_ProgrammeTargetMetricModelId] FOREIGN KEY ([ProgrammeTargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]),
    CONSTRAINT [FK_dbo.ExperimentProgramme_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[ExperimentProgramme]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeamId]
    ON [dbo].[ExperimentProgramme]([TeamId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MethodId]
    ON [dbo].[ExperimentProgramme]([MethodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProgrammeTargetMetricModelId]
    ON [dbo].[ExperimentProgramme]([ProgrammeTargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProgrammeImpactMetricModelId]
    ON [dbo].[ExperimentProgramme]([ProgrammeImpactMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentStatusId]
    ON [dbo].[ExperimentProgramme]([ExperimentStatusId] ASC);

