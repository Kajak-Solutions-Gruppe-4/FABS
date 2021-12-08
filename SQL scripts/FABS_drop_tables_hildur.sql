USE [dmaa0920_1062965]
GO
ALTER TABLE [dbo].[zipcode_country_city] DROP CONSTRAINT [FK_zipcode_country_city_countries]
GO
ALTER TABLE [dbo].[warehouses] DROP CONSTRAINT [FK_warehouses_addresses]
GO
ALTER TABLE [dbo].[people] DROP CONSTRAINT [FK_people_logins1]
GO
ALTER TABLE [dbo].[people] DROP CONSTRAINT [FK_people_addresses]
GO
ALTER TABLE [dbo].[organisations] DROP CONSTRAINT [FK_organisations_addresses]
GO
ALTER TABLE [dbo].[organisation_person] DROP CONSTRAINT [FK_association_person_people]
GO
ALTER TABLE [dbo].[organisation_person] DROP CONSTRAINT [FK_association_person_organisations]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_warehouses]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_people]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_organisations]
GO
ALTER TABLE [dbo].[kayak_types] DROP CONSTRAINT [FK_kayak_types_item_types]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_statuses]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_organisations]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_locations]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_item_types]
GO
ALTER TABLE [dbo].[bookings] DROP CONSTRAINT [FK_bookings_statuses]
GO
ALTER TABLE [dbo].[bookings] DROP CONSTRAINT [FK_bookings_people]
GO
ALTER TABLE [dbo].[booking_line] DROP CONSTRAINT [FK_booking_line_items]
GO
ALTER TABLE [dbo].[booking_line] DROP CONSTRAINT [FK_booking_line_bookings]
GO
ALTER TABLE [dbo].[addresses] DROP CONSTRAINT [FK_addresses_zipcode_country_city1]
GO
ALTER TABLE [dbo].[addresses] DROP CONSTRAINT [FK_addresses_countries]
GO
/****** Object:  Table [dbo].[zipcode_country_city]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[zipcode_country_city]') AND type in (N'U'))
DROP TABLE [dbo].[zipcode_country_city]
GO
/****** Object:  Table [dbo].[warehouses]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouses]') AND type in (N'U'))
DROP TABLE [dbo].[warehouses]
GO
/****** Object:  Table [dbo].[statuses]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[statuses]') AND type in (N'U'))
DROP TABLE [dbo].[statuses]
GO
/****** Object:  Table [dbo].[people]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[people]') AND type in (N'U'))
DROP TABLE [dbo].[people]
GO
/****** Object:  Table [dbo].[organisations]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[organisations]') AND type in (N'U'))
DROP TABLE [dbo].[organisations]
GO
/****** Object:  Table [dbo].[organisation_person]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[organisation_person]') AND type in (N'U'))
DROP TABLE [dbo].[organisation_person]
GO
/****** Object:  Table [dbo].[logins]    Script Date: 08-12-2021 13:42:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logins]') AND type in (N'U'))
DROP TABLE [dbo].[logins]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[kayak_types]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[kayak_types]') AND type in (N'U'))
DROP TABLE [dbo].[kayak_types]
GO
/****** Object:  Table [dbo].[items]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[item_types]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[item_types]') AND type in (N'U'))
DROP TABLE [dbo].[item_types]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countries]') AND type in (N'U'))
DROP TABLE [dbo].[countries]
GO
/****** Object:  Table [dbo].[bookings]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bookings]') AND type in (N'U'))
DROP TABLE [dbo].[bookings]
GO
/****** Object:  Table [dbo].[booking_line]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[booking_line]') AND type in (N'U'))
DROP TABLE [dbo].[booking_line]
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 08-12-2021 13:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[addresses]') AND type in (N'U'))
DROP TABLE [dbo].[addresses]
GO
USE [master]
GO
/****** Object:  Database [FABS]    Script Date: 08-12-2021 13:42:48 ******/
DROP DATABASE [FABS]
GO
