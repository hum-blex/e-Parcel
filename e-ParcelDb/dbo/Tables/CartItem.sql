CREATE TABLE [dbo].[CartItem] (
    [id]         BIGINT   IDENTITY (1, 1) NOT NULL,
    [SessionId]  BIGINT   NOT NULL,
    [ProductId]  BIGINT   NOT NULL,
    [Quantity]   INT      NOT NULL,
    [CreatedOn]  DATETIME NULL,
    [ModifiedOn] DATETIME NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED ([id] ASC)
);

