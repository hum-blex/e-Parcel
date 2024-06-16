CREATE TABLE [dbo].[OrderDetails] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [UserId]     INT          NOT NULL,
    [Total]      DECIMAL (18) NOT NULL,
    [PaymentId]  INT          NOT NULL,
    [CreatedOn]  DATETIME     NOT NULL,
    [ModifiedOn] DATETIME     NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OrderDetails_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserLogin] ([id])
);



