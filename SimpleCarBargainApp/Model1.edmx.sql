
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/05/2012 15:31:13
-- Generated from EDMX file: C:\Users\Seishin1\Workspace\Visual Studio 2012\Projects\SimpleCarBargainApp\SimpleCarBargainApp\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SimpleCarBargainAppDB];
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

-- Creating table 'BargainAdsSet'
CREATE TABLE [dbo].[BargainAdsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Engine] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [FromDate] nvarchar(max)  NOT NULL,
    [ToDate] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BargainAdsSet'
ALTER TABLE [dbo].[BargainAdsSet]
ADD CONSTRAINT [PK_BargainAdsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------