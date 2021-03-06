﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlockbusterWebAppplication.Models;
using BlockBuster;

namespace BlockbusterWebAppplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            string[] colors = { "red", "blue", "yellow" };
            ViewBag.Colors = colors;
            return View();
        }

        public IActionResult Cities()
        {
            string[] cities = { "New York City", "Paris", "London", "Tokyo", "Cape Town" };
            ViewBag.Cities = cities;
            return View();
        }

        public IActionResult Movies()
        {
            var movieList = BlockBusterBasicFunctions.GetAllMoviesFull();
            return View(movieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
