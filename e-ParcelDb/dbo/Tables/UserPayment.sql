CREATE TABLE [dbo].[UserPayment] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [UserId]      INT          NOT NULL,
    [PaymentType] VARCHAR (50) NOT NULL,
    [Provider]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserPayment] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_UserPayment_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserLogin] ([id])
);



