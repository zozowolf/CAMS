DECLARE @StartTime DATETIME = '2024-02-14 06:00:00'
DECLARE @EndTime DATETIME = '2024-02-14 08:00:00'
DECLARE @CurrentTime DATETIME = @StartTime
DECLARE @IdChannel INT = 1

WHILE @CurrentTime <= @EndTime
BEGIN
    INSERT INTO [dbo].[Mesure] ([IdChannel], [valeur], [dateHeure])
    VALUES (@IdChannel, ROUND(RAND() * 40, 0), @CurrentTime)

    SET @CurrentTime = DATEADD(MINUTE, 1, @CurrentTime)
END
