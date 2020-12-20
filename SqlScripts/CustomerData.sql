USE [HotelManagementDb]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([Id],[RoomId],[Name],[Address],[Phone],[Email],[TotalPersons],[BookingDays],[Advance]) VALUES (1,1,'Man','701 SW 7th Street','123-456-7890','abc@def.com',0,0,0)
SET IDENTITY_INSERT [dbo].[Customer] OFF