using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor.Movies.Business.DTOs
{
    public class CompleteMovieDTO
    {
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public int? MovieYear { get; set; }
        public string? MovieImg { get; set; }
        public string? Gender { get; set; }
        public string? Nome { get; set; }
    }
}
