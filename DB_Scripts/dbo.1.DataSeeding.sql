USE [SoftBox]

GO

SET IDENTITY_INSERT [Roles] ON
INSERT INTO [dbo].[Roles] ([Id], [Name])
VALUES ('1', 'admin'), ('2', 'participant')
SET IDENTITY_INSERT [Roles] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id],[FirstName],[LastName],[Login],[Password],[RoleId])
VALUES ('1','AdminFirstName','AdminLastName','admin','admin','1')
SET IDENTITY_INSERT [Users] OFF

GO