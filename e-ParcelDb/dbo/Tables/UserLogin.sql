CREATE TABLE [dbo].[UserLogin] (
    [id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]     VARCHAR (50)  NOT NULL,
    [FirstName]  VARCHAR (50)  NULL,
    [LastName]   VARCHAR (50)  NULL,
    [CreatedOn]  DATETIME      NULL,
    [LoginTime]  DATETIME      NULL,
    [LogoutTime] DATETIME      NULL,
    [IsDisabled] BIT           CONSTRAINT [DF_UserLogin_IsDisabled] DEFAULT ((0)) NULL,
    [Role]       VARCHAR (10)  NULL,
    [Password]   VARCHAR (MAX) NOT NULL,
    [Email]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED ([id] ASC)
);

