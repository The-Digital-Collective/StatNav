CREATE TABLE [dbo].[UserRole] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]                   NVARCHAR (MAX) NULL,
    [ReadTeamProgrammes]         BIT            NOT NULL,
    [EditTeamProgrammes]         BIT            NOT NULL,
    [ReadOrganisationProgrammes] BIT            NOT NULL,
    [EditOrganisationProgrammes] BIT            NOT NULL,
    [Administrator]              BIT            NOT NULL,
    CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

