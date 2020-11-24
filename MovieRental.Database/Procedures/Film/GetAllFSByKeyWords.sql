CREATE PROCEDURE [dbo].[GetAllFSByKeyWords]
	@KeyWords varchar(255)
AS begin
	select FilmId, Title, ReleaseYear
	from Film 
	where Title like '%'+ @KeyWords + '%' or [Description] like '%'+ @KeyWords +'%'
end
