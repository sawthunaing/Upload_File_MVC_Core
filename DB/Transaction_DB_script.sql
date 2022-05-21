USE [Transaction_DB]
GO
/****** Object:  Table [dbo].[tblTransaction]    Script Date: 5/22/2022 3:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransaction](
	[Id] [uniqueidentifier] NOT NULL,
	[TransactionId] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NULL,
	[CurrencyCode] [nvarchar](10) NOT NULL,
	[TransactionDate] [datetime] NULL,
	[CSVStatus] [nvarchar](10) NOT NULL,
	[XmlStatus] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus]) VALUES (N'48b5f004-f051-4621-b0c0-01e019228c3e', N'In00003', CAST(2500.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-01-23T13:45:10.000' AS DateTime), N'Finished', N'Done')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus]) VALUES (N'35dc3495-35a8-4f7f-b860-2822c3daff8c', N'Inv00001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-01-23T13:45:10.000' AS DateTime), N'Approved', N'Approved')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus]) VALUES (N'880e58ff-da07-4e0b-ae32-4506ea344ec2', N'Inv00002', CAST(2000.00 AS Decimal(10, 2)), N'EUR', CAST(N'2019-01-23T13:45:10.000' AS DateTime), N'Failed', N'Rejected')
GO
ALTER TABLE [dbo].[tblTransaction] ADD  DEFAULT (newid()) FOR [Id]
GO
