CREATE TABLE [dbo].[UserLogin] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (50)  NOT NULL,
    [LastName]   VARCHAR (50)  NOT NULL,
    [CreatedOn]  DATETIME      NOT NULL,
    [LoginTime]  DATETIME      NULL,
    [LogoutTime] DATETIME      NULL,
    [IsDisabled] BIT           CONSTRAINT [DF_UserLogin_IsDisabled] DEFAULT ((0)) NULL,
    [Role]       VARCHAR (10)  NOT NULL,
    [Password]   VARCHAR (MAX) NOT NULL,
    [Email]      VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED ([id] ASC)
);



