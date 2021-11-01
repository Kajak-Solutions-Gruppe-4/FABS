USE dmaa0920_1062965
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[addresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street_name] [varchar](50) NOT NULL,
	[street_number] [varchar](10) NOT NULL,
	[apartment_number] [varchar](10) NULL,
	[zipcode] [varchar](15) NULL,
	[country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_addresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[association_person]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[association_person](
	[associations_id] [int] NOT NULL,
	[people_id] [int] NOT NULL,
 CONSTRAINT [PK_association_person] PRIMARY KEY CLUSTERED 
(
	[associations_id] ASC,
	[people_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[association_warehouse]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[association_warehouse](
	[associations_id] [int] NOT NULL,
	[warehouses_id] [int] NOT NULL,
 CONSTRAINT [PK_association_warehouse] PRIMARY KEY CLUSTERED 
(
	[associations_id] ASC,
	[warehouses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[associations]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[associations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cvr] [varchar](8) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[addresses_id] [int] NOT NULL,
 CONSTRAINT [PK_associations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_line]    Script Date: 31-10-2021 16:22:02 ******/
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
/****** Object:  Table [dbo].[bookings]    Script Date: 31-10-2021 16:22:02 ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[association_id] [int] NOT NULL,
	[statuses_id] [int] NOT NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kayak_types]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kayak_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[weight_limit] [int] NOT NULL,
	[length_meter] [decimal](4, 2) NOT NULL,
	[person_capacity] [int] NOT NULL,
 CONSTRAINT [PK_kayak_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kayaks]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kayaks](
	[items_id] [int] NOT NULL,
	[serial] [varchar](50) NOT NULL,
	[kayak_types_id] [int] NOT NULL,
	[locations_id] [int] NOT NULL,
 CONSTRAINT [PK_kayaks] PRIMARY KEY CLUSTERED 
(
	[items_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pick_location] [varchar](50) NOT NULL,
	[is_in_use] [bit] NOT NULL,
	[description] [varchar](max) NULL,
	[warehouses_id] [int] NOT NULL,
	[people_id] [int] NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logins]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_logins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[people]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[people](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[telephone_number] [varchar](20) NULL,
	[adresses_id] [int] NOT NULL,
	[logins_id] [int] NOT NULL,
	[is_admin] [bit] NOT NULL,
 CONSTRAINT [PK_people] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statuses]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_statuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[warehouses]    Script Date: 31-10-2021 16:22:02 ******/
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
/****** Object:  Table [dbo].[zipcode_country_city]    Script Date: 31-10-2021 16:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipcode_country_city](
	[zipcode] [varchar](15) NOT NULL,
	[country] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
 CONSTRAINT [PK_zipcode_country_city] PRIMARY KEY CLUSTERED 
(
	[zipcode] ASC,
	[country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_logins]    Script Date: 31-10-2021 16:22:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_logins] ON [dbo].[logins]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[addresses]  WITH CHECK ADD  CONSTRAINT [FK_addresses_zipcode_country_city] FOREIGN KEY([zipcode], [country])
REFERENCES [dbo].[zipcode_country_city] ([zipcode], [country])
GO
ALTER TABLE [dbo].[addresses] CHECK CONSTRAINT [FK_addresses_zipcode_country_city]
GO
ALTER TABLE [dbo].[association_person]  WITH CHECK ADD  CONSTRAINT [FK_association_person_associations] FOREIGN KEY([associations_id])
REFERENCES [dbo].[associations] ([id])
GO
ALTER TABLE [dbo].[association_person] CHECK CONSTRAINT [FK_association_person_associations]
GO
ALTER TABLE [dbo].[association_person]  WITH CHECK ADD  CONSTRAINT [FK_association_person_people] FOREIGN KEY([people_id])
REFERENCES [dbo].[people] ([id])
GO
ALTER TABLE [dbo].[association_person] CHECK CONSTRAINT [FK_association_person_people]
GO
ALTER TABLE [dbo].[association_warehouse]  WITH CHECK ADD  CONSTRAINT [FK_association_warehouse_associations] FOREIGN KEY([associations_id])
REFERENCES [dbo].[associations] ([id])
GO
ALTER TABLE [dbo].[association_warehouse] CHECK CONSTRAINT [FK_association_warehouse_associations]
GO
ALTER TABLE [dbo].[association_warehouse]  WITH CHECK ADD  CONSTRAINT [FK_association_warehouse_warehouses] FOREIGN KEY([warehouses_id])
REFERENCES [dbo].[warehouses] ([id])
GO
ALTER TABLE [dbo].[association_warehouse] CHECK CONSTRAINT [FK_association_warehouse_warehouses]
GO
ALTER TABLE [dbo].[associations]  WITH CHECK ADD  CONSTRAINT [FK_associations_addresses] FOREIGN KEY([addresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[associations] CHECK CONSTRAINT [FK_associations_addresses]
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
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_associations] FOREIGN KEY([association_id])
REFERENCES [dbo].[associations] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_associations]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_kayaks] FOREIGN KEY([id])
REFERENCES [dbo].[kayaks] ([items_id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_kayaks]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_statuses] FOREIGN KEY([statuses_id])
REFERENCES [dbo].[statuses] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_statuses]
GO
ALTER TABLE [dbo].[kayaks]  WITH CHECK ADD  CONSTRAINT [FK_kayaks_kayak_types] FOREIGN KEY([kayak_types_id])
REFERENCES [dbo].[kayak_types] ([id])
GO
ALTER TABLE [dbo].[kayaks] CHECK CONSTRAINT [FK_kayaks_kayak_types]
GO
ALTER TABLE [dbo].[kayaks]  WITH CHECK ADD  CONSTRAINT [FK_kayaks_locations] FOREIGN KEY([locations_id])
REFERENCES [dbo].[locations] ([id])
GO
ALTER TABLE [dbo].[kayaks] CHECK CONSTRAINT [FK_kayaks_locations]
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
ALTER TABLE [dbo].[people]  WITH CHECK ADD  CONSTRAINT [FK_people_addresses] FOREIGN KEY([adresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[people] CHECK CONSTRAINT [FK_people_addresses]
GO
ALTER TABLE [dbo].[people]  WITH CHECK ADD  CONSTRAINT [FK_people_logins] FOREIGN KEY([logins_id])
REFERENCES [dbo].[logins] ([id])
GO
ALTER TABLE [dbo].[people] CHECK CONSTRAINT [FK_people_logins]
GO
ALTER TABLE [dbo].[warehouses]  WITH CHECK ADD  CONSTRAINT [FK_warehouses_addresses] FOREIGN KEY([addresses_id])
REFERENCES [dbo].[addresses] ([id])
GO
ALTER TABLE [dbo].[warehouses] CHECK CONSTRAINT [FK_warehouses_addresses]
GO
USE [master]
GO
ALTER DATABASE dmaa0920_1062965 SET  READ_WRITE 
GO
