CREATE TABLE [dbo].[UserPayment] (
    [id]          BIGINT       IDENTITY (1, 1) NOT NULL,
    [UserId]      VARCHAR (50) NOT NULL,
    [PaymentType] VARCHAR (50) NULL,
    [Provider]    VARCHAR (50) NULL,
    CONSTRAINT [PK_UserPayment] PRIMARY KEY CLUSTERED ([id] ASC)
);

