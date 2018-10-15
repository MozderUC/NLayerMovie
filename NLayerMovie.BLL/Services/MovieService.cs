using AutoMapper;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Services
{
    public class MovieService : IMovieService
    {
        IUnitOfWork Database { get; set; }

        public MovieService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeMovie(MovieDTO movieDto)
        {
            Genre genre = Database.Genres.Get(movieDto.GenreID);

            Movie movie = new Movie
            {
                ReleaseDate = DateTime.Now,
                Title = movieDto.Title,
                GenreID = genre.ID              
            };
            Database.Movies.Create(movie);
            Database.Save();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {           
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()
                .ForMember("Genre", opt => opt.MapFrom(src=>src.Genre.Name)))
                .CreateMapper();
            
            return mapper.Map<IEnumerable<Movie>, List<MovieDTO>>(Database.Movies.GetAll());
        }

        public MovieDTO GetMovie(int id)
        {
            Movie movie = Database.Movies.Get(id);
            
            return new MovieDTO { ID = movie.ID, Title = movie.Title, Genre = movie.Genre.Name, ReleaseDate = movie.ReleaseDate };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
