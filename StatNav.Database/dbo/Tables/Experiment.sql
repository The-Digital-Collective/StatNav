CREATE TABLE [dbo].[Experiment] (
    [Id]                              INT            IDENTITY (1, 1) NOT NULL,
    [MarketingAssetPackageId]         INT            NOT NULL,
    [RequiredDurationForSignificance] NVARCHAR (MAX) NULL,
    [StartDateTime]                   DATETIME       NULL,
    [EndDateTime]                     DATETIME       NULL,
    [SuccessOutcome]                  NVARCHAR (MAX) NULL,
    [FailureOutcome]                  NVARCHAR (MAX) NULL,
    [ExperimentName]                  NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [ExperimentNumber]                INT            NULL,
    CONSTRAINT [PK_dbo.Experiment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentIteration_dbo.MarketingAssetPackage_MarketingAssetPackageId] FOREIGN KEY ([MarketingAssetPackageId]) REFERENCES [dbo].[MarketingAssetPackage] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MarketingAssetPackageId]
    ON [dbo].[Experiment]([MarketingAssetPackageId] ASC);

