CREATE TABLE [dbo].[OrderItems] (
    [id]         INT      NOT NULL,
    [OrderId]    INT      NOT NULL,
    [Quantity]   INT      NOT NULL,
    [ProductId]  INT      NOT NULL,
    [CreatedOn]  DATETIME NOT NULL,
    [ModifiedOn] DATETIME NULL,
    CONSTRAINT [FK_OrderItems_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderDetails] ([id]),
    CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);



