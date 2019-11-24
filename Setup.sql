;--CREATE DATABASE [AppQueue]
--GO

USE AppQueue

DROP TABLE [dbo].[QueueItem]
DROP TABLE [dbo].[Queue]

CREATE TABLE [dbo].[Queue]
(
	[Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Queue PRIMARY KEY
	,[UniqueId] UNIQUEIDENTIFIER NOT NULL
	,[Created] DATETIMEOFFSET NOT NULL
	,[Modified] DATETIMEOFFSET NOT NULL
	,INDEX Idx_Queue NONCLUSTERED ([UniqueId])
) 

CREATE TABLE [dbo].[QueueItem]
(
	[Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_QueueItem PRIMARY KEY
	,[QueueId] INT NOT NULL
		CONSTRAINT FK_QueueItem_Queue
		REFERENCES [dbo].[Queue]([Id])
	,[Key] VARBINARY(MAX) NOT NULL
	,[Data] VARBINARY(MAX) NOT NULL
	,[Completed] DATETIMEOFFSET NULL
	,[LastAttempted] DATETIMEOFFSET NULL
	,[Created] DATETIMEOFFSET NOT NULL
	,[Modified] DATETIMEOFFSET NOT NULL
)

SELECT * FROM [Queue]