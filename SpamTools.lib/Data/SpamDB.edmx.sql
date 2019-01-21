
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2019 14:12:31
-- Generated from EDMX file: C:\Users\38418\Desktop\MailSender\SpamTools.lib\Data\SpamDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpamDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmailListSchedulerTasks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailListSet] DROP CONSTRAINT [FK_EmailListSchedulerTasks];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailListEmail_EmailList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailListEmail] DROP CONSTRAINT [FK_EmailListEmail_EmailList];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailListEmail_Email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailListEmail] DROP CONSTRAINT [FK_EmailListEmail_Email];
GO
IF OBJECT_ID(N'[dbo].[FK_SchedulerTasksServer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServerSet] DROP CONSTRAINT [FK_SchedulerTasksServer];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailListEmailRecipient_EmailList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailListEmailRecipient] DROP CONSTRAINT [FK_EmailListEmailRecipient_EmailList];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailListEmailRecipient_EmailRecipient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailListEmailRecipient] DROP CONSTRAINT [FK_EmailListEmailRecipient_EmailRecipient];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailSenderSchedulerTasks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchedulerTasksSet] DROP CONSTRAINT [FK_EmailSenderSchedulerTasks];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EmailRecipientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailRecipientSet];
GO
IF OBJECT_ID(N'[dbo].[EmailSenderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailSenderSet];
GO
IF OBJECT_ID(N'[dbo].[ServerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServerSet];
GO
IF OBJECT_ID(N'[dbo].[EmailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailSet];
GO
IF OBJECT_ID(N'[dbo].[SchedulerTasksSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchedulerTasksSet];
GO
IF OBJECT_ID(N'[dbo].[EmailListSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailListSet];
GO
IF OBJECT_ID(N'[dbo].[EmailListEmail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailListEmail];
GO
IF OBJECT_ID(N'[dbo].[EmailListEmailRecipient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailListEmailRecipient];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmailRecipientSet'
CREATE TABLE [dbo].[EmailRecipientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmailSenderSet'
CREATE TABLE [dbo].[EmailSenderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ServerSet'
CREATE TABLE [dbo].[ServerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Port] int  NOT NULL,
    [UseSSL] bit  NOT NULL,
    [SchedulerTasks_Id] int  NOT NULL
);
GO

-- Creating table 'EmailSet'
CREATE TABLE [dbo].[EmailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SchedulerTasksSet'
CREATE TABLE [dbo].[SchedulerTasksSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [EmailSender_Id] int  NOT NULL
);
GO

-- Creating table 'EmailListSet'
CREATE TABLE [dbo].[EmailListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Descriptio] nvarchar(max)  NOT NULL,
    [SchedulerTasks_Id] int  NOT NULL
);
GO

-- Creating table 'EmailListEmail'
CREATE TABLE [dbo].[EmailListEmail] (
    [EmailList_Id] int  NOT NULL,
    [Email_Id] int  NOT NULL
);
GO

-- Creating table 'EmailListEmailRecipient'
CREATE TABLE [dbo].[EmailListEmailRecipient] (
    [EmailList_Id] int  NOT NULL,
    [EmailRecipient_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmailRecipientSet'
ALTER TABLE [dbo].[EmailRecipientSet]
ADD CONSTRAINT [PK_EmailRecipientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailSenderSet'
ALTER TABLE [dbo].[EmailSenderSet]
ADD CONSTRAINT [PK_EmailSenderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServerSet'
ALTER TABLE [dbo].[ServerSet]
ADD CONSTRAINT [PK_ServerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailSet'
ALTER TABLE [dbo].[EmailSet]
ADD CONSTRAINT [PK_EmailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SchedulerTasksSet'
ALTER TABLE [dbo].[SchedulerTasksSet]
ADD CONSTRAINT [PK_SchedulerTasksSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailListSet'
ALTER TABLE [dbo].[EmailListSet]
ADD CONSTRAINT [PK_EmailListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EmailList_Id], [Email_Id] in table 'EmailListEmail'
ALTER TABLE [dbo].[EmailListEmail]
ADD CONSTRAINT [PK_EmailListEmail]
    PRIMARY KEY CLUSTERED ([EmailList_Id], [Email_Id] ASC);
GO

-- Creating primary key on [EmailList_Id], [EmailRecipient_Id] in table 'EmailListEmailRecipient'
ALTER TABLE [dbo].[EmailListEmailRecipient]
ADD CONSTRAINT [PK_EmailListEmailRecipient]
    PRIMARY KEY CLUSTERED ([EmailList_Id], [EmailRecipient_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SchedulerTasks_Id] in table 'EmailListSet'
ALTER TABLE [dbo].[EmailListSet]
ADD CONSTRAINT [FK_EmailListSchedulerTasks]
    FOREIGN KEY ([SchedulerTasks_Id])
    REFERENCES [dbo].[SchedulerTasksSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailListSchedulerTasks'
CREATE INDEX [IX_FK_EmailListSchedulerTasks]
ON [dbo].[EmailListSet]
    ([SchedulerTasks_Id]);
GO

-- Creating foreign key on [EmailList_Id] in table 'EmailListEmail'
ALTER TABLE [dbo].[EmailListEmail]
ADD CONSTRAINT [FK_EmailListEmail_EmailList]
    FOREIGN KEY ([EmailList_Id])
    REFERENCES [dbo].[EmailListSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Email_Id] in table 'EmailListEmail'
ALTER TABLE [dbo].[EmailListEmail]
ADD CONSTRAINT [FK_EmailListEmail_Email]
    FOREIGN KEY ([Email_Id])
    REFERENCES [dbo].[EmailSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailListEmail_Email'
CREATE INDEX [IX_FK_EmailListEmail_Email]
ON [dbo].[EmailListEmail]
    ([Email_Id]);
GO

-- Creating foreign key on [SchedulerTasks_Id] in table 'ServerSet'
ALTER TABLE [dbo].[ServerSet]
ADD CONSTRAINT [FK_SchedulerTasksServer]
    FOREIGN KEY ([SchedulerTasks_Id])
    REFERENCES [dbo].[SchedulerTasksSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchedulerTasksServer'
CREATE INDEX [IX_FK_SchedulerTasksServer]
ON [dbo].[ServerSet]
    ([SchedulerTasks_Id]);
GO

-- Creating foreign key on [EmailList_Id] in table 'EmailListEmailRecipient'
ALTER TABLE [dbo].[EmailListEmailRecipient]
ADD CONSTRAINT [FK_EmailListEmailRecipient_EmailList]
    FOREIGN KEY ([EmailList_Id])
    REFERENCES [dbo].[EmailListSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmailRecipient_Id] in table 'EmailListEmailRecipient'
ALTER TABLE [dbo].[EmailListEmailRecipient]
ADD CONSTRAINT [FK_EmailListEmailRecipient_EmailRecipient]
    FOREIGN KEY ([EmailRecipient_Id])
    REFERENCES [dbo].[EmailRecipientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailListEmailRecipient_EmailRecipient'
CREATE INDEX [IX_FK_EmailListEmailRecipient_EmailRecipient]
ON [dbo].[EmailListEmailRecipient]
    ([EmailRecipient_Id]);
GO

-- Creating foreign key on [EmailSender_Id] in table 'SchedulerTasksSet'
ALTER TABLE [dbo].[SchedulerTasksSet]
ADD CONSTRAINT [FK_EmailSenderSchedulerTasks]
    FOREIGN KEY ([EmailSender_Id])
    REFERENCES [dbo].[EmailSenderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailSenderSchedulerTasks'
CREATE INDEX [IX_FK_EmailSenderSchedulerTasks]
ON [dbo].[SchedulerTasksSet]
    ([EmailSender_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------