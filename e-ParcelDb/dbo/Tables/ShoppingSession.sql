CREATE TABLE [dbo].[ShoppingSession] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [UserId]     INT          NOT NULL,
    [Total]      DECIMAL (18) NOT NULL,
    [CreatedOn]  DATETIME     NOT NULL,
    [ModifiedOn] DATETIME     NULL,
    CONSTRAINT [PK_ShoppingSession] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ShoppingSession_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserLogin] ([id])
);



