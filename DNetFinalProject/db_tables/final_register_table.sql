USE [DNetFinalProject]
GO

/****** Object:  Table [dbo].[CurrencyRegister]    Script Date: 25-May-20 22:49:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CurrencyRegister](
	[CurrencyCode] [varchar](3) NOT NULL,
	[CurrencyName] [nchar](20) NOT NULL,
	[CurrencyLatinName] [varchar](20) NOT NULL,
	[OrderNum] [int] NOT NULL,
 CONSTRAINT [PK_CurrencyRegister] PRIMARY KEY CLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

