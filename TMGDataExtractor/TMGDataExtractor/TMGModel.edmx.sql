
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2014 21:30:16
-- Generated from EDMX file: C:\Documents and Settings\Administrator.CIPHER\My Documents\Visual Studio 2010\Projects\TMGDataExtractor\TMGDataExtractor\TMGModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[TMGModelStoreContainer].[person]', 'U') IS NOT NULL
    DROP TABLE [TMGModelStoreContainer].[person];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PER_NO] integer  NOT NULL,
    [FATHER] integer  NULL,
    [MOTHER] integer  NULL,
    [LAST_EDIT] datetime  NOT NULL,
    [DSID] integer  NOT NULL,
    [REF_ID] integer  NULL,
    [REFERENCE] varchar(12)  NULL,
    [SPOULAST] integer  NULL,
    [SCBUFF] varchar(10)  NULL,
    [PBIRTH] varchar(30)  NULL,
    [PDEATH] varchar(30)  NULL,
    [SEX] char(1)  NOT NULL,
    [LIVING] char(1)  NOT NULL,
    [BIRTHORDER] char(2)  NOT NULL,
    [MULTIBIRTH] char(1)  NOT NULL,
    [ADOPTED] char(1)  NOT NULL,
    [ANCE_INT] char(1)  NOT NULL,
    [DESC_INT] char(1)  NOT NULL,
    [RELATE] integer  NULL,
    [RELATEFO] integer  NULL,
    [TT] char(1)  NULL,
    [FLAG1] char(1)  NULL
);
GO

-- Creating table 'SourceTypes'
CREATE TABLE [dbo].[SourceTypes] (
    [RULESET] real  NOT NULL,
    [DSID] integer  NOT NULL,
    [SOURTYPE] integer  NOT NULL,
    [TRANS_TO] integer  NOT NULL,
    [NAME] nchar(66)  NOT NULL,
    [FOOT] nvarchar(8000)  NOT NULL,
    [SHORT] nvarchar(8000)  NOT NULL,
    [BIB] nvarchar(8000)  NOT NULL,
    [CUSTFOOT] nvarchar(8000)  NOT NULL,
    [CUSTSHORT] nvarchar(8000)  NOT NULL,
    [CUSTBIB] nvarchar(8000)  NOT NULL,
    [SAMEAS] integer  NOT NULL,
    [SAMEASMSG] nvarchar(8000)  NOT NULL,
    [PRIMARY] bit  NOT NULL,
    [REMINDERS] nvarchar(8000)  NOT NULL,
    [TT] nchar(1)  NOT NULL,
    [SourceType_ID] integer  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PER_NO] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([PER_NO] ASC);
GO

-- Creating primary key on [SourceType_ID] in table 'SourceTypes'
ALTER TABLE [dbo].[SourceTypes]
ADD CONSTRAINT [PK_SourceTypes]
    PRIMARY KEY CLUSTERED ([SourceType_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------