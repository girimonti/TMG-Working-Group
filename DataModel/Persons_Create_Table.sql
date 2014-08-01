USE [TMG]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 08/02/2014 04:16:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[PER_NO] [int] IDENTITY(1,1) NOT NULL,
	[FATHER] [int] NOT NULL,
	[MOTHER] [int] NOT NULL,
	[LAST_EDIT] [datetime] NOT NULL,
	[DSID] [int] NOT NULL,
	[REF_ID] [int] NOT NULL,
	[REFERENCE] [nvarchar](12) NOT NULL,
	[SPOULAST] [int] NOT NULL,
	[SCBUFF] [nvarchar](10) NOT NULL,
	[PBIRTH] [nvarchar](30) NOT NULL,
	[PDEATH] [nvarchar](30) NOT NULL,
	[SEX] [nvarchar](1) NOT NULL,
	[LIVING] [nvarchar](1) NOT NULL,
	[BIRTHORDER] [nvarchar](2) NOT NULL,
	[MULTIBIRTH] [nvarchar](1) NOT NULL,
	[ADOPTED] [nvarchar](1) NOT NULL,
	[ANCE_INT] [nvarchar](1) NOT NULL,
	[DESC_INT] [nvarchar](1) NOT NULL,
	[RELATE] [int] NOT NULL,
	[RELATEFO] [int] NOT NULL,
	[TT] [nvarchar](1) NOT NULL,
	[FLAG1] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PER_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

