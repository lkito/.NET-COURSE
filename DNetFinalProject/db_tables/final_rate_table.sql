USE [DNetFinalProject]
GO

/****** Object:  Table [dbo].[CurrencyRates]    Script Date: 25-May-20 22:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CurrencyRates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [varchar](3) NOT NULL,
	[BuyRateGEL] [decimal](15, 2) NOT NULL,
	[SellRateGEL] [decimal](15, 2) NOT NULL,
 CONSTRAINT [PK_CurrencyRates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_CurrencyRates] UNIQUE NONCLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

