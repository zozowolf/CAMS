DECLARE @IdChannel INT = 1;
DECLARE @StartDate DATETIME = '2024-02-13 08:00:00'; -- Définissez la date de départ souhaitée
DECLARE @EndDate DATETIME = '2024-02-13 10:00:00'; -- Définissez la date de fin souhaitée
DECLARE @CurrentDate DATETIME = @StartDate;

WHILE @CurrentDate <= @EndDate
BEGIN
    DECLARE @Valeur INT = ROUND(RAND() * 40, 0);

    INSERT INTO [dbo].[Mesure] ([IdChannel], [valeur], [dateHeure]) 
    VALUES (@IdChannel, @Valeur, @CurrentDate);

    SET @CurrentDate = DATEADD(MINUTE, 1, @CurrentDate); -- Incrémentez la date d'une minute
END
