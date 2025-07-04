USE [Kycapplication_29082023]
GO
/****** Object:  Table [dbo].[TblOmtDetail]    Script Date: 21-08-2024 16:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOmtDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [varchar](15) NULL,
	[Name] [varchar](100) NULL,
	[Mob_no] [varchar](14) NULL,
	[cust_no] [varchar](15) NULL,
	[Address] [varchar](500) NULL,
	[Address2] [varchar](500) NULL,
	[Address3] [varchar](500) NULL,
	[pin_code] [varchar](10) NULL,
	[pancard] [varchar](15) NULL,
	[added_on] [datetime] NULL,
	[Risk] [varchar](500) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblOmtDetail] ON 

INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (300, N'010033300001227', N'CHOUDHARI SAHADEV RAMSAMU', N'7045032052', N'1118738', N'C-302 GODAWARI SOCTY', N'SHANTIVAN', N'BORIVALI (EAST)', N'400067', N'AABPC2515K', CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'High')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (301, N'009033300001549', N'GAWADE ROHIDAS BABAJI', N'7045032052', N'145084', N'A/303 GREENLAND CHS LTD', N'PLOT NO 20 SECTOR NO 40', N'SEAWOODS WEST', N'400706', N'ACLPG7723M', CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'High')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (302, N'042011100001050', N'KHOT SHITALCHANDRA JAYKUMAR', N'7045032052', N'735255', N'A-6, MADHUR CHS,', N'CHINCHOLI BUNDER ROAD,', N'MALAD(WEST), MUMBAI.', N'400064', N'AAFPK1554J', CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'High')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (303, N'011033300001341', N'MANGAONKAR NITYANAND SADANAND', N'7045032052', N'701796', N'B/702,VINAY APT CHSL,', N'CHOGLE NAGAR,BORIVALI EAST,', N'MUMBAI', N'400066', N'ABKPM9093J', CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'High')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (304, N'002011100087787', N'MANISH DIGAMBAR PARKAR', N'7045032052', N'146243', N'A/23, SINDHU TIRTH,', N'NEAR MAKHMALI TALAO, AGRA ROAD,', N'THANE (W)', N'400601', N'AGVPP8286G', CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'High')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (305, N'012033300002882', N'PALSHETKAR AJAY RAKESH', N'7045032052', N'2465940', N'R.NO.1,CHANDRABHAGA HSG.SOC.', N'DILIP GUPTE NAGAR,PARK SITE', N'VIKHRILI-W , MUMBAI', N'400079', N'ARLPP0682R', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Medium')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (306, N'002033300001583', N'RANGALI BUCHAPPA PENTAYYA', N'7045032052', N'1111957', N'29,ABHYUDAYA NAGAR,', N'ROOM NO.4, BAITHICHAWL,', N'KALACHAWOKI.', N'400033', N'ADVPR8644P', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Medium')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (307, N'024033300000497', N'SALIAN PREMNATH SHRINIVAS', N'7045032052', N'412347', N'A 1203 RUSTOMJEE RIVERA', N'FR JUSTIN DSOUZA ROAD', N'OPP BORIVALI BIRYANI HOTEL MALAD W', N'400064', N'AANPS1239G', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Medium')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (308, N'002011100043469', N'SANDEEP SITARAM GHANDAT', N'7045032052', N'975242', N'FLAT NO 3101 AND 3102 31ST FLOOR', N'KINGSTON TOWER KALEWADI', N'G D AMBEKAR MARG KALACHOWKI', N'400033', N'AABPG2810K', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Medium')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (309, N'009033300001068', N'SANSARE SHYAM VILAS', N'7045032052', N'93613', N'36-PIPWALA BLDG', N'SARDAR BALWANTSING DHODI MARG', N'MAGAGOAN', N'400010', N'AAGPS4842N', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Low')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (310, N'010011100005746', N'TAURO LANCELOT RONALD', N'7045032052', N'517671', N'A-403, SHREE BLUE DIAMOND CHS LTD', N'OFF LAXMAN MHATRE ROAD, NEAR', N'SJBCN SCHOOL DAHISAR (W)', N'400068', N'AAAPT5954E', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Low')
INSERT [dbo].[TblOmtDetail] ([id], [AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk]) VALUES (311, N'011085960001341', N'Test from chic', N'7045032052', N'956874', N'A/23, SINDHU TIRTH,', N'NEAR MAKHMALI TALAO, AGRA ROAD,', N'THANE (W)', N'400601', N'AABCC5995L', CAST(N'2023-08-05T00:00:00.000' AS DateTime), N'Low')
SET IDENTITY_INSERT [dbo].[TblOmtDetail] OFF
GO
ALTER TABLE [dbo].[TblOmtDetail] ADD  DEFAULT (getdate()) FOR [added_on]
GO
