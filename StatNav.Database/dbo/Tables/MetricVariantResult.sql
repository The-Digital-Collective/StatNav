CREATE TABLE [dbo].[MetricVariantResult] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [MetricId]   INT  NOT NULL,
    [VariantId]  INT  NOT NULL,
    [Value]      REAL NOT NULL,
    [SampleSize] REAL NOT NULL,
    CONSTRAINT [PK_dbo.MetricVariantResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MetricVariantResult_dbo.MetricModel_MetricId] FOREIGN KEY ([MetricId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.MetricVariantResult_dbo.Variant_VariantId] FOREIGN KEY ([VariantId]) REFERENCES [dbo].[Variant] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MetricId]
    ON [dbo].[MetricVariantResult]([MetricId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VariantId]
    ON [dbo].[MetricVariantResult]([VariantId] ASC);

