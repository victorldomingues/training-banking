-- DROP DATABASE TrainingBank;
USE master 
GO
If(db_id('TrainingBank') IS NULL)
CREATE DATABASE TrainingBank;
GO
USE TrainingBank;
GO
IF NOT EXISTS (SELECT * FROM  sysobjects WHERE name='Users' and xtype='U')
    CREATE TABLE [Users] (
		[Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(), 
        [Cpf] NVARCHAR(11) NOT NULL,
		[Name] NVARCHAR(255) NOT NULL,
		[Email] NVARCHAR(255) NOT NULL,
		[Phone] NVARCHAR(20) NOT NULL,
		[Address] NVARCHAR(MAX) NOT NULL
		UNIQUE(CPF)
    )
GO