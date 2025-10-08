CREATE TABLE [dbo].[user] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR(100) NOT NULL, 
    [Age] INT NOT NULL, 
    [Contact] INT NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Password] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

