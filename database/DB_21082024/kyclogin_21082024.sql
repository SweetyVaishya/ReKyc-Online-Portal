USE [Kycapplication_29082023]
GO
/****** Object:  Table [dbo].[kyclogin]    Script Date: 21-08-2024 16:12:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kyclogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](300) NULL,
	[password] [varchar](300) NULL,
	[craete_at] [datetime] NULL,
	[status] [nvarchar](50) NULL,
	[name] [varchar](200) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kyclogin] ON 

INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status], [name]) VALUES (8, N'abhadmin', N'kycabh@2022', CAST(N'2023-02-17T15:25:23.887' AS DateTime), N'SuperAdmin', N'Abhyudaya bank')
INSERT [dbo].[kyclogin] ([id], [username], [password], [craete_at], [status], [name]) VALUES (2, N'chicadmin', N'Roshan@123', CAST(N'2023-02-16T15:30:03.067' AS DateTime), N'SuperAdmin', N'Chic Infotech')
SET IDENTITY_INSERT [dbo].[kyclogin] OFF
GO
