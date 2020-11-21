CREATE PROCEDURE [dbo].[GetAllActorInitials]

AS
BEGIN
	SELECT 
		ActorId, 
		left(FirstName, 1) as InitialFirstName, 
		left(LastName, 1) as InitialLastName
	FROM Actor A
END
