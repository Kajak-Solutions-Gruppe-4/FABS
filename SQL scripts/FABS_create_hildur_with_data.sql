USE [dmaa0920_1062965]
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[addresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street_name] [varchar](50) NOT NULL,
	[street_number] [varchar](10) NOT NULL,
	[apartment_number] [varchar](10) NULL,
	[zipcode] [varchar](15) NOT NULL,
	[countries_id] [int] NOT NULL,
 CONSTRAINT [PK_addresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_line]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_line](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookings_id] [int] NOT NULL,
	[items_id] [int] NOT NULL,
 CONSTRAINT [PK_booking_line] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bookings]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bookings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[start_datetime] [datetime] NOT NULL,
	[end_datetime] [datetime] NOT NULL,
	[people_id] [int] NOT NULL,
	[statuses_id] [int] NOT NULL,
 CONSTRAINT [PK_bookings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item_types]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_item_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[organisations_id] [int] NOT NULL,
	[statuses_id] [int] NULL,
	[locations_id] [int] NULL,
	[item_types_id] [int] NOT NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kayak_types]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kayak_types](
	[item_types_id] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[weight_limit] [int] NOT NULL,
	[length_meter] [decimal](4, 2) NOT NULL,
	[person_capacity] [int] NOT NULL,
 CONSTRAINT [PK_kayak_types] PRIMARY KEY CLUSTERED 
(
	[item_types_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pick_location] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[warehouses_id] [int] NULL,
	[people_id] [int] NULL,
	[organisations_id] [int] NOT NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logins]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logins](
	[people_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_logins] PRIMARY KEY CLUSTERED 
(
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[organisation_person]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organisation_person](
	[organisations_id] [int] NOT NULL,
	[person_id] [int] NOT NULL,
 CONSTRAINT [PK_association_person] PRIMARY KEY CLUSTERED 
(
	[organisations_id] ASC,
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[organisations]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organisations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cvr] [varchar](8) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[addresses_id] [int] NOT NULL,
 CONSTRAINT [PK_organisations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[people]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[people](
	[id] [int] NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[telephone_number] [varchar](20) NULL,
	[adresses_id] [int] NOT NULL,
	[is_admin] [bit] NOT NULL,
 CONSTRAINT [PK_people] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statuses]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[category] [varchar](50) NOT NULL,
 CONSTRAINT [PK_statuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[warehouses]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[warehouses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[addresses_id] [int] NOT NULL,
 CONSTRAINT [PK_warehouses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zipcode_country_city]    Script Date: 08-12-2021 13:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipcode_country_city](
	[zipcode] [varchar](15) NOT NULL,
	[countries_id] [int] NOT NULL,
	[city] [varchar](50) NOT NULL,
 CONSTRAINT [PK_zipcode_country_city] PRIMARY KEY CLUSTERED 
(
	[zipcode] ASC,
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[addresses] ON 
GO
INSERT [dbo].[addresses] ([id], [street_name], [street_number], [apartment_number], [zipcode], [countries_id]) VALUES (1, N'Sofiendalsvej', N'60', NULL, N'9000', 1)
GO
INSERT [dbo].[addresses] ([id], [street_name], [street_number], [apartment_number], [zipcode], [countries_id]) VALUES (2, N'Sofiendalsvej', N'65', NULL, N'9000', 1)
GO
SET IDENTITY_INSERT [dbo].[addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[booking_line] ON 
GO
INSERT [dbo].[booking_line] ([id], [bookings_id], [items_id]) VALUES (1, 1, 3)
GO
INSERT [dbo].[booking_line] ([id], [bookings_id], [items_id]) VALUES (2, 1, 5)
GO
SET IDENTITY_INSERT [dbo].[booking_line] OFF
GO
SET IDENTITY_INSERT [dbo].[bookings] ON 
GO
INSERT [dbo].[bookings] ([id], [start_datetime], [end_datetime], [people_id], [statuses_id]) VALUES (1, CAST(N'2021-12-08T14:38:42.590' AS DateTime), CAST(N'2021-12-08T15:38:42.590' AS DateTime), 1, 4)
GO
SET IDENTITY_INSERT [dbo].[bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[countries] ON 
GO
INSERT [dbo].[countries] ([id], [name]) VALUES (1, N'Danmark')
GO
SET IDENTITY_INSERT [dbo].[countries] OFF
GO
SET IDENTITY_INSERT [dbo].[item_types] ON 
GO
INSERT [dbo].[item_types] ([id], [name]) VALUES (1, N'Kayak - A for Awesome')
GO
INSERT [dbo].[item_types] ([id], [name]) VALUES (2, N'Kayak - B for Best')
GO
SET IDENTITY_INSERT [dbo].[item_types] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 
GO
INSERT [dbo].[items] ([id], [organisations_id], [statuses_id], [locations_id], [item_types_id]) VALUES (1, 1, 1, NULL, 1)
GO
INSERT [dbo].[items] ([id], [organisations_id], [statuses_id], [locations_id], [item_types_id]) VALUES (2, 1, 2, NULL, 1)
GO
INSERT [dbo].[items] ([id], [organisations_id], [statuses_id], [locations_id], [item_types_id]) VALUES (3, 1, 3, NULL, 2)
GO
INSERT [dbo].[items] ([id], [organisations_id], [statuses_id], [locations_id], [item_types_id]) VALUES (4, 1, NULL, NULL, 2)
GO
INSERT [dbo].[items] ([id], [organisations_id], [statuses_id], [locations_id], [item_types_id]) VALUES (5, 1, NULL, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[items] OFF
GO
INSERT [dbo].[kayak_types] ([item_types_id], [description], [weight_limit], [length_meter], [person_capacity]) VALUES (1, N'Floats on water', 100, CAST(5.10 AS Decimal(4, 2)), 1)
GO
INSERT [dbo].[kayak_types] ([item_types_id], [description], [weight_limit], [length_meter], [person_capacity]) VALUES (2, N'Floats on water', 80, CAST(4.95 AS Decimal(4, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[locations] ON 
GO
INSERT [dbo].[locations] ([id], [pick_location], [description], [warehouses_id], [people_id], [organisations_id]) VALUES (1, N'Plads 2', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[locations] ([id], [pick_location], [description], [warehouses_id], [people_id], [organisations_id]) VALUES (2, N'Plads 1', NULL, 1, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[logins] ON 
GO
INSERT [dbo].[logins] ([people_id], [email], [password]) VALUES (1, N'test1@test.com', N'1234')
GO
INSERT [dbo].[logins] ([people_id], [email], [password]) VALUES (2, N'test2@test.com', N'1234')
GO
INSERT [dbo].[logins] ([people_id], [email], [password]) VALUES (3, N'test3@test.com', N'1234')
GO
SET IDENTITY_INSERT [dbo].[logins] OFF
GO
INSERT [dbo].[organisation_person] ([organisations_id], [person_id]) VALUES (1, 1)
GO
INSERT [dbo].[organisation_person] ([organisations_id], [person_id]) VALUES (1, 2)
GO
INSERT [dbo].[organisation_person] ([organisations_id], [person_id]) VALUES (1, 3)
GO
SET IDENTITY_INSERT [dbo].[organisations] ON 
GO
INSERT [dbo].[organisations] ([id], [cvr], [name], [addresses_id]) VALUES (1, N'12341234', N'UCN Kajakker', 1)
GO
SET IDENTITY_INSERT [dbo].[organisations] OFF
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [is_admin]) VALUES (1, N'Peter', N'Hahn', N'20202020', 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [is_admin]) VALUES (2, N'Lars', N'Andersen', N'29292929', 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [is_admin]) VALUES (3, N'Rasmus', N'Larsen', N'28282828', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[statuses] ON 
GO
INSERT [dbo].[statuses] ([id], [name], [category]) VALUES (1, N'Ready for use', N'Item')
GO
INSERT [dbo].[statuses] ([id], [name], [category]) VALUES (2, N'Not ready for use', N'Item')
GO
INSERT [dbo].[statuses] ([id], [name], [category]) VALUES (3, N'In use', N'Item')
GO
INSERT [dbo].[statuses] ([id], [name], [category]) VALUES (4, N'Bekræftet', N'Booking')
GO
SET IDENTITY_INSERT [dbo].[statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[warehouses] ON 
GO
INSERT [dbo].[warehouses] ([id], [name], [addresses_id]) VALUES (1, N'Lager 1', 2)
GO
SET IDENTITY_INSERT [dbo].[warehouses] OFF
GO
INSERT [dbo].[zipcode_country_city] ([zipcode], [countries_id], [city]) VALUES (N'9000', 1, N'Aalborg')
GO
/****** Object:  Index [IX_addresses_countries_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_addresses_countries_id] ON [dbo].[addresses]
(
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_addresses_zipcode_country]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_addresses_zipcode_country] ON [dbo].[addresses]
(
	[zipcode] ASC,
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_booking_line_bookings_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_booking_line_bookings_id] ON [dbo].[booking_line]
(
	[bookings_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_booking_line_items_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_booking_line_items_id] ON [dbo].[booking_line]
(
	[items_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_bookings_people_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_bookings_people_id] ON [dbo].[bookings]
(
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_bookings_statuses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_bookings_statuses_id] ON [dbo].[bookings]
(
	[statuses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_association_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_items_association_id] ON [dbo].[items]
(
	[organisations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_item_types_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_items_item_types_id] ON [dbo].[items]
(
	[item_types_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_locations_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_items_locations_id] ON [dbo].[items]
(
	[locations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_statuses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_items_statuses_id] ON [dbo].[items]
(
	[statuses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_organisations_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_locations_organisations_id] ON [dbo].[locations]
(
	[organisations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_people_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_locations_people_id] ON [dbo].[locations]
(
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_warehouses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_locations_warehouses_id] ON [dbo].[locations]
(
	[warehouses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_logins]    Script Date: 08-12-2021 13:39:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_logins] ON [dbo].[logins]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_association_person_person_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_association_person_person_id] ON [dbo].[organisation_person]
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_associations_addresses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_associations_addresses_id] ON [dbo].[organisations]
(
	[addresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_people_adresses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_people_adresses_id] ON [dbo].[people]
(
	[adresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_warehouses_addresses_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_warehouses_addresses_id] ON [dbo].[warehouses]
(
	[addresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_zipcode_country_city_countries_id]    Script Date: 08-12-2021 13:39:41 ******/
CREATE NONCLUSTERED INDEX [IX_zipcode_country_city_countries_id] ON [dbo].[zipcode_country_city]
(
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[addresses]  WITH CHECK ADD  CONSTRAINT [FK_addresses_countries] FOREIGN KEY([countries_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[addresses] CHECK CONSTRAINT [FK_addresses_countries]
GO
ALTER TABLE [dbo].[addresses]  WITH CHECK ADD  CONSTRAINT [FK_addresses_zipcode_country_city1] FOREIGN KEY([zipcode], [countries_id])
REFERENCES [dbo].[zipcode_country_city] ([zipcode], [countries_id])
GO
ALTER TABLE [dbo].[addresses] CHECK CONSTRAINT [FK_addresses_zipcode_country_city1]
GO
ALTER TABLE [dbo].[booking_line]  WITH CHECK ADD  CONSTRAINT [FK_booking_line_bookings] FOREIGN KEY([bookings_id])
REFERENCES [dbo].[bookings] ([id])
GO
ALTER TABLE [dbo].[booking_line] CHECK CONSTRAINT [FK_booking_line_bookings]
GO
ALTER TABLE [dbo].[booking_line]  WITH CHECK ADD  CONSTRAINT [FK_booking_line_items] FOREIGN KEY([items_id])
REFERENCES [dbo].[items] ([id])
GO
ALTER TABLE [dbo].[booking_line] CHECK CONSTRAINT [FK_booking_line_items]
GO
ALTER TABLE [dbo].[bookings]  WITH CHECK ADD  CONSTRAINT [FK_bookings_people] FOREIGN KEY([people_id])
REFERENCES [dbo].[people] ([id])
GO
ALTER TABLE [dbo].[bookings] CHECK CONSTRAINT [FK_bookings_people]
GO
ALTER TABLE [dbo].[bookings]  WITH CHECK ADD  CONSTRAINT [FK_bookings_statuses] FOREIGN KEY([statuses_id])
REFERENCES [dbo].[statuses] ([id])
GO
ALTER TABLE [dbo].[bookings] CHECK CONSTRAINT [FK_bookings_statuses]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_item_types] FOREIGN KEY([item_types_id])
REFERENCES [dbo].[item_types] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_item_types]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_locations] FOREIGN KEY([locations_id])
REFERENCES [dbo].[locations] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_locations]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_organisations] FOREIGN KEY([organisations_id])
REFERENCES [dbo].[organisations] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_organisations]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_statuses] FOREIGN KEY([statuses_id])
REFERENCES [dbo].[statuses] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_statuses]
GO
ALTER TABLE [dbo].[kayak_types]  WITH CHECK ADD  CONSTRAINT [FK_kayak_types_item_types] FOREIGN KEY([item_types_id])
REFERENCES [dbo].[item_types] ([id])
GO
ALTER TABLE [dbo].[kayak_types] CHECK CONSTRAINT [FK_kayak_types_item_types]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_organisations] FOREIGN KEY([organisations_id])
REFERENCES [dbo].[organisations] ([id])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_organisations]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_people] FOREIGN KEY([people_id])
REFERENCES [dbo].[people] ([id])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_people]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_warehouses] FOREIGN KEY([warehouses_id])
REFERENCES [dbo].[warehouses] ([id])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_warehouses]
GO
ALTER TABLE [dbo].[organisation_person]  WITH CHECK ADD  CONSTRAINT [FK_association_person_organisations] FOREIGN KEY([organisations_id])
REFERENCES [dbo].[organisations] ([id])
GO
ALTER TABLE [dbo].[organisation_person] CHECK CONSTRAINT [FK_association_person_organisations]
GO
ALTER TABLE [dbo].[organisation_person]  WITH CHECK ADD  CONSTRAINT [FK_association_person_people] FOREIGN KEY([person_id])
REFERENCES [dbo].[people] ([id])
GO
ALTER TABLE [dbo].[organisation_person] CHECK CONSTRAINT [FK_association_person_people]
GO
ALTER TABLE [dbo].[organisations]  WITH CHECK ADD  CONSTRAINT [FK_organisations_addresses] FOREIGN KEY([addresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[organisations] CHECK CONSTRAINT [FK_organisations_addresses]
GO
ALTER TABLE [dbo].[people]  WITH CHECK ADD  CONSTRAINT [FK_people_addresses] FOREIGN KEY([adresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[people] CHECK CONSTRAINT [FK_people_addresses]
GO
ALTER TABLE [dbo].[people]  WITH CHECK ADD  CONSTRAINT [FK_people_logins1] FOREIGN KEY([id])
REFERENCES [dbo].[logins] ([people_id])
GO
ALTER TABLE [dbo].[people] CHECK CONSTRAINT [FK_people_logins1]
GO
ALTER TABLE [dbo].[warehouses]  WITH CHECK ADD  CONSTRAINT [FK_warehouses_addresses] FOREIGN KEY([addresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[warehouses] CHECK CONSTRAINT [FK_warehouses_addresses]
GO
ALTER TABLE [dbo].[zipcode_country_city]  WITH CHECK ADD  CONSTRAINT [FK_zipcode_country_city_countries] FOREIGN KEY([countries_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[zipcode_country_city] CHECK CONSTRAINT [FK_zipcode_country_city_countries]
GO
