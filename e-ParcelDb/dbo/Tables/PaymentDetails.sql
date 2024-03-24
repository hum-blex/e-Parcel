CREATE TABLE [dbo].[PaymentDetails] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [OrderId]    INT          NOT NULL,
    [Amount]     DECIMAL (18) NOT NULL,
    [Status]     VARCHAR (50) NOT NULL,
    [CreatedOn]  DATETIME     NOT NULL,
    [ModifiedOn] DATETIME     NULL,
    [Provider]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PaymentDetails_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderDetails] ([id])
);



