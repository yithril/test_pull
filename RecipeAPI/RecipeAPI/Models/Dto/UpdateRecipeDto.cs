namespace RecipeAPI.Models.Dto;

public class UpdateRecipeDto
{
    public string Name { get; set; }
    public string Instructions { get; set; }
    public int CookingTimeInMinutes { get; set; }
    public bool IsVegan { get; set; }
}
