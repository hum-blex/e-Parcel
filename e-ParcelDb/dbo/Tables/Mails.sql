CREATE TABLE [dbo].[Mails] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [From]            VARCHAR (MAX) NOT NULL,
    [To]              VARCHAR (MAX) NOT NULL,
    [Subject]         VARCHAR (MAX) NULL,
    [Body]            VARCHAR (MAX) NULL,
    [AttachmentUrl]   VARCHAR (MAX) NULL,
    [CreatedDateTime] DATETIME2 (7) NOT NULL,
    [code]            VARCHAR (MAX) CONSTRAINT [DF__Mails__code__46E78A0C] DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Mails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

