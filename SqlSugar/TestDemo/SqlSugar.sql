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

--CarType
CREATE TABLE [dbo].[CarType](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[Premium] [int] NOT NULL,
	[Introduce] [nvarchar](4000) NOT NULL,
	[Picture_ID] [uniqueidentifier] NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CarType] ADD  CONSTRAINT [DF__CarType__State__407A839F]  DEFAULT ((1)) FOR [State]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保险费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarType', @level2type=N'COLUMN',@level2name=N'Premium'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：0：删除，1：正常' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarType', @level2type=N'COLUMN',@level2name=N'State'
GO