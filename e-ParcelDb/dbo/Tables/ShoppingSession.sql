CREATE TABLE [dbo].[ShoppingSession] (
    [id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [SessionId]  BIGINT       NOT NULL,
    [UserId]     VARCHAR (50) NULL,
    [Total]      FLOAT (53)   NULL,
    [CreatedOn]  DATETIME     NULL,
    [ModifiedOn] DATETIME     NULL,
    CONSTRAINT [PK_ShoppingSession] PRIMARY KEY CLUSTERED ([id] ASC)
);

