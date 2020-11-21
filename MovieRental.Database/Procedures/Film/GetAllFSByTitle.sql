CREATE PROCEDURE [dbo].[GetAllFSByTitle]
	@Title NVARCHAR(255)
AS
BEGIN
	SELECT FilmId, Title, [Description], ReleaseYear, RentalPrice, [Length] 
	FROM Film 
	WHERE Title like '%'+@Title+'%'
END
