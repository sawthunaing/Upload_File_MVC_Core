USE [Transaction_DB]
GO
/****** Object:  Table [dbo].[tblTransaction]    Script Date: 5/23/2022 12:50:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransaction](
	[Id] [uniqueidentifier] NOT NULL,
	[TransactionId] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[CurrencyCode] [nvarchar](10) NOT NULL,
	[TransactionDate] [datetime] NULL,
	[CSVStatus] [nvarchar](10) NULL,
	[XmlStatus] [nvarchar](10) NULL,
	[OutputStatus] [nvarchar](10) NULL,
 CONSTRAINT [PK__tblTrans__3214EC07999A0676] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'cb1819c6-5b45-4a49-b198-08da3c0a0969', N'Inv00001', CAST(200.00 AS Decimal(10, 2)), N'USD', CAST(N'2022-05-22T10:15:03.000' AS DateTime), NULL, N'Done', N'D')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'85ddbe07-71b5-42b4-b199-08da3c0a0969', N'Inv00002', CAST(10000.00 AS Decimal(10, 2)), N'EUR', CAST(N'2022-05-22T10:15:03.000' AS DateTime), NULL, N'Rejected', N'R')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'b7807db0-5093-47be-9cee-08da3c125538', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'a075b44e-29a6-4944-9cef-08da3c125538', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'3c23fecc-c811-47b9-3b5b-08da3c127866', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'd92102a9-9226-4549-3b5c-08da3c127866', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'281e322d-9b85-421b-85f9-08da3c12a1ac', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'63deb688-8e4d-4a3d-85fa-08da3c12a1ac', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'5f54c6fe-209e-4c9d-b160-08da3c1991c4', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'd0587ebb-eeda-4a2a-b161-08da3c1991c4', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'25968e6c-a2eb-4e75-b162-08da3c1991c4', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'0d1176bd-3030-440e-b163-08da3c1991c4', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'41e5fd68-d68b-4d17-8523-08da3c19db5d', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'2af0a00f-10f2-4b9f-8524-08da3c19db5d', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'1c5997c9-c409-4a9e-bd12-08da3c1a0bef', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'442fe0f1-de15-4f7d-bd13-08da3c1a0bef', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'70145706-65e3-4cb2-9377-08da3c1c2e3d', N'Inv001', CAST(1000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
INSERT [dbo].[tblTransaction] ([Id], [TransactionId], [Amount], [CurrencyCode], [TransactionDate], [CSVStatus], [XmlStatus], [OutputStatus]) VALUES (N'89bf9643-ad07-4c05-9378-08da3c1c2e3d', N'Inv001', CAST(2000.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-02-20T00:33:16.000' AS DateTime), N'Approved', NULL, N'A')
GO
ALTER TABLE [dbo].[tblTransaction] ADD  CONSTRAINT [DF__tblTransacti__Id__24927208]  DEFAULT (newid()) FOR [Id]
GO
