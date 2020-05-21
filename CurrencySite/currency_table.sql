USE [DynamicCurrency]
GO

/****** Object:  Table [dbo].[CurrencyEntry]    Script Date: 21-May-20 23:59:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CurrencyEntry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FromCurrency] [varchar](3) NOT NULL,
	[ToCurrency] [varchar](3) NOT NULL,
	[Rate] [decimal](15, 2) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CurrencyEntry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CurrencyEntry] ADD  CONSTRAINT [DF_CurrencyEntry_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[CurrencyEntry] ADD  CONSTRAINT [DF_CurrencyEntry_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO

