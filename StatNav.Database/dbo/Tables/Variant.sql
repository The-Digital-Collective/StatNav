CREATE TABLE [dbo].[Variant] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [ExperimentId]               INT            NOT NULL,
    [VariantName]                NVARCHAR (MAX) NOT NULL,
    [Control]                    BIT            NOT NULL,
    [VariantTargetMetricModelId] INT            NOT NULL,
    [TargetMet]                  BIT            NOT NULL,
    [VariantImpactMetricModelId] INT            NOT NULL,
    [ImpactMet]                  BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Variant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Variant_dbo.Experiment_ExperimentId] FOREIGN KEY ([ExperimentId]) REFERENCES [dbo].[Experiment] ([Id]),
    CONSTRAINT [FK_dbo.Variant_dbo.MetricModel_VariantImpactMetricModelId] FOREIGN KEY ([VariantImpactMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id]),
    CONSTRAINT [FK_dbo.Variant_dbo.MetricModel_VariantTargetMetricModelId] FOREIGN KEY ([VariantTargetMetricModelId]) REFERENCES [dbo].[MetricModel] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExperimentId]
    ON [dbo].[Variant]([ExperimentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VariantTargetMetricModelId]
    ON [dbo].[Variant]([VariantTargetMetricModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VariantImpactMetricModelId]
    ON [dbo].[Variant]([VariantImpactMetricModelId] ASC);

