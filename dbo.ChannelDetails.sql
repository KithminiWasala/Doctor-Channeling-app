CREATE TABLE [dbo].[ChannelDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Illness] VARCHAR(50) NOT NULL, 
    [Doctor] VARCHAR(50) NOT NULL, 
    [Time] VARCHAR(50) NOT NULL
)
