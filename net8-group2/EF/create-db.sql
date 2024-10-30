﻿CREATE TABLE [Pizza] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Description] nvarchar(400) NULL,
    [LaunchDate] datetime2 NULL,
    CONSTRAINT [PK_Pizza] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Ingredient] (
    [Code] nvarchar(4) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Quantity] decimal(18,2) NOT NULL,
    [PizzaId] int NOT NULL,
    [PizzaId1] int NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([Code]),
    CONSTRAINT [FK_Ingredient_Pizza_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizza] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Ingredient_Pizza_PizzaId1] FOREIGN KEY ([PizzaId1]) REFERENCES [Pizza] ([Id])
);
GO


CREATE INDEX [IX_Ingredient_PizzaId] ON [Ingredient] ([PizzaId]);
GO


CREATE INDEX [IX_Ingredient_PizzaId1] ON [Ingredient] ([PizzaId1]);
GO


CREATE INDEX [IX_Pizza_Name] ON [Pizza] ([Name]);
GO

