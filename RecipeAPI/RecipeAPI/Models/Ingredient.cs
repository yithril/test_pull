using System;
using System.Collections.Generic;

namespace RecipeAPI.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string Name { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public int? RecipeId { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
