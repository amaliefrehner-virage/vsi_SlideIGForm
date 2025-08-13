
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2024 17:52:14
-- Generated from EDMX file: C:\vsi_code\git_repos\slideIgForm\SlideIGWebRetry\Models\Model166.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SlideIG_Api];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDBul__4E53A1AA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIGSubTitle] DROP CONSTRAINT [FK__ScenarioI__IDBul__4E53A1AA];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDBul__531856C7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIGSubTitleBullets] DROP CONSTRAINT [FK__ScenarioI__IDBul__531856C7];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDLan__3493CFA7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioInfo] DROP CONSTRAINT [FK__ScenarioI__IDLan__3493CFA7];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSce__339FAB6E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioInfo] DROP CONSTRAINT [FK__ScenarioI__IDSce__339FAB6E];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSce__3B40CD36]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIG] DROP CONSTRAINT [FK__ScenarioI__IDSce__3B40CD36];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSce__4A8310C6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIGTitle] DROP CONSTRAINT [FK__ScenarioI__IDSce__4A8310C6];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSce__4D5F7D71]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIGSubTitle] DROP CONSTRAINT [FK__ScenarioI__IDSce__4D5F7D71];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSce__5224328E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioIGSubTitleBullets] DROP CONSTRAINT [FK__ScenarioI__IDSce__5224328E];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioI__IDSim__3587F3E0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioInfo] DROP CONSTRAINT [FK__ScenarioI__IDSim__3587F3E0];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDBul__41EDCAC5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlideSubTitle] DROP CONSTRAINT [FK__ScenarioS__IDBul__41EDCAC5];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDBul__46B27FE2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlideSubTitleBullets] DROP CONSTRAINT [FK__ScenarioS__IDBul__46B27FE2];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDSce__3864608B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlide] DROP CONSTRAINT [FK__ScenarioS__IDSce__3864608B];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDSce__3E1D39E1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlideTitle] DROP CONSTRAINT [FK__ScenarioS__IDSce__3E1D39E1];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDSce__40F9A68C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlideSubTitle] DROP CONSTRAINT [FK__ScenarioS__IDSce__40F9A68C];
GO
IF OBJECT_ID(N'[dbo].[FK__ScenarioS__IDSce__45BE5BA9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScenarioSlideSubTitleBullets] DROP CONSTRAINT [FK__ScenarioS__IDSce__45BE5BA9];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BulletPoints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BulletPoints];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[Scenario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Scenario];
GO
IF OBJECT_ID(N'[dbo].[ScenarioIG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioIG];
GO
IF OBJECT_ID(N'[dbo].[ScenarioIGSubTitle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioIGSubTitle];
GO
IF OBJECT_ID(N'[dbo].[ScenarioIGSubTitleBullets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioIGSubTitleBullets];
GO
IF OBJECT_ID(N'[dbo].[ScenarioIGTitle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioIGTitle];
GO
IF OBJECT_ID(N'[dbo].[ScenarioInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioInfo];
GO
IF OBJECT_ID(N'[dbo].[ScenarioSlide]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioSlide];
GO
IF OBJECT_ID(N'[dbo].[ScenarioSlideSubTitle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioSlideSubTitle];
GO
IF OBJECT_ID(N'[dbo].[ScenarioSlideSubTitleBullets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioSlideSubTitleBullets];
GO
IF OBJECT_ID(N'[dbo].[ScenarioSlideTitle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScenarioSlideTitle];
GO
IF OBJECT_ID(N'[dbo].[SimulatorType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SimulatorType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BulletPoints'
CREATE TABLE [dbo].[BulletPoints] (
    [IDBulletPoints] int IDENTITY(1,1) NOT NULL,
    [Unicode] nvarchar(10)  NULL,
    [ClassContent] nvarchar(100)  NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [IDLanguage] int IDENTITY(1,1) NOT NULL,
    [LanguageCode] varchar(500)  NULL
);
GO

-- Creating table 'Scenarios'
CREATE TABLE [dbo].[Scenarios] (
    [IDScenario] int  NOT NULL,
    [ScenarioNumber] varchar(500)  NULL
);
GO

-- Creating table 'ScenarioIGs'
CREATE TABLE [dbo].[ScenarioIGs] (
    [IDScenarioIG] int IDENTITY(1,1) NOT NULL,
    [IDScenarioInfo] int  NULL
);
GO

-- Creating table 'ScenarioIGSubTitles'
CREATE TABLE [dbo].[ScenarioIGSubTitles] (
    [IDScenarioIGSubTitle] int IDENTITY(1,1) NOT NULL,
    [IDScenarioIGTitle] int  NULL,
    [IDBulletPoints] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioIGSubTitleBullets'
CREATE TABLE [dbo].[ScenarioIGSubTitleBullets] (
    [IDScenarioIGSubTitleBullets] int IDENTITY(1,1) NOT NULL,
    [IDScenarioIGSubTitle] int  NULL,
    [IDBulletPoints] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioIGTitles'
CREATE TABLE [dbo].[ScenarioIGTitles] (
    [IDScenarioIGTitle] int IDENTITY(1,1) NOT NULL,
    [IDScenarioIG] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioInfoes'
CREATE TABLE [dbo].[ScenarioInfoes] (
    [IDScenarioInfo] int IDENTITY(1,1) NOT NULL,
    [IDScenario] int  NULL,
    [IDLanguage] int  NULL,
    [IDSimulatorType] int  NULL,
    [Title] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioSlides'
CREATE TABLE [dbo].[ScenarioSlides] (
    [IDScenarioSlide] int IDENTITY(1,1) NOT NULL,
    [IDScenarioInfo] int  NULL
);
GO

-- Creating table 'ScenarioSlideSubTitles'
CREATE TABLE [dbo].[ScenarioSlideSubTitles] (
    [IDScenarioSlideSubTitle] int IDENTITY(1,1) NOT NULL,
    [IDScenarioSlideTitle] int  NULL,
    [IDBulletPoints] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioSlideSubTitleBullets'
CREATE TABLE [dbo].[ScenarioSlideSubTitleBullets] (
    [IDScenarioSlideSubTitleBullets] int IDENTITY(1,1) NOT NULL,
    [IDScenarioSlideSubTitle] int  NULL,
    [IDBulletPoints] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ScenarioSlideTitles'
CREATE TABLE [dbo].[ScenarioSlideTitles] (
    [IDScenarioSlideTitle] int IDENTITY(1,1) NOT NULL,
    [IDScenarioSlide] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'SimulatorTypes'
CREATE TABLE [dbo].[SimulatorTypes] (
    [IDSimulatorType] int IDENTITY(1,1) NOT NULL,
    [SimulatorTypeCode] varchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDBulletPoints] in table 'BulletPoints'
ALTER TABLE [dbo].[BulletPoints]
ADD CONSTRAINT [PK_BulletPoints]
    PRIMARY KEY CLUSTERED ([IDBulletPoints] ASC);
GO

-- Creating primary key on [IDLanguage] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([IDLanguage] ASC);
GO

-- Creating primary key on [IDScenario] in table 'Scenarios'
ALTER TABLE [dbo].[Scenarios]
ADD CONSTRAINT [PK_Scenarios]
    PRIMARY KEY CLUSTERED ([IDScenario] ASC);
GO

-- Creating primary key on [IDScenarioIG] in table 'ScenarioIGs'
ALTER TABLE [dbo].[ScenarioIGs]
ADD CONSTRAINT [PK_ScenarioIGs]
    PRIMARY KEY CLUSTERED ([IDScenarioIG] ASC);
GO

-- Creating primary key on [IDScenarioIGSubTitle] in table 'ScenarioIGSubTitles'
ALTER TABLE [dbo].[ScenarioIGSubTitles]
ADD CONSTRAINT [PK_ScenarioIGSubTitles]
    PRIMARY KEY CLUSTERED ([IDScenarioIGSubTitle] ASC);
GO

-- Creating primary key on [IDScenarioIGSubTitleBullets] in table 'ScenarioIGSubTitleBullets'
ALTER TABLE [dbo].[ScenarioIGSubTitleBullets]
ADD CONSTRAINT [PK_ScenarioIGSubTitleBullets]
    PRIMARY KEY CLUSTERED ([IDScenarioIGSubTitleBullets] ASC);
GO

-- Creating primary key on [IDScenarioIGTitle] in table 'ScenarioIGTitles'
ALTER TABLE [dbo].[ScenarioIGTitles]
ADD CONSTRAINT [PK_ScenarioIGTitles]
    PRIMARY KEY CLUSTERED ([IDScenarioIGTitle] ASC);
GO

-- Creating primary key on [IDScenarioInfo] in table 'ScenarioInfoes'
ALTER TABLE [dbo].[ScenarioInfoes]
ADD CONSTRAINT [PK_ScenarioInfoes]
    PRIMARY KEY CLUSTERED ([IDScenarioInfo] ASC);
GO

-- Creating primary key on [IDScenarioSlide] in table 'ScenarioSlides'
ALTER TABLE [dbo].[ScenarioSlides]
ADD CONSTRAINT [PK_ScenarioSlides]
    PRIMARY KEY CLUSTERED ([IDScenarioSlide] ASC);
GO

-- Creating primary key on [IDScenarioSlideSubTitle] in table 'ScenarioSlideSubTitles'
ALTER TABLE [dbo].[ScenarioSlideSubTitles]
ADD CONSTRAINT [PK_ScenarioSlideSubTitles]
    PRIMARY KEY CLUSTERED ([IDScenarioSlideSubTitle] ASC);
GO

-- Creating primary key on [IDScenarioSlideSubTitleBullets] in table 'ScenarioSlideSubTitleBullets'
ALTER TABLE [dbo].[ScenarioSlideSubTitleBullets]
ADD CONSTRAINT [PK_ScenarioSlideSubTitleBullets]
    PRIMARY KEY CLUSTERED ([IDScenarioSlideSubTitleBullets] ASC);
GO

-- Creating primary key on [IDScenarioSlideTitle] in table 'ScenarioSlideTitles'
ALTER TABLE [dbo].[ScenarioSlideTitles]
ADD CONSTRAINT [PK_ScenarioSlideTitles]
    PRIMARY KEY CLUSTERED ([IDScenarioSlideTitle] ASC);
GO

-- Creating primary key on [IDSimulatorType] in table 'SimulatorTypes'
ALTER TABLE [dbo].[SimulatorTypes]
ADD CONSTRAINT [PK_SimulatorTypes]
    PRIMARY KEY CLUSTERED ([IDSimulatorType] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDBulletPoints] in table 'ScenarioIGSubTitles'
ALTER TABLE [dbo].[ScenarioIGSubTitles]
ADD CONSTRAINT [FK__ScenarioI__IDBul__40DA7652]
    FOREIGN KEY ([IDBulletPoints])
    REFERENCES [dbo].[BulletPoints]
        ([IDBulletPoints])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDBul__40DA7652'
CREATE INDEX [IX_FK__ScenarioI__IDBul__40DA7652]
ON [dbo].[ScenarioIGSubTitles]
    ([IDBulletPoints]);
GO

-- Creating foreign key on [IDBulletPoints] in table 'ScenarioIGSubTitleBullets'
ALTER TABLE [dbo].[ScenarioIGSubTitleBullets]
ADD CONSTRAINT [FK__ScenarioI__IDBul__459F2B6F]
    FOREIGN KEY ([IDBulletPoints])
    REFERENCES [dbo].[BulletPoints]
        ([IDBulletPoints])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDBul__459F2B6F'
CREATE INDEX [IX_FK__ScenarioI__IDBul__459F2B6F]
ON [dbo].[ScenarioIGSubTitleBullets]
    ([IDBulletPoints]);
GO

-- Creating foreign key on [IDBulletPoints] in table 'ScenarioSlideSubTitles'
ALTER TABLE [dbo].[ScenarioSlideSubTitles]
ADD CONSTRAINT [FK__ScenarioS__IDBul__34749F6D]
    FOREIGN KEY ([IDBulletPoints])
    REFERENCES [dbo].[BulletPoints]
        ([IDBulletPoints])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDBul__34749F6D'
CREATE INDEX [IX_FK__ScenarioS__IDBul__34749F6D]
ON [dbo].[ScenarioSlideSubTitles]
    ([IDBulletPoints]);
GO

-- Creating foreign key on [IDBulletPoints] in table 'ScenarioSlideSubTitleBullets'
ALTER TABLE [dbo].[ScenarioSlideSubTitleBullets]
ADD CONSTRAINT [FK__ScenarioS__IDBul__3939548A]
    FOREIGN KEY ([IDBulletPoints])
    REFERENCES [dbo].[BulletPoints]
        ([IDBulletPoints])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDBul__3939548A'
CREATE INDEX [IX_FK__ScenarioS__IDBul__3939548A]
ON [dbo].[ScenarioSlideSubTitleBullets]
    ([IDBulletPoints]);
GO

-- Creating foreign key on [IDLanguage] in table 'ScenarioInfoes'
ALTER TABLE [dbo].[ScenarioInfoes]
ADD CONSTRAINT [FK__ScenarioI__IDLan__271AA44F]
    FOREIGN KEY ([IDLanguage])
    REFERENCES [dbo].[Languages]
        ([IDLanguage])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDLan__271AA44F'
CREATE INDEX [IX_FK__ScenarioI__IDLan__271AA44F]
ON [dbo].[ScenarioInfoes]
    ([IDLanguage]);
GO

-- Creating foreign key on [IDLanguage] in table 'ScenarioInfoes'
ALTER TABLE [dbo].[ScenarioInfoes]
ADD CONSTRAINT [FK__ScenarioI__IDSim__280EC888]
    FOREIGN KEY ([IDLanguage])
    REFERENCES [dbo].[Languages]
        ([IDLanguage])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSim__280EC888'
CREATE INDEX [IX_FK__ScenarioI__IDSim__280EC888]
ON [dbo].[ScenarioInfoes]
    ([IDLanguage]);
GO

-- Creating foreign key on [IDScenario] in table 'ScenarioInfoes'
ALTER TABLE [dbo].[ScenarioInfoes]
ADD CONSTRAINT [FK__ScenarioI__IDSce__26268016]
    FOREIGN KEY ([IDScenario])
    REFERENCES [dbo].[Scenarios]
        ([IDScenario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSce__26268016'
CREATE INDEX [IX_FK__ScenarioI__IDSce__26268016]
ON [dbo].[ScenarioInfoes]
    ([IDScenario]);
GO

-- Creating foreign key on [IDScenarioInfo] in table 'ScenarioIGs'
ALTER TABLE [dbo].[ScenarioIGs]
ADD CONSTRAINT [FK__ScenarioI__IDSce__2DC7A1DE]
    FOREIGN KEY ([IDScenarioInfo])
    REFERENCES [dbo].[ScenarioInfoes]
        ([IDScenarioInfo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSce__2DC7A1DE'
CREATE INDEX [IX_FK__ScenarioI__IDSce__2DC7A1DE]
ON [dbo].[ScenarioIGs]
    ([IDScenarioInfo]);
GO

-- Creating foreign key on [IDScenarioIG] in table 'ScenarioIGTitles'
ALTER TABLE [dbo].[ScenarioIGTitles]
ADD CONSTRAINT [FK__ScenarioI__IDSce__3D09E56E]
    FOREIGN KEY ([IDScenarioIG])
    REFERENCES [dbo].[ScenarioIGs]
        ([IDScenarioIG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSce__3D09E56E'
CREATE INDEX [IX_FK__ScenarioI__IDSce__3D09E56E]
ON [dbo].[ScenarioIGTitles]
    ([IDScenarioIG]);
GO

-- Creating foreign key on [IDScenarioIGTitle] in table 'ScenarioIGSubTitles'
ALTER TABLE [dbo].[ScenarioIGSubTitles]
ADD CONSTRAINT [FK__ScenarioI__IDSce__3FE65219]
    FOREIGN KEY ([IDScenarioIGTitle])
    REFERENCES [dbo].[ScenarioIGTitles]
        ([IDScenarioIGTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSce__3FE65219'
CREATE INDEX [IX_FK__ScenarioI__IDSce__3FE65219]
ON [dbo].[ScenarioIGSubTitles]
    ([IDScenarioIGTitle]);
GO

-- Creating foreign key on [IDScenarioIGSubTitle] in table 'ScenarioIGSubTitleBullets'
ALTER TABLE [dbo].[ScenarioIGSubTitleBullets]
ADD CONSTRAINT [FK__ScenarioI__IDSce__44AB0736]
    FOREIGN KEY ([IDScenarioIGSubTitle])
    REFERENCES [dbo].[ScenarioIGSubTitles]
        ([IDScenarioIGSubTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioI__IDSce__44AB0736'
CREATE INDEX [IX_FK__ScenarioI__IDSce__44AB0736]
ON [dbo].[ScenarioIGSubTitleBullets]
    ([IDScenarioIGSubTitle]);
GO

-- Creating foreign key on [IDScenarioInfo] in table 'ScenarioSlides'
ALTER TABLE [dbo].[ScenarioSlides]
ADD CONSTRAINT [FK__ScenarioS__IDSce__2AEB3533]
    FOREIGN KEY ([IDScenarioInfo])
    REFERENCES [dbo].[ScenarioInfoes]
        ([IDScenarioInfo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDSce__2AEB3533'
CREATE INDEX [IX_FK__ScenarioS__IDSce__2AEB3533]
ON [dbo].[ScenarioSlides]
    ([IDScenarioInfo]);
GO

-- Creating foreign key on [IDScenarioSlide] in table 'ScenarioSlideTitles'
ALTER TABLE [dbo].[ScenarioSlideTitles]
ADD CONSTRAINT [FK__ScenarioS__IDSce__30A40E89]
    FOREIGN KEY ([IDScenarioSlide])
    REFERENCES [dbo].[ScenarioSlides]
        ([IDScenarioSlide])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDSce__30A40E89'
CREATE INDEX [IX_FK__ScenarioS__IDSce__30A40E89]
ON [dbo].[ScenarioSlideTitles]
    ([IDScenarioSlide]);
GO

-- Creating foreign key on [IDScenarioSlideTitle] in table 'ScenarioSlideSubTitles'
ALTER TABLE [dbo].[ScenarioSlideSubTitles]
ADD CONSTRAINT [FK__ScenarioS__IDSce__33807B34]
    FOREIGN KEY ([IDScenarioSlideTitle])
    REFERENCES [dbo].[ScenarioSlideTitles]
        ([IDScenarioSlideTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDSce__33807B34'
CREATE INDEX [IX_FK__ScenarioS__IDSce__33807B34]
ON [dbo].[ScenarioSlideSubTitles]
    ([IDScenarioSlideTitle]);
GO

-- Creating foreign key on [IDScenarioSlideSubTitle] in table 'ScenarioSlideSubTitleBullets'
ALTER TABLE [dbo].[ScenarioSlideSubTitleBullets]
ADD CONSTRAINT [FK__ScenarioS__IDSce__38453051]
    FOREIGN KEY ([IDScenarioSlideSubTitle])
    REFERENCES [dbo].[ScenarioSlideSubTitles]
        ([IDScenarioSlideSubTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ScenarioS__IDSce__38453051'
CREATE INDEX [IX_FK__ScenarioS__IDSce__38453051]
ON [dbo].[ScenarioSlideSubTitleBullets]
    ([IDScenarioSlideSubTitle]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------