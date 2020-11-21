select ActorId, concat(left(FirstName,1),left(LastName,1)) as [initialActor],
		FirstName, LastName
from Actor
select ActorId, [dbo].[DatabaseScalarInitialActor](FirstName, LastName) as [initialActor],
		FirstName, LastName
from Actor

select dbo.DatabaseScalarInitialActor(FirstName,LastName) from Actor


exec[dbo].[DatabaseScalarInitialActor('ttt','tttt')]


select A.FirstName, A.LastName from Film F
inner join FilmActor FA on (F.FilmId = FA.FilmId)
inner join Actor A on (FA.ActorId = A.ActorId)
where F.FilmId = 44


select ActorId, FirstName, LastName
from Actor
where 'DT' = concat(left(FirstName,1),left(LastName,1))


select * from Category


SELECT ActorId, FirstName, LastName
FROM Actor 
WHERE SUBSTRING(FirstName, 1, 1) = 'A' AND SUBSTRING(LastName, 1, 1) = 'B'

	SELECT ActorId, FirstName, LastName
	FROM Actor 
	WHERE	left(FirstName, 1) = left('MM' , 1)
	AND		left(LastName, 1) = right('MM', 1)


SELECT SUBSTRING(FirstName, 1, 1) as FirstName, SUBSTRING(LastName, 1, 1) as LastName 
FROM Actor 
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT 
	ActorId, 
	left(FirstName, 1) as InitialFirstName, 
	left(LastName, 1) as InitialLastName
/*	concat(left(FirstName, 1), left(LastName, 1)) as Initials*/
FROM Actor A
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT ActorId as Id, CONCAT(FirstName, ' ', LastName) as [Name] FROM Actor


SELECT CategoryId as Id, * FROM Category


SELECT FilmId as Id, * FROM Film


SELECT * FROM Film WHERE FilmId = 1


SELECT * FROM Film WHERE Title like 'ACADEMY DINOSAUR'


SELECT * FROM FilmActor 
inner JOIN Film on FilmActor.FilmId = Film.FilmId
inner JOIN Actor on FilmActor.ActorId = Actor.ActorId
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT F.FilmId, F.Title, F.ReleaseYear FROM FilmCategory FC
inner JOIN Film F ON FC.FilmId = F.FilmId
inner JOIN Category C ON FC.CategoryId = C.CategoryId
WHERE C.CategoryId = 1

INSERT INTO Rental (CustomerId) OUTPUT inserted.RentalId VAlUES (@CustomerId)
INSERT INTO RentalDetail (FilmId, RentalPrice) OUTPUT inserted.RentalId VALUES (@FilmId, @RentalPrice)

SELECT RentalId as Id, * FROM Rental
SELECT RentalId as Id, * FROm RentalDetail


SELECT [FilmId]
      ,[Title]
      ,[Description]
      ,[ReleaseYear]
      ,[F].[LanguageId]
	  ,[L].[Name]
      ,[RentalDuration]
      ,[RentalPrice]
      ,[Length]
      ,[ReplacementCost]
	  ,[F].[RatingId]
      ,[Rating]

  FROM [Film] AS [F]
  JOIN [Rating] AS [R] ON [F].[RatingId] = [R].[RatingId]
  JOIN [Language] AS [L] ON [F].[LanguageId] = [L].[LanguageId]


exec [dbo].[GetAllActorByInitials('DT')]

select count(*) from Film WHERE LanguageId=2 


SELECT F.FilmId, F.Title, F.ReleaseYear FROM FilmCategory FC
inner JOIN Film F ON FC.FilmId = F.FilmId
inner JOIN Category C ON FC.CategoryId = C.CategoryId
WHERE C.CategoryId = 1


set varchar Titlee
set @Titlee = 'DIVINE'
	SELECT Title, [Description], ReleaseYear, RentalPrice, [Length] 
	FROM Film 
	WHERE Title like '%'+'DIVINE'+'%'

exec [dbo].[GetAllFSByTitle('DIVINE')]


	SELECT FilmId, Title, [Description], ReleaseYear, RentalPrice, [Length] 
	FROM Film 
	WHERE LanguageId = 1