SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (1, N'Подтверждено')

INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (2, N'Ожидает подтверждения')

INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (3, N'Отклонено')

SET IDENTITY_INSERT [dbo].[Statuses] OFF



SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'User', N'USER', N'e1fc0d55-0881-42ea-a237-f8d19874fbaf')

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Administrator', N'ADMINISTRATOR', N'b550f60c-a248-4113-b5d6-409102556a6b')

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Organizer', N'ORGANIZER', N'1b5b1e0c-bbbf-4b66-9342-b321c99af928')

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'Event manager', N'EVENT MANAGER', N'501dd3ac-ec0c-4924-8ae1-8da05a5f6a4a')

SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF



SET IDENTITY_INSERT [dbo].[Actions] ON 

INSERT [dbo].[Actions] ([Id], [Name], [NameMUI], [ConfirmationMUI], [SuccessMUI], [SetStatusId], [RoleId]) VALUES (1, N'Approve', N'Подтвердить', NULL, NULL, 1, 2)

INSERT [dbo].[Actions] ([Id], [Name], [NameMUI], [ConfirmationMUI], [SuccessMUI], [SetStatusId], [RoleId]) VALUES (2, N'Disapprove', N'Отклонить', NULL, NULL, 3, 2)

INSERT [dbo].[Actions] ([Id], [Name], [NameMUI], [ConfirmationMUI], [SuccessMUI], [SetStatusId], [RoleId]) VALUES (3, N'Take part', N'Участвовать', NULL, NULL, 2, 1)

SET IDENTITY_INSERT [dbo].[Actions] OFF



SET IDENTITY_INSERT [dbo].[ActionStatuses] ON 

INSERT [dbo].[ActionStatuses] ([Id], [ActionId], [StatusId]) VALUES (1, 1, 2)

INSERT [dbo].[ActionStatuses] ([Id], [ActionId], [StatusId]) VALUES (2, 2, 2)

SET IDENTITY_INSERT [dbo].[ActionStatuses] OFF



SET IDENTITY_INSERT [dbo].[Disciplines] ON 

INSERT [dbo].[Disciplines] ([Id], [Name]) VALUES (1, N'Т1-2500')

INSERT [dbo].[Disciplines] ([Id], [Name]) VALUES (2, N'Т4-3')

INSERT [dbo].[Disciplines] ([Id], [Name]) VALUES (3, N'Д2Н')

INSERT [dbo].[Disciplines] ([Id], [Name]) VALUES (4, N'Супер-1600')

SET IDENTITY_INSERT [dbo].[Disciplines] OFF



SET IDENTITY_INSERT [dbo].[RaceTypes] ON 

INSERT [dbo].[RaceTypes] ([Id], [Name]) VALUES (1, N'Кросс')

INSERT [dbo].[RaceTypes] ([Id], [Name]) VALUES (2, N'Ралли-кросс')

SET IDENTITY_INSERT [dbo].[RaceTypes] OFF



SET IDENTITY_INSERT [dbo].[RaceStatuses] ON 

INSERT [dbo].[RaceStatuses] ([Id], [Name]) VALUES (1, N'ЧР')

INSERT [dbo].[RaceStatuses] ([Id], [Name]) VALUES (2, N'ПР')

INSERT [dbo].[RaceStatuses] ([Id], [Name]) VALUES (3, N'КРАФ')

INSERT [dbo].[RaceStatuses] ([Id], [Name]) VALUES (4, N'ПРАФ')

SET IDENTITY_INSERT [dbo].[RaceStatuses] OFF



SET IDENTITY_INSERT [dbo].[Venues] ON 

INSERT [dbo].[Venues] ([Id], [Name]) VALUES (1, N'Воронеж')

SET IDENTITY_INSERT [dbo].[Venues] OFF



SET IDENTITY_INSERT [dbo].[Tracks] ON 

INSERT [dbo].[Tracks] ([Id], [Name], [VenueId]) VALUES (1, N'M1', 1)

SET IDENTITY_INSERT [dbo].[Tracks] OFF



/* Password: "Ghblevfqyjdsqgfhjkm2@" */
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (1, N'golov.po@yandex.ru', N'GOLOV.PO@YANDEX.RU', N'golov.po@yandex.ru', N'GOLOV.PO@YANDEX.RU', 0, N'AQAAAAEAACcQAAAAEDMfdUtMSks45Ko6BdRQbvxhEppNxjJmRK3BKJNxOz3355tvz8Xxlu9jo6We3nUG5A==', N'HKAQ67PBATO6SF2MEM67EP6ZUGVP525B', N'c787bbdb-24ed-4bec-9443-dd8e9542d5fc', NULL, 0, 0, NULL, 1, 0, N'System', N'Account')

SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF



INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 2)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 3)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 4)