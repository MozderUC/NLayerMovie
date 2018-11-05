using NLayerMovie.BLL.DTO;
using System.Collections.Generic;

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
