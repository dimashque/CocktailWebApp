using CocktailWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CocktailWebApp.Data.Dtos;

namespace CocktailWebApp.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailService _cocktailService;

        public CocktailController(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _cocktailService.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Category(string id)
        {
            var drinks = await _cocktailService.GetDrinksByCategoryAsync(id);
            return View(drinks);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var drink = await _cocktailService.GetDrinkByIdAsync(id);

            if (drink == null) return View("Error");

            drink.PopulateIngredientsAndMeasures();

            return View(drink);

        }

        public async Task<IActionResult> Search(string query)
        {
            var drinks = await _cocktailService.GetDrinksByNameAsync(query);

            if (drinks == null) return View("Error");

            foreach (var drink in drinks)
            {

                drink.PopulateIngredientsAndMeasures();
            }
            return View(drinks);
        }
    }
}
