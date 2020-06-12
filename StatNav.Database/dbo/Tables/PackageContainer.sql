CREATE TABLE [dbo].[PackageContainer] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [PackageContainerName] NVARCHAR (MAX) NOT NULL,
    [Type]                 NVARCHAR (MAX) NOT NULL,
    [MetricModelStageId]   INT            NOT NULL,
    [Notes]                NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.PackageContainer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.PackageContainer_dbo.MetricModelStage_MetricModelStageId] FOREIGN KEY ([MetricModelStageId]) REFERENCES [dbo].[MetricModelStage] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MetricModelStageId]
    ON [dbo].[PackageContainer]([MetricModelStageId] ASC);

