CREATE TABLE [dbo].[ProdDiscounts] (
    [DiscID]       INT             IDENTITY (1, 1) NOT NULL,
    [ProdID]       INT             NOT NULL,
    [DiscType]     NVARCHAR (100)  NULL,
    [DiscUnit]     DECIMAL (4, 2)  NULL,
    [MinOrderQty]  INT             NULL,
    [DiscPriority] INT             NOT NULL,
    [DiscDesc]     NVARCHAR (100)  NULL,
    [FixedPrice]   DECIMAL (10, 2) NULL,
    [ChargeForQty] INT             NULL,
    [DiscPercent]  DECIMAL (5, 2)  NULL,
    CONSTRAINT [PK_dbo.ProdDiscounts] PRIMARY KEY CLUSTERED ([DiscID] ASC),
    CONSTRAINT [FK_ProdDiscounts_ProdID] FOREIGN KEY ([ProdID]) REFERENCES [dbo].[MastProduct] ([ProdID]) ON DELETE CASCADE
);

