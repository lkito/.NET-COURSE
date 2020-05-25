USE [DNetFinalProject]
GO

/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 25-May-20 22:49:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncomingCurrencyCode] [varchar](3) NOT NULL,
	[OutgoingCurrencyCode] [varchar](3) NOT NULL,
	[IncomingAmount] [int] NOT NULL,
	[OutgoingAmount] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Comment] [nchar](4000) NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TransactionHistory] ADD  CONSTRAINT [DF_TransactionHistory_Comment]  DEFAULT ('') FOR [Comment]
GO

