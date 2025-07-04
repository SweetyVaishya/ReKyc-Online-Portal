USE [KYCapplication]
GO
/****** Object:  Table [dbo].[otp]    Script Date: 2/15/2023 4:08:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[otp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mobile] [varchar](255) NULL,
	[otp_gen] [varchar](500) NULL,
	[otp_receive] [int] NULL,
	[status] [int] NULL,
	[created_at] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[otp] ON 

INSERT [dbo].[otp] ([id], [mobile], [otp_gen], [otp_receive], [status], [created_at]) VALUES (1, N'116201004057', N'902802', NULL, 2, CAST(N'2023-02-15T15:03:39.160' AS DateTime))
INSERT [dbo].[otp] ([id], [mobile], [otp_gen], [otp_receive], [status], [created_at]) VALUES (2, N'116201004057', N'363485', NULL, 2, CAST(N'2023-02-15T15:04:13.160' AS DateTime))
INSERT [dbo].[otp] ([id], [mobile], [otp_gen], [otp_receive], [status], [created_at]) VALUES (3, N'194201000537', N'231803', NULL, 2, CAST(N'2023-02-15T15:16:01.547' AS DateTime))
INSERT [dbo].[otp] ([id], [mobile], [otp_gen], [otp_receive], [status], [created_at]) VALUES (4, N'154201001226', N'862782', NULL, 2, CAST(N'2023-02-15T15:54:55.347' AS DateTime))
SET IDENTITY_INSERT [dbo].[otp] OFF
GO
ALTER TABLE [dbo].[otp] ADD  DEFAULT (getdate()) FOR [created_at]
GO
