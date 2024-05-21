CREATE TABLE [dbo].[UserAddress] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [Address]    VARCHAR (MAX) NOT NULL,
    [City]       VARCHAR (50)  NOT NULL,
    [Country]    VARCHAR (20)  NULL,
    [Telephone]  VARCHAR (50)  NULL,
    [Mobile]     VARCHAR (50)  NOT NULL,
    [State]      VARCHAR (50)  NOT NULL,
    [PostalCode] VARCHAR (50)  NULL,
    CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_UserAddress_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserLogin] ([id])
);



