CREATE TABLE [dbo].[ninja]
(
	[ninjaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ninjaName] VARCHAR(100) NOT NULL DEFAULT '', 
    [classId] INT NOT NULL, 
    [bio] VARCHAR(MAX) NULL DEFAULT 'codeninja', 
    [joined] DATETIME NOT NULL DEFAULT getdate(), 
    [websiteUrl] VARCHAR(250) NULL DEFAULT 'http://coderdojoport.com', 
    [active] BIT NOT NULL DEFAULT 1
)
