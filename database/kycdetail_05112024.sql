USE [KYCapplication_new_280823]
GO
/****** Object:  Table [dbo].[kycdetail]    Script Date: 5 Nov 2024 2:57:40 pm ******/
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
	[status] [nchar](10) NULL,
	[create_date] [date] NULL,
	[reply_date] [date] NULL,
	[YearsOfServiceBusinessHA] [varchar](50) NULL,
	[YearsOfServiceBusinessHB] [varchar](50) NULL,
	[ConsentLetterHA] [varchar](300) NULL,
	[ConsentLetterHB] [varchar](300) NULL,
	[Reasons] [varchar](250) NULL,
	[cust_no] [varchar](100) NULL,
	[PancardFileNm] [varchar](1000) NULL,
	[AadharcardFileNm] [varchar](1000) NULL,
	[approved_by] [varchar](500) NULL,
	[AuthorizeAadhar] [varchar](500) NULL,
	[AuthorizationTitle] [varchar](5000) NULL,
	[AuthorizePan] [varchar](500) NULL,
	[AuthorizationTitlePan] [varchar](5000) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kycdetail] ON 

INSERT [dbo].[kycdetail] ([id], [Kycid], [Name], [acoount_no], [mobail_no], [accout_type], [pancardno_HA], [pancardverify_HA], [pancardno_HB], [pancardverify_HB], [Aadharcardno_HA], [Aadharcardverify_HA], [Aadharcardno_HB], [Aadharcardverify_HB], [Alternativmob_HA], [Alternativmob_HB], [Email_HA], [Email_HB], [CurrentAdd_HA], [CurrentAdd_HB], [IncomeSource_HA], [IncomeSource_HB], [empbussname_HA], [empbussname_HB], [worktype_HA], [worktype_HB], [Incomefrom_HA], [Incometo_HA], [Incomefrom_HB], [Incometo_HB], [Create_at], [status], [create_date], [reply_date], [YearsOfServiceBusinessHA], [YearsOfServiceBusinessHB], [ConsentLetterHA], [ConsentLetterHB], [Reasons], [cust_no], [PancardFileNm], [AadharcardFileNm], [approved_by], [AuthorizeAadhar], [AuthorizationTitle], [AuthorizePan], [AuthorizationTitlePan]) VALUES (17, N'KYCTES3635', N'Test from chic', N'011085960001341', N'9137379173', N'individual', N'AABCC5995L', N'verified', NULL, NULL, N'595687090325', N'verified', NULL, NULL, N'9137379173', NULL, N'chic@gmail.com', NULL, N'D-448 vashi plaza , sector 17 vashi,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2024-11-05T11:54:00.380' AS DateTime), N'          ', NULL, NULL, N'10', NULL, N'I, the holder of Aadhaar No.xxxx xxxx 0325, hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.', NULL, NULL, N'956874', N'', N'', NULL, N'No', N'Do you want to upload latest Aadhaar Card for updating the OVDs in the Bank ? : ', N'No', N'Kindly update my PAN number in bank records as per attached PAN card details : ')
SET IDENTITY_INSERT [dbo].[kycdetail] OFF
GO
ALTER TABLE [dbo].[kycdetail] ADD  DEFAULT (getdate()) FOR [Create_at]
GO
