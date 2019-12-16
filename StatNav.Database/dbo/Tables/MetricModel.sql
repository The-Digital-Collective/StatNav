CREATE TABLE [dbo].[MetricModel] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [MetricModelStageId] INT            NOT NULL,
    [Title]              NVARCHAR (MAX) NULL,
    [GoodIsUp]           BIT            NOT NULL,
    CONSTRAINT [PK_dbo.MetricModel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MetricModel_dbo.MetricModelStage_MetricModelStageId] FOREIGN KEY ([MetricModelStageId]) REFERENCES [dbo].[MetricModelStage] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MetricModelStageId]
    ON [dbo].[MetricModel]([MetricModelStageId] ASC);

