CREATE TABLE [dbo].[Products] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (MAX) NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    [Price]       DECIMAL (18)  NOT NULL,
    [CategoryId]  INT           CONSTRAINT [DF__Products__Catego__403A8C7D] DEFAULT ((0)) NOT NULL,
    [ImageUrl]    VARCHAR (MAX) CONSTRAINT [DF__Products__ImageU__412EB0B6] DEFAULT (N'') NOT NULL,
    [DiscountId]  INT           NOT NULL,
    [InventoryId] INT           NOT NULL,
    [CreatedOn]   DATETIME      NULL,
    [DeletedOn]   DATETIME      NULL,
    [ModifiedBy]  VARCHAR (50)  NULL,
    [SKU]         VARCHAR (50)  NOT NULL,
    [ModifiedOn]  DATETIME      NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Discount] FOREIGN KEY ([DiscountId]) REFERENCES [dbo].[Discount] ([id]),
    CONSTRAINT [FK_Products_ProductInventory] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[ProductInventory] ([id])
);



