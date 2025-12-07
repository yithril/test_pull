namespace RecipeAPI.Models.Dto;

public class CreateRecipeDto
{
    public string Name { get; set; }
    public string Instructions { get; set; }
    public int CookingTimeInMinutes { get; set; }
    public bool IsVegan { get; set; }
}
