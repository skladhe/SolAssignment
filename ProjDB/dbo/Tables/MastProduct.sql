CREATE TABLE [dbo].[MastProduct] (
    [ProdID]        INT            IDENTITY (1, 1) NOT NULL,
    [ProdName]      NVARCHAR (100) NULL,
    [ProdDesc]      NVARCHAR (500) NULL,
    [UnitsInStock]  INT            NULL,
    [UnitOfMeasure] NVARCHAR (30)  NULL,
    [UnitOfSales]   NVARCHAR (30)  NULL,
    CONSTRAINT [PK_dbo.MastProduct] PRIMARY KEY CLUSTERED ([ProdID] ASC)
);

