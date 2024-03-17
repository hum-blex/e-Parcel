CREATE TABLE [dbo].[UserAddress] (
    [id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]       VARCHAR (50)  NOT NULL,
    [AddressLine1] VARCHAR (MAX) NULL,
    [AddressLine2] VARCHAR (MAX) NULL,
    [City]         VARCHAR (50)  NULL,
    [PostalCode]   VARCHAR (15)  NULL,
    [Country]      VARCHAR (20)  NULL,
    [Telephone]    VARCHAR (50)  NULL,
    [Mobile]       VARCHAR (50)  NULL,
    CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED ([id] ASC)
);

