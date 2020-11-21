CREATE FUNCTION [dbo].[DatabaseScalarInitialActor]
(
	@FirstName varchar,
	@LastName varchar
)
RETURNS varchar
AS
BEGIN
	DECLARE @initials VARCHAR(2);
	set @initials = concat(Left(@FirstName,1), left(@LastName,1))
	return @initials
END
