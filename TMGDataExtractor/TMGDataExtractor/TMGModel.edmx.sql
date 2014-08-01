
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2014 04:09:37
-- Generated from EDMX file: c:\documents and settings\administrator.cipher\my documents\visual studio 2010\Projects\TMGDataExtractor\TMGDataExtractor\TMGModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TMG];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [PER_NO] int IDENTITY(1,1) NOT NULL,
    [FATHER] int  NOT NULL,
    [MOTHER] int  NOT NULL,
    [LAST_EDIT] datetime  NOT NULL,
    [DSID] int  NOT NULL,
    [REF_ID] int  NOT NULL,
    [REFERENCE] nvarchar(max)  NOT NULL,
    [SPOULAST] int  NOT NULL,
    [SCBUFF] nvarchar(max)  NOT NULL,
    [PBIRTH] nvarchar(max)  NOT NULL,
    [PDEATH] nvarchar(max)  NOT NULL,
    [SEX] nvarchar(max)  NOT NULL,
    [BIRTHORDER] nvarchar(max)  NOT NULL,
    [MULTIBIRTH] nvarchar(max)  NOT NULL,
    [ADOPTED] nvarchar(max)  NOT NULL,
    [ANCE_INT] nvarchar(max)  NOT NULL,
    [DESC_INT] nvarchar(max)  NOT NULL,
    [RELATE] int  NOT NULL,
    [RELATEFO] int  NOT NULL,
    [TT] nvarchar(max)  NOT NULL,
    [FLAG1] nvarchar(max)  NOT NULL,
    [LIVING] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PER_NO] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([PER_NO] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------