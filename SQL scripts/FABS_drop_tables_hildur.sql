USE [dmaa0920_1062965]
GO
ALTER TABLE [dbo].[warehouses] DROP CONSTRAINT [FK_warehouses_addresses]
GO
ALTER TABLE [dbo].[people] DROP CONSTRAINT [FK_people_logins]
GO
ALTER TABLE [dbo].[people] DROP CONSTRAINT [FK_people_addresses]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_warehouses]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_people]
GO
ALTER TABLE [dbo].[kayaks] DROP CONSTRAINT [FK_kayaks_locations]
GO
ALTER TABLE [dbo].[kayaks] DROP CONSTRAINT [FK_kayaks_kayak_types]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_statuses]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_kayaks]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_associations]
GO
ALTER TABLE [dbo].[bookings] DROP CONSTRAINT [FK_bookings_statuses]
GO
ALTER TABLE [dbo].[bookings] DROP CONSTRAINT [FK_bookings_people]
GO
ALTER TABLE [dbo].[booking_line] DROP CONSTRAINT [FK_booking_line_items]
GO
ALTER TABLE [dbo].[booking_line] DROP CONSTRAINT [FK_booking_line_bookings]
GO
ALTER TABLE [dbo].[associations] DROP CONSTRAINT [FK_associations_addresses]
GO
ALTER TABLE [dbo].[association_warehouse] DROP CONSTRAINT [FK_association_warehouse_warehouses]
GO
ALTER TABLE [dbo].[association_warehouse] DROP CONSTRAINT [FK_association_warehouse_associations]
GO
ALTER TABLE [dbo].[association_person] DROP CONSTRAINT [FK_association_person_people]
GO
ALTER TABLE [dbo].[association_person] DROP CONSTRAINT [FK_association_person_associations]
GO
ALTER TABLE [dbo].[addresses] DROP CONSTRAINT [FK_addresses_zipcode_country_city]
GO
/****** Object:  Table [dbo].[zipcode_country_city]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[zipcode_country_city]') AND type in (N'U'))
DROP TABLE [dbo].[zipcode_country_city]
GO
/****** Object:  Table [dbo].[warehouses]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouses]') AND type in (N'U'))
DROP TABLE [dbo].[warehouses]
GO
/****** Object:  Table [dbo].[statuses]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[statuses]') AND type in (N'U'))
DROP TABLE [dbo].[statuses]
GO
/****** Object:  Table [dbo].[people]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[people]') AND type in (N'U'))
DROP TABLE [dbo].[people]
GO
/****** Object:  Table [dbo].[logins]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logins]') AND type in (N'U'))
DROP TABLE [dbo].[logins]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[kayaks]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[kayaks]') AND type in (N'U'))
DROP TABLE [dbo].[kayaks]
GO
/****** Object:  Table [dbo].[kayak_types]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[kayak_types]') AND type in (N'U'))
DROP TABLE [dbo].[kayak_types]
GO
/****** Object:  Table [dbo].[items]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[bookings]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bookings]') AND type in (N'U'))
DROP TABLE [dbo].[bookings]
GO
/****** Object:  Table [dbo].[booking_line]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[booking_line]') AND type in (N'U'))
DROP TABLE [dbo].[booking_line]
GO
/****** Object:  Table [dbo].[associations]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[associations]') AND type in (N'U'))
DROP TABLE [dbo].[associations]
GO
/****** Object:  Table [dbo].[association_warehouse]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[association_warehouse]') AND type in (N'U'))
DROP TABLE [dbo].[association_warehouse]
GO
/****** Object:  Table [dbo].[association_person]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[association_person]') AND type in (N'U'))
DROP TABLE [dbo].[association_person]
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 10-11-2021 21:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[addresses]') AND type in (N'U'))
DROP TABLE [dbo].[addresses]
GO
