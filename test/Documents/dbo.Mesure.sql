CREATE TABLE [dbo].[Mesure] (
    [IdEnregistrement] INT          DEFAULT ((0)) NULL,
    [Id]               INT          NULL,
    [Type]             VARCHAR (10) NULL,
    [valeur]           FLOAT (53)   NULL,
    [dateHeure]        DATETIME     NULL,
    CONSTRAINT [FK_Mesure_Channel] FOREIGN KEY ([Id]) REFERENCES [dbo].[Channel] ([Id]),
    CONSTRAINT [FK_Mesure_Enregistrement] FOREIGN KEY ([IdEnregistrement]) REFERENCES [dbo].[Enregistrement] ([Id])
);

