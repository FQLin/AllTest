use [master]
go
 create database [SqlSugar]
 go
 use [SqlSugar]
 go
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
/****** Object:  Table [dbo].[CarTypeExtend]    Script Date: 2019/5/20 17:51:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[OrdersCar]    Script Date: 2019/5/20 17:51:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersCar](
	[ID] [uniqueidentifier] NOT NULL,
	[Customer_ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Goods] [nvarchar](100) NOT NULL,
	[Number] [bigint] NOT NULL,
	[TradeID] [nvarchar](100) NOT NULL,
	[TotalFee] [int] NOT NULL,
	[State] [tinyint] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[PayTime] [datetime] NULL,
	[CarType_ID] [uniqueidentifier] NULL,
	[ProductGrade_ID] [uniqueidentifier] NULL,
	[Picture_ID] [uniqueidentifier] NULL,
	[StartStore_ID] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndStore_ID] [uniqueidentifier] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Car_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_OrdersCar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 2019/5/20 17:51:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[ID] [uniqueidentifier] NOT NULL,
	[Company_ID] [uniqueidentifier] NOT NULL,
	[Area_ID] [uniqueidentifier] NOT NULL,
	[Area_Name] [nvarchar](100) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrdersCar', @level2type=N'COLUMN',@level2name=N'Customer_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrdersCar', @level2type=N'COLUMN',@level2name=N'Goods'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrdersCar', @level2type=N'COLUMN',@level2name=N'Number'
GO