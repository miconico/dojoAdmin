CREATE TABLE [dbo].[badges]
(
	[badgeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(250) NOT NULL DEFAULT 'Ninja Badge', 
    [description] VARCHAR(MAX) NOT NULL DEFAULT 'Being cool', 
    [badgeStepId] INT NOT NULL, 
    [active] BIT NOT NULL DEFAULT 1
)
