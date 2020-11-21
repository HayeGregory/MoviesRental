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


SELECT CONCAT(FirstName,' ', LastName) 
FROM Actor 
WHERE SUBSTRING(FirstName, 1, 1) = 'D' AND SUBSTRING(LastName, 1, 1) = 'T'


SELECT SUBSTRING(FirstName, 1, 1) as FirstName, SUBSTRING(LastName, 1, 1) as LastName 
FROM Actor 
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT 
	ActorId, A.FirstName, A.LastName,
	left(FirstName, 1) as FirstName, 
	left(LastName, 1) as LastName,
	concat(left(FirstName, 1), left(LastName, 1)) as Initials
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


SELECT * FROM FilmCategory
inner JOIN Film ON FilmCategory.FilmId = Film.FilmId
inner JOIN Category ON FilmCategory.CategoryId = Category.CategoryId
WHERE [Name] = 'Action'

INSERT INTO Rental (CustomerId) OUTPUT inserted.RentalId VAlUES (@CustomerId)
INSERT INTO RentalDetail (FilmId, RentalPrice) OUTPUT inserted.RentalId VALUES (@FilmId, @RentalPrice)

SELECT RentalId as Id, * FROM Rental
SELECT RentalId as Id, * FROm RentalDetail