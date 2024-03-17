CREATE TABLE [dbo].[PaymentDetails] (
    [id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [PaymentId]  BIGINT       NOT NULL,
    [OrderId]    VARCHAR (50) NOT NULL,
    [Amount]     FLOAT (53)   NOT NULL,
    [Status]     VARCHAR (50) NOT NULL,
    [CreatedOn]  DATETIME     NULL,
    [ModifiedOn] DATETIME     NULL,
    CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED ([id] ASC)
);

