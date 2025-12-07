using System;
using System.Collections.Generic;

namespace RecipeAPI.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string Name { get; set; } = null!;

    public string Instructions { get; set; } = null!;

    public int CookingTimeInMinutes { get; set; }

    public bool IsVegan { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
