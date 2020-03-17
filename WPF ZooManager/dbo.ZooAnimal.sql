CREATE TABLE [dbo].[ZooAnimal] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [ZooId]    INT NOT NULL,
    [AnimalId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AnimalFK] FOREIGN KEY ([AnimalId]) REFERENCES [dbo].[Animal] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [ZooFK] FOREIGN KEY ([ZooId]) REFERENCES [dbo].[Zoo] ([Id]) ON DELETE CASCADE
);

