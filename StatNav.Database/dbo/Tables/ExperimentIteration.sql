CREATE TABLE [dbo].[ExperimentIteration] (
    [Id]                              INT            IDENTITY (1, 1) NOT NULL,
    [IterationName]                   NVARCHAR (MAX) NOT NULL,
    [RequiredDurationForSignificance] NVARCHAR (MAX) NULL,
    [IterationNumber]                 INT            NOT NULL,
    [StartDateTime]                   DATETIME       NOT NULL,
    [EndDateTime]                     DATETIME       NOT NULL,
    [SuccessOutcome]                  NVARCHAR (MAX) NULL,
    [FailureOutcome]                  NVARCHAR (MAX) NULL,
    [MarketingAssetPackageId]         INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.ExperimentIteration] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExperimentIteration_dbo.MarketingAssetPackage_MarketingAssetPackageId] FOREIGN KEY ([MarketingAssetPackageId]) REFERENCES [dbo].[MarketingAssetPackage] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MarketingAssetPackageId]
    ON [dbo].[ExperimentIteration]([MarketingAssetPackageId] ASC);

