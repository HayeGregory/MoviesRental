using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class RentalService : BaseService<int, Rental>
    {
        public RentalService(Connection connection) : base(connection) { }

        /*
         * Get : 
         * - Get all Rental
         * - add rental : add rental + add rentalmovie
         */
        public override IEnumerable<Rental> GetAll() {
            Command cmd = new Command("GetAllRental", true);
            return Connection.ExecuteReader<Rental>(cmd, ConverterRental);
        }


        public int AddRental(Rental rental, IEnumerable<int> moviesId)
        {
            Command cmd = new Command("AddRental", true);

            /* constituer le param table movies id*/
            DataTable DT_MoviesId = new DataTable();
            DT_MoviesId.Columns.Add(new DataColumn("Id", typeof(int))); // ajout de la colonne id
            foreach (int movieId in moviesId)
                DT_MoviesId.Rows.Add(movieId);                          // ajout des id dans la table (une row un id)

            cmd.AddParameter("CustomerId", rental.CustomerId);
            cmd.AddParameter("FilmsId", DT_MoviesId);

            return Connection.ExecuteNonQuery(cmd);
        }

        private Rental ConverterRental(SqlDataReader reader) {
            return new Rental(
                    (int)reader["RentalId"],
                    (DateTime)reader["RentalDate"],
                    (int)reader["CustomerId"]
            );
        }

    }

}
