USE [KYCapplication]
GO
/****** Object:  Table [dbo].[kycdetail]    Script Date: 2/15/2023 4:07:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kycdetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Kycid] [varchar](300) NULL,
	[Name] [varchar](500) NULL,
	[acoount_no] [varchar](50) NULL,
	[mobail_no] [varchar](20) NULL,
	[accout_type] [varchar](250) NULL,
	[pancardno_HA] [varchar](250) NULL,
	[pancardverify_HA] [varchar](250) NULL,
	[pancardno_HB] [varchar](250) NULL,
	[pancardverify_HB] [varchar](250) NULL,
	[Aadharcardno_HA] [varchar](250) NULL,
	[Aadharcardverify_HA] [varchar](250) NULL,
	[Aadharcardno_HB] [varchar](250) NULL,
	[Aadharcardverify_HB] [varchar](250) NULL,
	[Alternativmob_HA] [varchar](20) NULL,
	[Alternativmob_HB] [varchar](20) NULL,
	[Email_HA] [varchar](250) NULL,
	[Email_HB] [varchar](250) NULL,
	[CurrentAdd_HA] [varchar](500) NULL,
	[CurrentAdd_HB] [varchar](500) NULL,
	[IncomeSource_HA] [varchar](300) NULL,
	[IncomeSource_HB] [varchar](300) NULL,
	[empbussname_HA] [varchar](300) NULL,
	[empbussname_HB] [varchar](300) NULL,
	[worktype_HA] [varchar](300) NULL,
	[worktype_HB] [varchar](300) NULL,
	[Incomefrom_HA] [varchar](250) NULL,
	[Incometo_HA] [varchar](250) NULL,
	[Incomefrom_HB] [varchar](250) NULL,
	[Incometo_HB] [varchar](250) NULL,
	[Create_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kycdetail] ON 

INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at]) VALUES (38, N'ABHVAI0652', N'VAISHALI MANJUL', N'135232000652', N'135232000652', N'individual', N'1132456789', N'verify', NULL, NULL, N'198230000176', N'verify', NULL, NULL, N'9137379173', NULL, N'vaishali@gmail.com', NULL, N'vashi', NULL, N'business', NULL, N'testing', NULL, N'FARMING', NULL, N'5 lac', N'15 lac', NULL, NULL, CAST(N'2023-02-15T12:46:13.273' AS DateTime))
INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at]) VALUES (39, N'ABHSAS4057', N'SASI C', N'116201004057', N'116201004057', N'individual', N'198230000176', N'verify', NULL, NULL, N'987654321', N'verify', NULL, NULL, N'9137379173', NULL, N'selvim@gmail.com', NULL, N'hmjhgvktkj', NULL, N'business', NULL, N'testing', NULL, N'MARKETING', NULL, N'1 lac', N'10 lac', NULL, NULL, CAST(N'2023-02-15T15:05:39.640' AS DateTime))
INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at]) VALUES (40, N'ABHSAS4057', N'SASI C', N'116201004057', N'116201004057', N'individual', N'198230000176', N'verify', NULL, NULL, N'987654321', N'verify', NULL, NULL, N'9137379173', NULL, N'selvim@gmail.com', NULL, N'hmjhgvktkj', NULL, N'business', NULL, N'testing', NULL, N'MARKETING', NULL, N'1 lac', N'10 lac', NULL, NULL, CAST(N'2023-02-15T15:05:39.640' AS DateTime))
INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at]) VALUES (41, N'ABHVEL0537', N'VELU L', N'194201000537', N'194201000537', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2023-02-15T15:16:01.543' AS DateTime))
INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at]) VALUES (42, N'ABHKAM1226', N'KAMALA BAI', N'154201001226', N'154201001226', N'individual', N'1132456789', N'verify', NULL, NULL, N'198230000176', N'verify', NULL, NULL, N'9137379173', NULL, N'chnda@gmail.com', NULL, N'jkhgkhjk,', NULL, N'salary', NULL, N'testing', NULL, N'FARMING', NULL, N'2 lac', N'10 lac', NULL, NULL, CAST(N'2023-02-15T15:59:31.680' AS DateTime))
SET IDENTITY_INSERT [dbo].[kycdetail] OFF
GO
ALTER TABLE [dbo].[kycdetail] ADD  DEFAULT (getdate()) FOR [Create_at]
GO
