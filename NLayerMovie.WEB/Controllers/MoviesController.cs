using AutoMapper;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerMovie.WEB.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        IMovieService movieService;
        public MoviesController(IMovieService serv)
        {
            movieService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<MovieDTO> movieDtos = movieService.GetMovies();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()).CreateMapper();
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(movieDtos);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            MovieDTO movieDto = movieService.GetMovie(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()).CreateMapper();
            var movie = mapper.Map<MovieDTO, MovieViewModel>(movieDto);
            return View(movie);
        }       
    }
}