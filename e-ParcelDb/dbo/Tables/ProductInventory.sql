CREATE TABLE [dbo].[ProductInventory] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [Quantity]   INT          NOT NULL,
    [CreatedOn]  DATETIME     NOT NULL,
    [ModifiedOn] DATETIME     NULL,
    [DeletedOn]  DATETIME     NULL,
    [ModifiedBy] VARCHAR (50) NULL,
    CONSTRAINT [PK_ProductInventory] PRIMARY KEY CLUSTERED ([id] ASC)
);



