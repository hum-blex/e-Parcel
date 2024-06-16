CREATE TABLE [dbo].[Discount] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [DiscountPercentage] DECIMAL (18)  NULL,
    [Active]             BIT           CONSTRAINT [DF_Discount_Active] DEFAULT ((0)) NULL,
    [CreatedOn]          DATETIME      NOT NULL,
    [ModifiedOn]         DATETIME      NULL,
    [DeletedOn]          DATETIME      NULL,
    [Name]               VARCHAR (50)  NOT NULL,
    [Description]        VARCHAR (MAX) NULL,
    [ModifiedBy]         VARCHAR (50)  NULL,
    [IsDeleted]          BIT           NULL,
    CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED ([id] ASC)
);





