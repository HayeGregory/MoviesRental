	SELECT ActorId, FirstName, LastName
	FROM Actor 
	WHERE	left(FirstName, 1) = left('DT',1)
	AND		left(LastName, 1) = substring('DT',2,1)

		where FirstName like 'D%' and LastName like '%T'