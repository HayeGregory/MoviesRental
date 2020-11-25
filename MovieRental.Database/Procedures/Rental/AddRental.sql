CREATE PROCEDURE [dbo].[AddRental]

	@CustomerId int,
	@FilmsId T_FilmIds READONLY

AS Begin
	/* insertion "du panier de location" */
	insert into Rental (CustomerId) values(@CustomerId);

	/* recuperer l'id créé */
	declare @RentalId INT = SCOPE_IDENTITY();

	/* insertion des films dans le panier créé, sur base des id passé en param */
	insert into [RentalDetail] ([RentalId], [FilmId], [RentalPrice])
		select @RentalId, FI.[Id], F.[RentalPrice] 
		from Film F
		join @FilmsId FI on ( F.[FilmId] = FI.[Id])

end
