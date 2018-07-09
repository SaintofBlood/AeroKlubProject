# AeroKlubProject


Baza danych:
Tworzymy ją poprzez Eksplorator serwera , lokalnie. Powinna zawierać odpowiednie tabele:

- Reservations
- Samolots
- Services
- Users

O następujących kodach :

- Reservations

CREATE TABLE [dbo].[Reservations] (
    [ReservationID] INT           IDENTITY (1, 1) NOT NULL,
    [PlaneName]     NVARCHAR (50) NOT NULL,
    [Date]          NVARCHAR (10) NOT NULL,
    [From]          INT           NOT NULL,
    [To]            INT           NOT NULL,
    [By]            NVARCHAR (50) NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED ([ReservationID] ASC)
);

- Samolots

CREATE TABLE [dbo].[Samolots] (
    [PlaneID]         INT            IDENTITY (1, 1) NOT NULL,
    [Nazwa]           NVARCHAR (MAX) NULL,
    [WylataneGodziny] INT            NULL,
    CONSTRAINT [PK_dbo.Samolots] PRIMARY KEY CLUSTERED ([PlaneID] ASC)
);

- Services

CREATE TABLE [dbo].[Services] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Samolot] VARCHAR (20) NOT NULL,
    [Data]    VARCHAR (10) NOT NULL,
    [By]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

- Users

CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (20) NOT NULL,
    [Role]     NVARCHAR (20) NOT NULL,
    [Name]     NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

Przykładowe dane do tabel:

- Reservations

SET IDENTITY_INSERT [dbo].[Reservations] ON
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3209, N'Cessna_150', N'11.07.2018', 4, 17, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3210, N'Cessna_150', N'13.07.2018', 8, 19, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3211, N'Cessna_142', N'12.07.2018', 6, 15, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3212, N'Cessna_150', N'11.07.2018', 0, 2, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3213, N'Cessna_150', N'11.07.2018', 19, 24, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3214, N'Cessna_102', N'12.07.2018', 2, 18, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3215, N'Cessna_142', N'09.07.2018', 2, 18, N'Michał_Kochanowicz')
SET IDENTITY_INSERT [dbo].[Reservations] OFF

- Samolots

SET IDENTITY_INSERT [dbo].[Samolots] ON
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (29, N'Cessna_150', 6652)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (30, N'Cessna_142', 521)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (31, N'Cessna_102', 521)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (32, N'Cessna_221', 521)
SET IDENTITY_INSERT [dbo].[Samolots] OFF

- Services

SET IDENTITY_INSERT [dbo].[Services] ON
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (17, N'BAF1234', N'06.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (25, N'Cessna_150', N'12.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (26, N'Cessna_221', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (27, N'Cessna_150', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (28, N'Cessna_142', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (29, N'Cessna_221', N'12.07.2018', N'Adam_Sachulski')
SET IDENTITY_INSERT [dbo].[Services] OFF

- Users

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Role], [Name]) VALUES (1, N'admin', N'Admin', N'Admin_NAME')
INSERT INTO [dbo].[Users] ([Id], [Username], [Role], [Name]) VALUES (2, N'user', N'User', N'Michał_Kochanowicz')
INSERT INTO [dbo].[Users] ([Id], [Username], [Role], [Name]) VALUES (3, N'mechanic', N'Mechanic', N'Adam_Sachulski')
INSERT INTO [dbo].[Users] ([Id], [Username], [Role], [Name]) VALUES (4, N'user1', N'User', N'Schabowski_Wiktor')
SET IDENTITY_INSERT [dbo].[Users] OFF


Po dodaniu danych , kopujemy connectionstring , i podmieniamy go , w pliku Web.config , w miejscu :

<connectionStrings>
    <add name="EFDbContext"  connectionString="Here" />
  </connectionStrings>

----------------------------------------------------------------------------------------------------------------------------------------

Strona internetowa , działającego projektu : 

http://aeroklub.azurewebsites.net/

Aktualne konta :
L:P
user:user - Rola użytkownika;
mechanic:mechanic - Rola mechanica;
admin:admin - Rola administratora;

Jeżeli dane nie wyświetlają się poprawnie , zalecam tryb "raw"
