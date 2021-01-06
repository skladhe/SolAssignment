CREATE TABLE [dbo].[ProdPricing] (
    [ProdPriceID] INT             IDENTITY (1, 1) NOT NULL,
    [ProdID]      INT             NOT NULL,
    [BasePrice]   NUMERIC (10, 2) NULL,
    [PromoOffer]  BIT             NOT NULL,
    CONSTRAINT [PK_dbo.ProdPricing] PRIMARY KEY CLUSTERED ([ProdPriceID] ASC),
    CONSTRAINT [FK_ProdPricing_ProdID] FOREIGN KEY ([ProdID]) REFERENCES [dbo].[MastProduct] ([ProdID]) ON DELETE CASCADE
);



