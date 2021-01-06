/****** Object:  Table [dbo].[MastProduct]    Script Date: 1/6/2021 8:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MastProduct](
	[ProdID] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [nvarchar](100) NULL,
	[ProdDesc] [nvarchar](500) NULL,
	[UnitsInStock] [int] NULL,
	[UnitOfMeasure] [nvarchar](30) NULL,
	[UnitOfSales] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.MastProduct] PRIMARY KEY CLUSTERED 
(
	[ProdID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdDiscounts]    Script Date: 1/6/2021 8:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdDiscounts](
	[DiscID] [int] IDENTITY(1,1) NOT NULL,
	[ProdID] [int] NOT NULL,
	[DiscType] [nvarchar](100) NULL,
	[DiscUnit] [decimal](4, 2) NULL,
	[MinOrderQty] [int] NULL,
	[DiscPriority] [int] NOT NULL,
	[DiscDesc] [nvarchar](100) NULL,
	[FixedPrice] [decimal](10, 2) NULL,
	[ChargeForQty] [int] NULL,
	[DiscPercent] [decimal](5, 2) NULL,
 CONSTRAINT [PK_dbo.ProdDiscounts] PRIMARY KEY CLUSTERED 
(
	[DiscID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdPricing]    Script Date: 1/6/2021 8:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdPricing](
	[ProdPriceID] [int] IDENTITY(1,1) NOT NULL,
	[ProdID] [int] NOT NULL,
	[BasePrice] [numeric](10, 2) NULL,
	[PromoOffer] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProdPricing] PRIMARY KEY CLUSTERED 
(
	[ProdPriceID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MastProduct] ON 
GO
INSERT [dbo].[MastProduct] ([ProdID], [ProdName], [ProdDesc], [UnitsInStock], [UnitOfMeasure], [UnitOfSales]) VALUES (1, N'A', N'Rubber Gloves', 1000, N'NUMBERS', N'INTEGER')
GO
INSERT [dbo].[MastProduct] ([ProdID], [ProdName], [ProdDesc], [UnitsInStock], [UnitOfMeasure], [UnitOfSales]) VALUES (2, N'B', N'Stethoscope', 1000, N'NUMBERS', N'INTEGER')
GO
INSERT [dbo].[MastProduct] ([ProdID], [ProdName], [ProdDesc], [UnitsInStock], [UnitOfMeasure], [UnitOfSales]) VALUES (3, N'C', N'Talc', 1000, N'WEIGHT', N'FLOAT')
GO
INSERT [dbo].[MastProduct] ([ProdID], [ProdName], [ProdDesc], [UnitsInStock], [UnitOfMeasure], [UnitOfSales]) VALUES (4, N'D', N'Gloves', 500, N'NUMBERS', N'INTEGER')
GO
INSERT [dbo].[MastProduct] ([ProdID], [ProdName], [ProdDesc], [UnitsInStock], [UnitOfMeasure], [UnitOfSales]) VALUES (5, N'E', N'ALMONDS', 200, N'WEIGHT', N'FLOAT')
GO
SET IDENTITY_INSERT [dbo].[MastProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[ProdDiscounts] ON 
GO
INSERT [dbo].[ProdDiscounts] ([DiscID], [ProdID], [DiscType], [DiscUnit], [MinOrderQty], [DiscPriority], [DiscDesc], [FixedPrice], [ChargeForQty], [DiscPercent]) VALUES (1, 1, N'FREE_ON_MIN_QTY', CAST(1.00 AS Decimal(4, 2)), 3, 1, N'BUY 2 AND GET 1 FREEE', NULL, 2, NULL)
GO
INSERT [dbo].[ProdDiscounts] ([DiscID], [ProdID], [DiscType], [DiscUnit], [MinOrderQty], [DiscPriority], [DiscDesc], [FixedPrice], [ChargeForQty], [DiscPercent]) VALUES (2, 2, N'FIXEDPRICE', CAST(0.00 AS Decimal(4, 2)), 3, 1, N'Fixed price for 3', CAST(999.00 AS Decimal(10, 2)), NULL, NULL)
GO
INSERT [dbo].[ProdDiscounts] ([DiscID], [ProdID], [DiscType], [DiscUnit], [MinOrderQty], [DiscPriority], [DiscDesc], [FixedPrice], [ChargeForQty], [DiscPercent]) VALUES (4, 5, N'FLAT_PERCENT', NULL, 2, 1, N'FLAT 10% discount on purchase of 2', NULL, NULL, CAST(10.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[ProdDiscounts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProdPricing] ON 
GO
INSERT [dbo].[ProdPricing] ([ProdPriceID], [ProdID], [BasePrice], [PromoOffer]) VALUES (1, 1, CAST(59.90 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[ProdPricing] ([ProdPriceID], [ProdID], [BasePrice], [PromoOffer]) VALUES (2, 2, CAST(399.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[ProdPricing] ([ProdPriceID], [ProdID], [BasePrice], [PromoOffer]) VALUES (3, 3, CAST(19.54 AS Numeric(10, 2)), 0)
GO
INSERT [dbo].[ProdPricing] ([ProdPriceID], [ProdID], [BasePrice], [PromoOffer]) VALUES (4, 5, CAST(100.00 AS Numeric(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[ProdPricing] OFF
GO
ALTER TABLE [dbo].[ProdDiscounts]  WITH CHECK ADD  CONSTRAINT [FK_ProdDiscounts_ProdID] FOREIGN KEY([ProdID])
REFERENCES [dbo].[MastProduct] ([ProdID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdDiscounts] CHECK CONSTRAINT [FK_ProdDiscounts_ProdID]
GO
ALTER TABLE [dbo].[ProdPricing]  WITH CHECK ADD  CONSTRAINT [FK_ProdPricing_ProdID] FOREIGN KEY([ProdID])
REFERENCES [dbo].[MastProduct] ([ProdID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdPricing] CHECK CONSTRAINT [FK_ProdPricing_ProdID]
GO
