use [master]
go
 create database [SqlSugar]
 go
 use [SqlSugar]
 go
 CREATE TABLE [dbo].[CarTypeExtend](
	[ID] [uniqueidentifier] NOT NULL,
	[CarType_ID] [uniqueidentifier] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Indexing] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Value] [nvarchar](100) NULL,
	[Picture_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CarTypeExtend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

