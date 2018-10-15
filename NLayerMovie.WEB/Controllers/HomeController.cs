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
    public class HomeController : Controller
    {

        IMovieService movieService;
        public HomeController(IMovieService serv)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}