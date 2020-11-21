using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class ActorService : BaseService<int, Actor>
    {
        public ActorService(Connection connection) : base(connection)
        {
        }

        public override IEnumerable<Actor> GetAll()
        {
            Command cmd = new Command("GetAllActor", true);
            return connection.ExecuteReader<Actor>(cmd, Converter);
        }

        public IEnumerable<Actor> GetAllByFilmId(int key) {
            Command cmd = new Command("GetAllActorByFilmId", true);
            cmd.AddParameter("IdFilm", key);
            return connection.ExecuteReader<Actor>(cmd, Converter);

        }

        private Actor Converter(SqlDataReader reader)
        {
            return new Actor (
                (int)reader["ActorId"],
                reader["FirstName"].ToString(), 
                reader["LastName"].ToString()
            );
        }
    }
}
