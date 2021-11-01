USE [FABS]
GO
INSERT [dbo].[zipcode_country_city] ([zipcode], [country], [city]) VALUES (N'9000', N'Danmark', N'Aalborg')
GO
SET IDENTITY_INSERT [dbo].[addresses] ON 
GO
INSERT [dbo].[addresses] ([id], [street_name], [street_number], [apartment_number], [zipcode], [country]) VALUES (2, N'Sofiendalsvej', N'60', NULL, N'9000', N'Danmark')
GO
SET IDENTITY_INSERT [dbo].[addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[associations] ON 
GO
INSERT [dbo].[associations] ([id], [cvr], [name], [addresses_id]) VALUES (1, N'12341234', N'UCN Kajakker', 2)
GO
SET IDENTITY_INSERT [dbo].[associations] OFF
GO
SET IDENTITY_INSERT [dbo].[logins] ON 
GO
INSERT [dbo].[logins] ([id], [email], [password]) VALUES (1, N'test@test.com', N'1234')
GO
SET IDENTITY_INSERT [dbo].[logins] OFF
GO
SET IDENTITY_INSERT [dbo].[people] ON 
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [logins_id], [is_admin]) VALUES (2, N'Peter', N'Hahn', N'20202020', 2, 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [logins_id], [is_admin]) VALUES (3, N'Lars', N'Andersen', N'29292929', 2, 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [logins_id], [is_admin]) VALUES (4, N'Rasmus', N'Larsen', N'28282828', 2, 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [logins_id], [is_admin]) VALUES (5, N'Allan', N'Jacobsen', N'27272727', 2, 1, 0)
GO
INSERT [dbo].[people] ([id], [first_name], [last_name], [telephone_number], [adresses_id], [logins_id], [is_admin]) VALUES (6, N'Maijbritt', N'Jacobsen', N'26262626', 2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[people] OFF
GO
