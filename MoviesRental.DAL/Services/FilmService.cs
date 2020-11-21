using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class FilmService : BaseService<int, Film>
    {
        public FilmService(Connection connection) : base(connection)
        {
        }

        /*
         * GET : 
         * - Get all
         * - Get all by categorie id
         * - Get all by title
         * - Get all by langue id
         * - Get all by words
         */
        //todo : by words
        public override IEnumerable<Film> GetAll()
        {
            Command cmd = new Command("GetAllFilm");
            return connection.ExecuteReader<Film>(cmd, Converter);
        }
        public IEnumerable<FilmShort> GetAllFilmShort()
        {
            Command cmd = new Command("GetAllFilmShort");
            return connection.ExecuteReader<FilmShort>(cmd, ConverterShort);
        }
        public IEnumerable<FilmFull> GetAllFilmFull()
        {
            Command cmd = new Command("GetAllFilmFull");
            return connection.ExecuteReader<FilmFull>(cmd, ConverterFull);
        }

        public IEnumerable<FilmShort> GetAllFSByCategoryId(int key) {
            Command cmd = new Command("GelAllFSByCategoryId", true);
            cmd.AddParameter("categoryId", key);
            return connection.ExecuteReader<FilmShort>(cmd, ConverterShort);
        }

        public IEnumerable<FilmShort> getAllFSByTitle(string title) {
            Command cmd = new Command("GetAllFSByTitle", true);
            cmd.AddParameter("Title", title);
            return connection.ExecuteReader<FilmShort>(cmd, ConverterShort);
        }
        public IEnumerable<FilmShort> getAllFSByLanguageId(int key)
        {
            Command cmd = new Command("GetAllFSByLanguageId", true);
            cmd.AddParameter("LanguageId", key);
            return connection.ExecuteReader<FilmShort>(cmd, ConverterShort);
        }

        /* 
         * Converters :
         * - Film
         * - FilmShort
         * - FilmFull
         **/

        private Film Converter(SqlDataReader reader) {
            return new Film(
                (int)reader["FilmId"],
                reader["Title"].ToString(),
                reader["Description"].ToString(),
                (int)reader["ReleaseYear"],
                (int)reader["LanguageId"],
                (int)reader["RentalDuration"],
                (decimal)reader["RentalPrice"],
                (int)reader["Length"],
                (decimal)reader["ReplacementCost"],
                (int)reader["RatingId"]
            );
        }
        private FilmShort ConverterShort(SqlDataReader reader)
        {
            return new FilmShort(
                (int)reader["FilmId"],
                reader["Title"].ToString(),
                (int)reader["ReleaseYear"]
            );
        }
        private FilmFull ConverterFull(SqlDataReader reader)
        {
            return new FilmFull(
                (int)reader["FilmId"],
                reader["Title"].ToString(),
                reader["Description"].ToString(),
                (int)reader["ReleaseYear"],
                (int)reader["LanguageId"],
                reader["Name"].ToString(),
                (int)reader["RentalDuration"],
                (decimal)reader["RentalPrice"],
                (int)reader["Length"],
                (decimal)reader["ReplacementCost"],
                (int)reader["RatingId"],
                reader["Rating"].ToString()
            );
        }


    }
}
