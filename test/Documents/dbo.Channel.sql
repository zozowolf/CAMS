CREATE TABLE [dbo].[Channel] (
    [No]         INT            NOT NULL,
	[Type]	 INT			NOT NULL,
    [Desc]       NVARCHAR (255) NULL,
    [Intervalle] INT            NULL,
    [IdEnregist] INT            NULL,
    [sexe]       NCHAR (10)     NULL,
    [génotype]   NCHAR (10)     NULL,
    [age]        INT            NULL,
    [traité]     NCHAR (10)     NULL,
    PRIMARY KEY CLUSTERED ([No] ASC),
	CONSTRAINT FK_Channel_Type FOREIGN KEY ([Type]) REFERENCES [dbo].[Type]([Id])
);

