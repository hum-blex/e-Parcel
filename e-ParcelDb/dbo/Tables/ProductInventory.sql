CREATE TABLE [dbo].[ProductInventory] (
    [id]          BIGINT       IDENTITY (1, 1) NOT NULL,
    [InventoryId] BIGINT       NOT NULL,
    [Quantity]    INT          NOT NULL,
    [CreatedOn]   DATETIME     NULL,
    [ModifiedOn]  DATETIME     NULL,
    [DeletedOn]   DATETIME     NULL,
    [IsDeleted]   BIT          CONSTRAINT [DF_ProductInventory_IsDeleted] DEFAULT ((0)) NULL,
    [ModifiedBy]  VARCHAR (50) NULL,
    CONSTRAINT [PK_ProductInventory] PRIMARY KEY CLUSTERED ([id] ASC)
);

