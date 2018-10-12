
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2018 19:14:37
-- Generated from EDMX file: D:\ProfgyanV2\ProfGyanV2\ProfgyanAPI_V2\WebAPI\DataModel\ModelDesign.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProfGyan];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Appointment_dbo_Trainee_TraineeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK_dbo_Appointment_dbo_Trainee_TraineeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Appointment_dbo_Trainers_TrainerId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK_dbo_Appointment_dbo_Trainers_TrainerId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Bid_dbo_Trainee_Trainee_TraineeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bid] DROP CONSTRAINT [FK_dbo_Bid_dbo_Trainee_Trainee_TraineeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Bid_dbo_Trainers_TrainerId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bid] DROP CONSTRAINT [FK_dbo_Bid_dbo_Trainers_TrainerId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Enrollment_dbo_Course_CourseID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enrollment] DROP CONSTRAINT [FK_dbo_Enrollment_dbo_Course_CourseID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_SocialMedia_dbo_TrainerDetails_TrDetailId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SocialMedia] DROP CONSTRAINT [FK_dbo_SocialMedia_dbo_TrainerDetails_TrDetailId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Trainee_dbo_CommonDetails_CommonDetailID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainee] DROP CONSTRAINT [FK_dbo_Trainee_dbo_CommonDetails_CommonDetailID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_TrainerDetails_dbo_Trainers_TrainerId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrainerDetails] DROP CONSTRAINT [FK_dbo_TrainerDetails_dbo_Trainers_TrainerId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Trainers_dbo_CommonDetails_CommonDetailID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainers] DROP CONSTRAINT [FK_dbo_Trainers_dbo_CommonDetails_CommonDetailID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UserClaim_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserClaim] DROP CONSTRAINT [FK_dbo_UserClaim_dbo_User_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UserLogin_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK_dbo_UserLogin_dbo_User_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UserRole_dbo_Role_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_dbo_UserRole_dbo_Role_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UserRole_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_dbo_UserRole_dbo_User_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Appointment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointment];
GO
IF OBJECT_ID(N'[dbo].[Attendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attendance];
GO
IF OBJECT_ID(N'[dbo].[Bid]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bid];
GO
IF OBJECT_ID(N'[dbo].[BookMarks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookMarks];
GO
IF OBJECT_ID(N'[dbo].[Chat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chat];
GO
IF OBJECT_ID(N'[dbo].[CommonDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommonDetails];
GO
IF OBJECT_ID(N'[dbo].[ContactUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactUs];
GO
IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Enrollment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enrollment];
GO
IF OBJECT_ID(N'[dbo].[Feedback]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedback];
GO
IF OBJECT_ID(N'[dbo].[PaymentModes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentModes];
GO
IF OBJECT_ID(N'[dbo].[Rating]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rating];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Session]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Session];
GO
IF OBJECT_ID(N'[dbo].[SocialMedia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SocialMedia];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Subscription]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscription];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Trainee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainee];
GO
IF OBJECT_ID(N'[dbo].[TrainerDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainerDetails];
GO
IF OBJECT_ID(N'[dbo].[Trainers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainers];
GO
IF OBJECT_ID(N'[dbo].[TrainingType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainingType];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserClaim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserClaim];
GO
IF OBJECT_ID(N'[dbo].[UserLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogin];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[ValidationPasscodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValidationPasscodes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [AppointmentId] nvarchar(128)  NOT NULL,
    [Phone] nvarchar(50)  NULL,
    [Message] nvarchar(300)  NULL,
    [TraineeID] nvarchar(128)  NULL,
    [TrainerId] nvarchar(128)  NULL
);
GO

-- Creating table 'Attendances'
CREATE TABLE [dbo].[Attendances] (
    [AttendanceId] nvarchar(128)  NOT NULL,
    [SessionId] nvarchar(128)  NULL,
    [TraineeId] nvarchar(128)  NULL
);
GO

-- Creating table 'Bids'
CREATE TABLE [dbo].[Bids] (
    [BidId] nvarchar(128)  NOT NULL,
    [FixedRate] bit  NOT NULL,
    [FinalBid] bit  NOT NULL,
    [CourseId] nvarchar(max)  NULL,
    [TrainerId] nvarchar(128)  NULL,
    [Trainee_TraineeID] nvarchar(128)  NULL
);
GO

-- Creating table 'BookMarks'
CREATE TABLE [dbo].[BookMarks] (
    [BookmarkId] nvarchar(128)  NOT NULL,
    [CourseId] nvarchar(128)  NULL
);
GO

-- Creating table 'Chats'
CREATE TABLE [dbo].[Chats] (
    [ChatID] nvarchar(128)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Comments] nvarchar(300)  NULL
);
GO

-- Creating table 'CommonDetails'
CREATE TABLE [dbo].[CommonDetails] (
    [ID] nvarchar(128)  NOT NULL,
    [state] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [PINCode] nvarchar(50)  NULL,
    [AcademicYear] datetime  NULL,
    [HighestQualification] nvarchar(50)  NULL,
    [Department] nvarchar(50)  NULL,
    [Grade] nvarchar(50)  NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'ContactUs'
CREATE TABLE [dbo].[ContactUs] (
    [ContactusId] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Mobile] nvarchar(max)  NULL,
    [Message] nvarchar(max)  NULL,
    [Subject] nvarchar(max)  NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseId] nvarchar(128)  NOT NULL,
    [CourseName] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [Logo] varbinary(max)  NULL,
    [StatusId] nvarchar(128)  NULL,
    [URL] nvarchar(max)  NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [DocumentId] nvarchar(128)  NOT NULL,
    [FileName] nvarchar(50)  NULL,
    [FileType] nvarchar(50)  NULL,
    [UserIdentity] nvarchar(50)  NULL
);
GO

-- Creating table 'Enrollments'
CREATE TABLE [dbo].[Enrollments] (
    [EnrollmentId] nvarchar(128)  NOT NULL,
    [TrainerId] nvarchar(128)  NULL,
    [DateEnrolled] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [ModifiedDateTime] datetime  NULL,
    [CourseID] nvarchar(128)  NULL
);
GO

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [FeedbackId] nvarchar(128)  NOT NULL,
    [Comments] nvarchar(max)  NULL,
    [UserId] nvarchar(128)  NULL
);
GO

-- Creating table 'PaymentModes'
CREATE TABLE [dbo].[PaymentModes] (
    [ModeId] nvarchar(128)  NOT NULL,
    [Mode] nvarchar(20)  NULL,
    [StatusId] nvarchar(128)  NULL
);
GO

-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [RatingId] nvarchar(128)  NOT NULL,
    [StarsCount] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [SessionId] nvarchar(128)  NOT NULL,
    [Timing] datetime  NULL,
    [CourseId] nvarchar(128)  NULL
);
GO

-- Creating table 'SocialMedias'
CREATE TABLE [dbo].[SocialMedias] (
    [SocialMediaId] nvarchar(128)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Link] nvarchar(100)  NULL,
    [TrDetailId] nvarchar(128)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [StatusId] nvarchar(128)  NOT NULL,
    [StatusName] nvarchar(50)  NULL
);
GO

-- Creating table 'Subscriptions'
CREATE TABLE [dbo].[Subscriptions] (
    [SubscriptionId] nvarchar(128)  NOT NULL,
    [CourseId] nvarchar(128)  NULL,
    [Comments] nchar(300)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Trainees'
CREATE TABLE [dbo].[Trainees] (
    [TraineeID] nvarchar(128)  NOT NULL,
    [UserID] nvarchar(128)  NULL,
    [AreaOfIntrest] nvarchar(max)  NULL,
    [StatusId] nvarchar(50)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [ModifiedDate] datetime  NULL,
    [CommonDetailID] nvarchar(128)  NULL
);
GO

-- Creating table 'TrainerDetails'
CREATE TABLE [dbo].[TrainerDetails] (
    [TrDetailId] nvarchar(128)  NOT NULL,
    [Experience] nvarchar(300)  NULL,
    [Companies] nvarchar(200)  NULL,
    [SkillSet] nvarchar(300)  NULL,
    [TeachingExperience] nvarchar(300)  NULL,
    [Rewards] nvarchar(300)  NULL,
    [TeachingReason] nvarchar(300)  NULL,
    [TrainerId] nvarchar(128)  NULL
);
GO

-- Creating table 'Trainers'
CREATE TABLE [dbo].[Trainers] (
    [TrainerId] nvarchar(128)  NOT NULL,
    [UserID] nvarchar(128)  NULL,
    [TypeId] int  NULL,
    [RatingId] nvarchar(128)  NULL,
    [StatusId] nvarchar(128)  NULL,
    [IsVerified] bit  NULL,
    [CommonDetailID] nvarchar(128)  NULL
);
GO

-- Creating table 'TrainingTypes'
CREATE TABLE [dbo].[TrainingTypes] (
    [TypeId] nvarchar(128)  NOT NULL,
    [TypeName] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] nvarchar(128)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Address] nvarchar(200)  NOT NULL,
    [SocialMediaId] nvarchar(128)  NULL,
    [SocialMedia_SocialMediaId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'UserClaims'
CREATE TABLE [dbo].[UserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ValidationPasscodes'
CREATE TABLE [dbo].[ValidationPasscodes] (
    [validationElement] nvarchar(128)  NOT NULL,
    [passcode] nvarchar(max)  NULL,
    [createdTime] datetime  NULL,
    [expiryTime] datetime  NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [Roles_Id] nvarchar(128)  NOT NULL,
    [Users_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AppointmentId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([AppointmentId] ASC);
GO

-- Creating primary key on [AttendanceId] in table 'Attendances'
ALTER TABLE [dbo].[Attendances]
ADD CONSTRAINT [PK_Attendances]
    PRIMARY KEY CLUSTERED ([AttendanceId] ASC);
GO

-- Creating primary key on [BidId] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [PK_Bids]
    PRIMARY KEY CLUSTERED ([BidId] ASC);
GO

-- Creating primary key on [BookmarkId] in table 'BookMarks'
ALTER TABLE [dbo].[BookMarks]
ADD CONSTRAINT [PK_BookMarks]
    PRIMARY KEY CLUSTERED ([BookmarkId] ASC);
GO

-- Creating primary key on [ChatID] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [PK_Chats]
    PRIMARY KEY CLUSTERED ([ChatID] ASC);
GO

-- Creating primary key on [ID] in table 'CommonDetails'
ALTER TABLE [dbo].[CommonDetails]
ADD CONSTRAINT [PK_CommonDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ContactusId] in table 'ContactUs'
ALTER TABLE [dbo].[ContactUs]
ADD CONSTRAINT [PK_ContactUs]
    PRIMARY KEY CLUSTERED ([ContactusId] ASC);
GO

-- Creating primary key on [CourseId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [DocumentId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([DocumentId] ASC);
GO

-- Creating primary key on [EnrollmentId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [PK_Enrollments]
    PRIMARY KEY CLUSTERED ([EnrollmentId] ASC);
GO

-- Creating primary key on [FeedbackId] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([FeedbackId] ASC);
GO

-- Creating primary key on [ModeId] in table 'PaymentModes'
ALTER TABLE [dbo].[PaymentModes]
ADD CONSTRAINT [PK_PaymentModes]
    PRIMARY KEY CLUSTERED ([ModeId] ASC);
GO

-- Creating primary key on [RatingId] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [PK_Ratings]
    PRIMARY KEY CLUSTERED ([RatingId] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SessionId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([SessionId] ASC);
GO

-- Creating primary key on [SocialMediaId] in table 'SocialMedias'
ALTER TABLE [dbo].[SocialMedias]
ADD CONSTRAINT [PK_SocialMedias]
    PRIMARY KEY CLUSTERED ([SocialMediaId] ASC);
GO

-- Creating primary key on [StatusId] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([StatusId] ASC);
GO

-- Creating primary key on [SubscriptionId] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [PK_Subscriptions]
    PRIMARY KEY CLUSTERED ([SubscriptionId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TraineeID] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [PK_Trainees]
    PRIMARY KEY CLUSTERED ([TraineeID] ASC);
GO

-- Creating primary key on [TrDetailId] in table 'TrainerDetails'
ALTER TABLE [dbo].[TrainerDetails]
ADD CONSTRAINT [PK_TrainerDetails]
    PRIMARY KEY CLUSTERED ([TrDetailId] ASC);
GO

-- Creating primary key on [TrainerId] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [PK_Trainers]
    PRIMARY KEY CLUSTERED ([TrainerId] ASC);
GO

-- Creating primary key on [TypeId] in table 'TrainingTypes'
ALTER TABLE [dbo].[TrainingTypes]
ADD CONSTRAINT [PK_TrainingTypes]
    PRIMARY KEY CLUSTERED ([TypeId] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserClaims'
ALTER TABLE [dbo].[UserClaims]
ADD CONSTRAINT [PK_UserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [validationElement] in table 'ValidationPasscodes'
ALTER TABLE [dbo].[ValidationPasscodes]
ADD CONSTRAINT [PK_ValidationPasscodes]
    PRIMARY KEY CLUSTERED ([validationElement] ASC);
GO

-- Creating primary key on [Roles_Id], [Users_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([Roles_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TraineeID] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_dbo_Appointment_dbo_Trainee_TraineeID]
    FOREIGN KEY ([TraineeID])
    REFERENCES [dbo].[Trainees]
        ([TraineeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Appointment_dbo_Trainee_TraineeID'
CREATE INDEX [IX_FK_dbo_Appointment_dbo_Trainee_TraineeID]
ON [dbo].[Appointments]
    ([TraineeID]);
GO

-- Creating foreign key on [TrainerId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_dbo_Appointment_dbo_Trainers_TrainerId]
    FOREIGN KEY ([TrainerId])
    REFERENCES [dbo].[Trainers]
        ([TrainerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Appointment_dbo_Trainers_TrainerId'
CREATE INDEX [IX_FK_dbo_Appointment_dbo_Trainers_TrainerId]
ON [dbo].[Appointments]
    ([TrainerId]);
GO

-- Creating foreign key on [Trainee_TraineeID] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [FK_dbo_Bid_dbo_Trainee_Trainee_TraineeID]
    FOREIGN KEY ([Trainee_TraineeID])
    REFERENCES [dbo].[Trainees]
        ([TraineeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Bid_dbo_Trainee_Trainee_TraineeID'
CREATE INDEX [IX_FK_dbo_Bid_dbo_Trainee_Trainee_TraineeID]
ON [dbo].[Bids]
    ([Trainee_TraineeID]);
GO

-- Creating foreign key on [TrainerId] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [FK_dbo_Bid_dbo_Trainers_TrainerId]
    FOREIGN KEY ([TrainerId])
    REFERENCES [dbo].[Trainers]
        ([TrainerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Bid_dbo_Trainers_TrainerId'
CREATE INDEX [IX_FK_dbo_Bid_dbo_Trainers_TrainerId]
ON [dbo].[Bids]
    ([TrainerId]);
GO

-- Creating foreign key on [CommonDetailID] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [FK_dbo_Trainee_dbo_CommonDetails_CommonDetailID]
    FOREIGN KEY ([CommonDetailID])
    REFERENCES [dbo].[CommonDetails]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Trainee_dbo_CommonDetails_CommonDetailID'
CREATE INDEX [IX_FK_dbo_Trainee_dbo_CommonDetails_CommonDetailID]
ON [dbo].[Trainees]
    ([CommonDetailID]);
GO

-- Creating foreign key on [CommonDetailID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [FK_dbo_Trainers_dbo_CommonDetails_CommonDetailID]
    FOREIGN KEY ([CommonDetailID])
    REFERENCES [dbo].[CommonDetails]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Trainers_dbo_CommonDetails_CommonDetailID'
CREATE INDEX [IX_FK_dbo_Trainers_dbo_CommonDetails_CommonDetailID]
ON [dbo].[Trainers]
    ([CommonDetailID]);
GO

-- Creating foreign key on [CourseID] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_dbo_Enrollment_dbo_Course_CourseID]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Enrollment_dbo_Course_CourseID'
CREATE INDEX [IX_FK_dbo_Enrollment_dbo_Course_CourseID]
ON [dbo].[Enrollments]
    ([CourseID]);
GO

-- Creating foreign key on [TrainerId] in table 'TrainerDetails'
ALTER TABLE [dbo].[TrainerDetails]
ADD CONSTRAINT [FK_dbo_TrainerDetails_dbo_Trainers_TrainerId]
    FOREIGN KEY ([TrainerId])
    REFERENCES [dbo].[Trainers]
        ([TrainerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_TrainerDetails_dbo_Trainers_TrainerId'
CREATE INDEX [IX_FK_dbo_TrainerDetails_dbo_Trainers_TrainerId]
ON [dbo].[TrainerDetails]
    ([TrainerId]);
GO

-- Creating foreign key on [UserId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [FK_dbo_UserLogin_dbo_User_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_UserLogin_dbo_User_UserId'
CREATE INDEX [IX_FK_dbo_UserLogin_dbo_User_UserId]
ON [dbo].[UserLogins]
    ([UserId]);
GO

-- Creating foreign key on [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRole]
    ([Users_Id]);
GO

-- Creating foreign key on [UserId] in table 'UserClaims'
ALTER TABLE [dbo].[UserClaims]
ADD CONSTRAINT [FK_UserUserClaim]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserClaim'
CREATE INDEX [IX_FK_UserUserClaim]
ON [dbo].[UserClaims]
    ([UserId]);
GO

-- Creating foreign key on [SocialMedia_SocialMediaId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserSocialMedia]
    FOREIGN KEY ([SocialMedia_SocialMediaId])
    REFERENCES [dbo].[SocialMedias]
        ([SocialMediaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSocialMedia'
CREATE INDEX [IX_FK_UserSocialMedia]
ON [dbo].[Users]
    ([SocialMedia_SocialMediaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------