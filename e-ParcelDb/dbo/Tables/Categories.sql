CREATE TABLE [dbo].[Categories] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NOT NULL,
    [DisplayOrder] INT           NOT NULL,
    [CategoryId]   BIGINT        NOT NULL,
    [Description]  VARCHAR (MAX) NULL,
    [CreatedOn]    DATETIME      NULL,
    [ModifiedOn]   DATETIME      NULL,
    [DeletedOn]    DATETIME      NULL,
    [ModifiedBy]   VARCHAR (50)  NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

