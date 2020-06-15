CREATE TABLE [dbo].[MarketingAssetPackage] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [UserId]                 INT            NULL,
    [TeamId]                 INT            NULL,
    [MAPName]                NVARCHAR (MAX) NOT NULL,
    [Problem]                NVARCHAR (MAX) NULL,
    [ProblemValidation]      NVARCHAR (MAX) NULL,
    [Hypothesis]             NVARCHAR (MAX) NULL,
    [MethodId]               INT            NOT NULL,
    [MAPTargetMetricModelId] INT            NOT NULL,
    [TargetValue]            REAL           NOT NULL,
    [MAPImpactMetricModelId] INT            NOT NULL,
    [ImpactValue]            REAL           NOT NULL,
    [ExperimentStatusId]     INT            NOT NULL,
    [Notes]                  NVARCHAR (MAX) NULL,
    [PackageContainerId]     INT            NOT NULL,
    CONSTRAINT [PK_dbo.MarketingAssetPackage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.ExperimentStatus_ExperimentStatusId] FOREIGN KEY ([ExperimentStatusId]) REFERENCES [dbo].[ExperimentStatus] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.Method_MethodId] FOREIGN KEY ([MethodId]) REFERENCES [dbo].[Method] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.MetricModel_MAPImpactMetricModelId] FOREIGN KEY ([MAPImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.MetricModel_MAPTargetMetricModelId] FOREIGN KEY ([MAPTargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.PackageContainer_PackageContainerId] FOREIGN KEY ([PackageContainerId]) REFERENCES [dbo].[PackageContainer] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]),
    CONSTRAINT [FK_dbo.MarketingAssetPackage_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[MarketingAssetPackage]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeamId]
    ON [dbo].[MarketingAssetPackage]([TeamId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MethodId]
    ON [dbo].[MarketingAssetPackage]([MethodId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MAPTargetMetricModelId]
    ON [dbo].[MarketingAssetPackage]([MAPTargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MAPImpactMetricModelId]
    ON [dbo].[MarketingAssetPackage]([MAPImpactMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentStatusId]
    ON [dbo].[MarketingAssetPackage]([ExperimentStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PackageContainerId]
    ON [dbo].[MarketingAssetPackage]([PackageContainerId] ASC);

