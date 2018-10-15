using NLayerMovie.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Interfaces
{
     public interface IMovieService
    {
        void MakeMovie(MovieDTO orderDto);
        MovieDTO GetMovie(int id);
        IEnumerable<MovieDTO> GetMovies();
        void Dispose();
    }
}
