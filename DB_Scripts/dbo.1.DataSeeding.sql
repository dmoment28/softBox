USE [SoftBox]

GO

SET IDENTITY_INSERT [Roles] ON
INSERT INTO [dbo].[Roles] ([Id], [Name])
VALUES ('1', 'admin'), ('2', 'participant')
SET IDENTITY_INSERT [Roles] OFF

SET IDENTITY_INSERT [UserProfiles] ON
INSERT INTO [dbo].[UserProfiles] ([Id], [FirstName], [LastName], [UserId])
VALUES ('1','admin','admin','1')
SET IDENTITY_INSERT [UserProfiles] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [Login], [Token], [UserProfileId], [Password], [RoleId])
VALUES ('1','admin','','1','admin', '1')
SET IDENTITY_INSERT [Users] OFF
GO