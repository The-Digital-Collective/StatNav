CREATE TABLE [dbo].[MetricModelStage] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [SortOrder]        INT            NOT NULL,
    [Title]            NVARCHAR (MAX) NULL,
    [DataType]         INT            NOT NULL,
    [MarketingModelId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.MetricModelStage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

