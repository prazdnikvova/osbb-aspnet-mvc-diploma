-- Схема бази ОСББ «Наш дім» (SQL Server LocalDB), довідковий скрипт.
--
-- Таблиці створює Entity Framework 6 Code First під час першого звернення до
-- контекстів (міграції не ввімкнено), тому запускати цей скрипт не потрібно.
-- Він лише показує, яку схему EF будує за моделями проєкту:
--   HouseContext         (OSBB-N/Common)     -> Flats, Residents
--   ApplicationDbContext (OSBB-N/Models)     -> таблиці ASP.NET Identity 2.2 (AspNet*)
-- Обидва контексти працюють з однією базою (рядок підключення DefaultConnection).
-- Окрім цих таблиць EF створює службову таблицю __MigrationHistory зі знімком моделі.
--
-- Таблицю Residents додано в жовтні 2018. Базу, створену раніше, треба перестворити:
-- EF порівнює модель зі знімком у __MigrationHistory і без міграцій не додає нові
-- таблиці до наявної бази (див. README, розділ «Запуск»).


-- ---------------------------------------------------------------------------
-- HouseContext
-- ---------------------------------------------------------------------------

CREATE TABLE [dbo].[Flats] (
    [FlatId]          INT            IDENTITY (1, 1) NOT NULL,
    [FlatName]        NVARCHAR (MAX) NULL,      -- мобільний телефон власника
    [FlatIp1]         BIGINT         NOT NULL,  -- податковий номер
    [Pib]             NVARCHAR (MAX) NULL,      -- ПІБ власника
    [Address]         NVARCHAR (MAX) NULL,
    [PhoneNumber]     NVARCHAR (MAX) NULL,      -- домашній телефон
    [AreaMetr]        INT            NOT NULL,  -- площа квартири
    [CostMetr]        INT            NOT NULL,  -- ціна за метр
    [CostMetr2]       INT            NOT NULL,  -- у формах не використовується
    [CostOll]         INT            NOT NULL,  -- оплата всього
    [CostSubsidy]     INT            NOT NULL,
    [CostPrivilege75] INT            NOT NULL,
    [CostPrivilege50] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Flats] PRIMARY KEY CLUSTERED ([FlatId] ASC)
);
GO

CREATE TABLE [dbo].[Residents] (
    [ResidentId]  INT            IDENTITY (1, 1) NOT NULL,
    [Pib]         NVARCHAR (150) NOT NULL,
    [FlatId]      INT            NOT NULL,
    [PhoneNumber] NVARCHAR (20)  NULL,
    [Email]       NVARCHAR (100) NULL,
    [IsOwner]     BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Residents] PRIMARY KEY CLUSTERED ([ResidentId] ASC),
    -- зв'язок обов'язковий, тому EF вмикає каскадне видалення:
    -- разом із квартирою видаляються і її мешканці
    CONSTRAINT [FK_dbo.Residents_dbo.Flats_FlatId] FOREIGN KEY ([FlatId])
        REFERENCES [dbo].[Flats] ([FlatId]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_FlatId] ON [dbo].[Residents] ([FlatId] ASC);
GO


-- ---------------------------------------------------------------------------
-- ApplicationDbContext: стандартні таблиці ASP.NET Identity 2.2
-- ---------------------------------------------------------------------------

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] ([Name] ASC);
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers] ([UserName] ASC);
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId])
        REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims] ([UserId] ASC);
GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId])
        REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins] ([UserId] ASC);
GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId])
        REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId])
        REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles] ([RoleId] ASC);
GO
