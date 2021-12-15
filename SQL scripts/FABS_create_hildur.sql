USE [dmaa0920_1062965]
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[booking_line]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[bookings]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[countries]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[item_types]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[kayak_types]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[locations]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[logins]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[organisation_person]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[organisations]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[people]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[statuses]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[warehouses]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Table [dbo].[zipcode_country_city]    Script Date: 08-12-2021 12:57:03 ******/
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
/****** Object:  Index [IX_addresses_countries_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_addresses_countries_id] ON [dbo].[addresses]
(
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_addresses_zipcode_country]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_addresses_zipcode_country] ON [dbo].[addresses]
(
	[zipcode] ASC,
	[countries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_booking_line_bookings_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_booking_line_bookings_id] ON [dbo].[booking_line]
(
	[bookings_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_booking_line_items_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_booking_line_items_id] ON [dbo].[booking_line]
(
	[items_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_bookings_people_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_bookings_people_id] ON [dbo].[bookings]
(
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_bookings_statuses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_bookings_statuses_id] ON [dbo].[bookings]
(
	[statuses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_association_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_items_association_id] ON [dbo].[items]
(
	[organisations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_item_types_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_items_item_types_id] ON [dbo].[items]
(
	[item_types_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_locations_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_items_locations_id] ON [dbo].[items]
(
	[locations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_items_statuses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_items_statuses_id] ON [dbo].[items]
(
	[statuses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_organisations_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_locations_organisations_id] ON [dbo].[locations]
(
	[organisations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_people_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_locations_people_id] ON [dbo].[locations]
(
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_locations_warehouses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_locations_warehouses_id] ON [dbo].[locations]
(
	[warehouses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_logins]    Script Date: 08-12-2021 12:57:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_logins] ON [dbo].[logins]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_association_person_person_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_association_person_person_id] ON [dbo].[organisation_person]
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_associations_addresses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_associations_addresses_id] ON [dbo].[organisations]
(
	[addresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_people_adresses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_people_adresses_id] ON [dbo].[people]
(
	[adresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_warehouses_addresses_id]    Script Date: 08-12-2021 12:57:03 ******/
CREATE NONCLUSTERED INDEX [IX_warehouses_addresses_id] ON [dbo].[warehouses]
(
	[addresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_zipcode_country_city_countries_id]    Script Date: 08-12-2021 12:57:03 ******/
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
