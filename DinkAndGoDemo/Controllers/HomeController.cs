using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinkAndGoDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }
    }
}