CREATE TABLE [dbo].[course]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [cName] NCHAR(10) NULL, 
    [duration(month)] INT NULL, 
    [fees] FLOAT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([courseID]), 
    CONSTRAINT [PK_Table] PRIMARY KEY ([ID])
)
