using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Data;
using RecipeAPI.Models.Dto;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly RecipeDbContext _recipeDB;

    public RecipeController(RecipeDbContext recipeDbContext)
    {
        _recipeDB = recipeDbContext;
    }

    //api/Recipe GET
    [HttpGet]
    public IActionResult GetAllRecipes()
    {
        //SELECT * FROM Recipes
        return Ok(_recipeDB.Recipes.ToList());
    }

    //api/Recipe/2
    [HttpGet("{id}")]
    public IActionResult GetRecipeById(int id)
    {
        var recipe = _recipeDB.Recipes.Find(id);

        if(recipe == null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRecipe(int id)
    {
        var recipe = _recipeDB.Recipes.Find(id);

        if(recipe == null)
        {
            return NotFound();
        }

        _recipeDB.Recipes.Remove(recipe);
        _recipeDB.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateRecipe([FromBody] CreateRecipeDto recipe)
    {
        Recipe newRecipe = new Recipe();
        Recipe anotherRecipe = new Recipe();

        newRecipe.Name = recipe.Name;
        newRecipe.CookingTimeInMinutes = recipe.CookingTimeInMinutes;
        newRecipe.Instructions = recipe.Instructions;
        newRecipe.IsVegan = recipe.IsVegan;

        _recipeDB.Add(newRecipe); //INSERT INTO Recipes (Name, CookingTimeInMinutes...) VALUES(recipe.Name, recipe....)

        _recipeDB.Add(anotherRecipe); //(anotherRecipe.Name, anotherRecipe.CookingTime....)

        _recipeDB.SaveChanges();

        return Ok(newRecipe);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRecipe(int id, [FromBody] UpdateRecipeDto updateRecipe)
    {
        //does the recipe even exist?
        var recipe = _recipeDB.Recipes.Find(id);

        if(recipe == null)
        {
            return NotFound();
        }

        recipe.Name = updateRecipe.Name;
        recipe.Instructions = updateRecipe.Instructions;
        recipe.CookingTimeInMinutes = updateRecipe.CookingTimeInMinutes;
        recipe.IsVegan= updateRecipe.IsVegan;

        _recipeDB.Update(recipe);
        _recipeDB.SaveChanges();

        return Ok(recipe);
    }
}
