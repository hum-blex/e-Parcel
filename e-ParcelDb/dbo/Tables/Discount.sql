CREATE TABLE [dbo].[Discount] (
    [id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [DiscountId]  BIGINT        NOT NULL,
    [Percent]     FLOAT (53)    NULL,
    [Active]      BIT           CONSTRAINT [DF_Discount_Active] DEFAULT ((0)) NULL,
    [CreatedOn]   DATETIME      NULL,
    [ModifiedOn]  DATETIME      NULL,
    [DeletedOn]   DATETIME      NULL,
    [Name]        VARCHAR (50)  NULL,
    [Description] VARCHAR (MAX) NULL,
    [ModifiedBy]  VARCHAR (50)  NULL,
    CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED ([id] ASC)
);

