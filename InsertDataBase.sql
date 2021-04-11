CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [E-mail] VARCHAR(50) NOT NULL, 
    [Password] INT NOT NULL
)

CREATE TABLE [dbo].[Customers]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [IdBaglanti] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) -- İlişkilendirme
)