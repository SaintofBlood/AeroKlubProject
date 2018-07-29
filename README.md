# AeroKlubProject

This is a system project for managing an example aeroclub.
- Made using ASP.NET MVC.
- The library used for styling is Bootstrap ver.4
- Project is using NoUiSlider , wNumb and bootstrap-datepicker.

## Working functions:

 - Booking flights
 - Functions detecting the lack of reservation
 - Adding and removing: aircraft, reservations, mechanics and aircraft inspections
 - User creation
 - Login panel
 - Encryption of user passwords
 - Displaying flight history
 

## Database
We create it through the server explorer, locally. It should contain the appropriate tables:

- Reservations
- Samolots
- Services
- Users

The following codes:

#### Reservations


 ```
 CREATE TABLE [dbo].[Reservations] (
    [ReservationID] INT           IDENTITY (1, 1) NOT NULL,
    [PlaneName]     NVARCHAR (50) NOT NULL,
    [Date]          NVARCHAR (10) NOT NULL,
    [From]          INT           NOT NULL,
    [To]            INT           NOT NULL,
    [By]            NVARCHAR (50) NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED ([ReservationID] ASC)
); 
```

#### Samolots


```
CREATE TABLE [dbo].[Samolots] (
    [PlaneID]         INT            IDENTITY (1, 1) NOT NULL,
    [Nazwa]           NVARCHAR (MAX) NULL,
    [WylataneGodziny] INT            NULL,
    CONSTRAINT [PK_dbo.Samolots] PRIMARY KEY CLUSTERED ([PlaneID] ASC)
);
```

#### Services


```
CREATE TABLE [dbo].[Services] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Samolot] VARCHAR (20) NOT NULL,
    [Data]    VARCHAR (10) NOT NULL,
    [By]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

#### Users


```
CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (20)  NULL,
    [Name]         NVARCHAR (40)  NULL,
    [Password]     NVARCHAR (120) NULL,
    [VCode]        NVARCHAR (100) NULL,
    [Email]        NVARCHAR (40)  NULL,
    [Role]         NVARCHAR (20)  NULL,
    [CreationDate] NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```




Sample data for tables:



#### Reservations


```
SET IDENTITY_INSERT [dbo].[Reservations] ON
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3209, N'Cessna_150', N'11.07.2018', 4, 17, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3210, N'Cessna_150', N'13.07.2018', 8, 19, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3211, N'Cessna_142', N'12.07.2018', 6, 15, N'Admin_NAME')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3212, N'Cessna_150', N'11.07.2018', 0, 2, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3213, N'Cessna_150', N'11.07.2018', 19, 24, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3214, N'Cessna_102', N'12.07.2018', 2, 18, N'Michał_Kochanowicz')
INSERT INTO [dbo].[Reservations] ([ReservationID], [PlaneName], [Date], [From], [To], [By]) VALUES (3215, N'Cessna_142', N'09.07.2018', 2, 18, N'Michał_Kochanowicz')
SET IDENTITY_INSERT [dbo].[Reservations] OFF
```
#### Samolots


```
SET IDENTITY_INSERT [dbo].[Samolots] ON
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (29, N'Cessna_150', 6652)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (30, N'Cessna_142', 521)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (31, N'Cessna_102', 521)
INSERT INTO [dbo].[Samolots] ([PlaneID], [Nazwa], [WylataneGodziny]) VALUES (32, N'Cessna_221', 521)
SET IDENTITY_INSERT [dbo].[Samolots] OFF
```
#### Services


```
SET IDENTITY_INSERT [dbo].[Services] ON
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (17, N'BAF1234', N'06.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (25, N'Cessna_150', N'12.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (26, N'Cessna_221', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (27, N'Cessna_150', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (28, N'Cessna_142', N'10.07.2018', N'Adam_Sachulski')
INSERT INTO [dbo].[Services] ([Id], [Samolot], [Data], [By]) VALUES (29, N'Cessna_221', N'12.07.2018', N'Adam_Sachulski')
SET IDENTITY_INSERT [dbo].[Services] OFF
```
#### Users


```
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Name], [Password], [VCode], [Email], [Role], [CreationDate]) VALUES (24, N'admin', N'Admin_Account', N'50-6F-E9-AD-12-DB-A0-1F-3E-30-B8-0F-B1-EF-52-38', N'oqF10UYi29', N'admin@gmail.com', N'Admin', NULL)
INSERT INTO [dbo].[Users] ([Id], [Username], [Name], [Password], [VCode], [Email], [Role], [CreationDate]) VALUES (33, N'user', N'Jan_Kowalski', N'64-A7-06-19-43-4A-86-FF-12-97-3A-C0-3D-1E-AB-29', N'si4Onod412', N'user@gmail.com', N'User', NULL)
INSERT INTO [dbo].[Users] ([Id], [Username], [Name], [Password], [VCode], [Email], [Role], [CreationDate]) VALUES (34, N'mechanic', N'Adam_Sachulski', N'D3-31-A3-41-22-7F-B0-0B-57-19-A4-4F-B2-F3-2F-85', N'Lzbsdbg0Go', N'mechanic@gmail.com', N'Mechanic', NULL)
INSERT INTO [dbo].[Users] ([Id], [Username], [Name], [Password], [VCode], [Email], [Role], [CreationDate]) VALUES (40, N'user1', N'Janek_Kowalski', N'E6-81-0A-C3-CD-9A-AD-58-30-5E-FB-0A-20-72-C3-93', N'8W9W5Efygc', N'JanekKowalski@gmail.com', N'User', N'13.07.2018')
SET IDENTITY_INSERT [dbo].[Users] OFF
```
## VERY IMPORTANT!

If the user database will not work (data), you have to manually add 3 users from the login level, after which one should give Role = "Admin" and then , thru admin panel we can add a mechanic role .

After adding the data, we copy connectionstring, and replace it in the Web.config file, in the place:

   ``` <add name="EFDbContext"  connectionString="Here" /> ```

### Login accounts implemented immediately in the project with database

Current accounts:
```
L:P
user: user - User role;
mechanic: mechanic - The role of mechanics;
admin: admin - Admin role;
user1: user1 - User role
```
