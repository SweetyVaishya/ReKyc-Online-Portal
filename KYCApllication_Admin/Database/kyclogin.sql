USE [KYCapplication]
GO
/****** Object:  Table [dbo].[kyclogin]    Script Date: 2023-02-21 3:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kyclogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](300) NULL,
	[password] [varchar](300) NULL,
	[craete_at] [datetime] NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kyclogin] ON 

INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (1, N'dfadfs', N'sdfsdfsd', NULL, NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (2, N'akjsdhasjkd', N'sweety12', CAST(N'2023-02-16T15:30:03.067' AS DateTime), NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (3, N'hdbfhdbf', N'sweety12', CAST(N'2023-02-16T17:16:31.880' AS DateTime), NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (4, N'serrr', N'sweety123', CAST(N'2023-02-17T15:25:23.887' AS DateTime), NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (5, N'dgdfgsdfg', N'sdasd', CAST(N'2023-02-17T15:40:50.603' AS DateTime), NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (6, N'dgdfgsdfg', N'sweety12', CAST(N'2023-02-17T15:43:39.283' AS DateTime), NULL)
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status]) VALUES (7, N'hklhjklhk', N'jkbgjk', CAST(N'2023-02-17T16:10:24.587' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[kyclogin] OFF
GO
ALTER TABLE [dbo].[kyclogin] ADD  CONSTRAINT [DF_kyclogin_craete_at]  DEFAULT (getdate()) FOR [craete_at]
GO

select * from [kyclogin]
