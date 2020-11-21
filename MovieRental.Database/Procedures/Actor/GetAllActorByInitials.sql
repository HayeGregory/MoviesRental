--CREATE PROCEDURE [dbo].[GetAllActorByInitials]
--	@initials varchar
--AS Begin
--	SELECT ActorId, FirstName, LastName
--	FROM Actor 
--	WHERE	left(FirstName, 1) = left(@initials,1)
--	AND		left(LastName, 1) = right(@initials,1)
--End


CREATE PROCEDURE [dbo].[GetAllActorByInitials]
	@initialsFN char,
	@initialsLN char

AS Begin
	SELECT ActorId, FirstName, LastName
	FROM Actor 
	WHERE	left(FirstName, 1) = @initialsFN
	AND		left(LastName, 1) = @initialsLN
end