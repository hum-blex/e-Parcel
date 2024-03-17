CREATE TABLE [dbo].[OrderItems] (
    [id]         BIGINT       NOT NULL,
    [OrderId]    VARCHAR (50) NOT NULL,
    [Quantity]   VARCHAR (50) NOT NULL,
    [ProductId]  VARCHAR (50) NOT NULL,
    [CreatedOn]  DATETIME     NULL,
    [ModifiedOn] DATETIME     NULL
);

