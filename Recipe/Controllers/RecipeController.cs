using Recipe.Data;
using Recipe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Recipe.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext dbContext = new AppDbContext();

        public RecipeController()
        {
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(RecipeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var data = new Recipe.Models.Recipe
                {
                    Id = Guid.NewGuid(),
                    Title = item.Title,
                    Ingredients = item.Ingredients,
                    Instructions = item.Instructions,
                    Cuisine = item.Cuisine,
                    Servings = item.Servings,
                    PreparationTime = item.PreparationTime,
                    CookingTime = item.CookingTime
                };

                dbContext.Recipes.Add(data);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Recipe");
            }
            return View(item);
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var Recipes = await dbContext.Recipes.ToListAsync();
            return View(Recipes);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid Id)
        {
            var e = await dbContext.Recipes.FindAsync(Id);

            return View(e);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Recipe.Models.Recipe recipe)
        {
            var existingRecipe = await dbContext.Recipes.FindAsync(recipe.Id);
            if (existingRecipe != null)
            {
                existingRecipe.Title = recipe.Title;
                existingRecipe.Ingredients = recipe.Ingredients;
                existingRecipe.Instructions = recipe.Instructions;
                existingRecipe.Cuisine = recipe.Cuisine;
                existingRecipe.Servings = recipe.Servings;
                existingRecipe.PreparationTime = recipe.PreparationTime;
                existingRecipe.CookingTime = recipe.CookingTime;

                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "Recipe");
            }
            return View(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Recipe = await dbContext.Recipes.FindAsync(id);

            dbContext.Recipes.Remove(Recipe);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Recipe");
        }
    }
}
