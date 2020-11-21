CREATE PROCEDURE [dbo].[GetFilmById]
	@Id int

AS BEGIN
	SELECT * from V_Film where FilmId = @Id
END
