CREATE TABLE [dbo].[badgeSteps]
(
	[badgeStepId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [badgeId] INT NOT NULL, 
    [stepNo] INT NOT NULL DEFAULT 0, 
    [stepDesc] VARCHAR(250) NOT NULL DEFAULT 'badge internmediate achievement', 
    [active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_badge_steps_badges] FOREIGN KEY ([badgeId]) REFERENCES [badges]([badgeId])
)
