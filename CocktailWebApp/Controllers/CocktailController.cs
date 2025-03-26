using CocktailWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CocktailWebApp.Data.Dtos;
using CocktailWebApp.ViewModel;
using CocktailWebApp.Models;

namespace CocktailWebApp.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailService _cocktailService;
        private readonly ICocktailRepository _cocktailRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public CocktailController(ICocktailService cocktailService, ICocktailRepository cocktailRepository, IIngredientRepository ingredientRepository)
        {
            _cocktailService = cocktailService;
            _cocktailRepository = cocktailRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _cocktailService.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Category(string id)
        {
            ViewBag.ActionName = "Detail";
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

        public async Task <IActionResult> MyRecipes()
        {
            var myRecipes = await _cocktailRepository.GetAllAsync();

            if (myRecipes == null) return View("Error");

            ViewBag.ActionName = "MyRecipeDetails";

            List<DrinkDto> myRecipesDto = new List<DrinkDto>();

            foreach(var myRecipe in myRecipes)
            {
                DrinkDto drinkDto = new DrinkDto
                {
                    Id = myRecipe.Id.ToString(),
                    Name = myRecipe.Name,
                    ImageUrl = myRecipe.ImageUrl,
                };

                myRecipesDto.Add(drinkDto);
            }

            
            return View("Category", myRecipesDto);


        }

        public async Task <IActionResult> RecipeDetails(int id)
        {
            var myCocktail = await _cocktailRepository.GetByIdAsync(id);
            if (myCocktail == null) return View("Error");

            DrinkDetailDto drinkDetail = new DrinkDetailDto
            {
                Id = myCocktail.Id.ToString(),
                Name = myCocktail.Name,
                Category = myCocktail.Category,
                Alcoholic = myCocktail.Alcoholic,
                Glass = myCocktail.Glass,
                DrinkImageUrl = myCocktail.ImageUrl,
                Instructions = myCocktail.Instructions,
                Ingredients = myCocktail.CocktailIngredients
                     .Select(ci => ci.Ingredient?.Name)
                     .Where(name => !string.IsNullOrEmpty(name))
                     .ToList(),
                Measures = myCocktail.CocktailIngredients
                     .Select(ci => ci.Amount)
                     .Where(amount => !string.IsNullOrEmpty(amount))
                     .ToList()
            };


            return View("Detail", drinkDetail);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCocktailViewModel CreateCocktailVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model Upload Error");
                return View(CreateCocktailVM);
            }
            var cocktail = new Cocktail
            {
                Name = CreateCocktailVM.Name,
                Category = CreateCocktailVM.Category,
                Instructions = CreateCocktailVM.Instructions,
                Glass = CreateCocktailVM.Glass,
                Alcoholic = CreateCocktailVM.Alcoholic,
                ImageUrl = CreateCocktailVM.ImageUrl,
            };
             await _cocktailRepository.Add(cocktail);

            foreach(var ingredient in CreateCocktailVM.Ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient.Name))
                {
                    var ing = await _ingredientRepository.GetByNameAsync(ingredient.Name.ToString());

                    if (ing == null)
                    {
                         ing = new Ingredient { Name = ingredient.Name };
                        await _ingredientRepository.Add(ing);
                    }

                    cocktail.CocktailIngredients.Add(new CocktailIngredient
                    {
                        CocktailId = cocktail.Id,
                        IngredientId = ing.Id,
                        Amount = ingredient.Amount

                    });

                }
                
            }
            await _cocktailRepository.Update(cocktail);
            return RedirectToAction("Index");


        }
    }
}
