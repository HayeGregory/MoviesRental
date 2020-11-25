using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class RentalDetail 
    {
        public int RentalId { get; set; }
        public int FilmId { get; set; }
        public int RentalPrice { get; set; }
    }
}
