USE [HotelManagementDb]
GO
SET IDENTITY_INSERT [dbo].[Service] ON 
INSERT [dbo].[Service] ([Id],[RoomId],[Description],[Amount]) VALUES (1,1,'Cloth washing',10);
INSERT [dbo].[Service] ([Id],[RoomId],[Description],[Amount]) VALUES (2,1,'Dining Service',30);
INSERT [dbo].[Service] ([Id],[RoomId],[Description],[Amount]) VALUES (3,2,'Movie Order',5);
SET IDENTITY_INSERT [dbo].[Service] OFF