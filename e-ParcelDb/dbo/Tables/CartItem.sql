CREATE TABLE [dbo].[CartItem] (
    [id]         INT      IDENTITY (1, 1) NOT NULL,
    [SessionId]  INT      NOT NULL,
    [ProductId]  INT      NOT NULL,
    [Quantity]   INT      NULL,
    [CreatedOn]  DATETIME NOT NULL,
    [ModifiedOn] DATETIME NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_CartItem_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_CartItem_ShoppingSession] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[ShoppingSession] ([id])
);



