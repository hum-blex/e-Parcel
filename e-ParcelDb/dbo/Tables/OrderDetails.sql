CREATE TABLE [dbo].[OrderDetails] (
    [id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [UserId]     VARCHAR (50) NOT NULL,
    [Total]      FLOAT (53)   NOT NULL,
    [PaymentId]  BIGINT       NOT NULL,
    [CreatedOn]  DATETIME     NULL,
    [ModifiedOn] DATETIME     NULL,
    [OrderId]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([id] ASC)
);

