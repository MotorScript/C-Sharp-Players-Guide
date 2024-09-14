// See https://aka.ms/new-console-template for more information

Seasoning GetSeasoning()
{
    Console.WriteLine("1 - Spicy\n" +
                      "2 - Salty\n" +
                      "3 - Sweet\n");

    int response = Convert.ToInt32(Console.ReadLine());
    Seasoning seasoningKind = response switch
    {
        1 => Seasoning.Spicy,
        2 => Seasoning.Salty,
        3 => Seasoning.Sweet
    };
    return seasoningKind;
}

MainIngredient GetMainIngredient()
{
    Console.WriteLine("1 - Mushrooms\n" +
                      "2 - Carrots\n" +
                      "3 - Chicken\n" +
                      "4 - Potatos\n");

    int response = Convert.ToInt32(Console.ReadLine());
    MainIngredient ingredientType = response switch
    {
        1 => MainIngredient.Mushrooms,
        2 => MainIngredient.Carrots,
        3 => MainIngredient.Chicken,
        4 => MainIngredient.Potatos
    };
    return ingredientType;
}

FoodType GetFoodType()
{
    Console.WriteLine("1 - Soup\n" +
                      "2 - Stew\n" +
                      "3 - Gumbo\n");

    int response = Convert.ToInt32(Console.ReadLine());
    FoodType foodType = response switch
    {
        1 => FoodType.Soup,
        2 => FoodType.Stew,
        3 => FoodType.Gumbo
    };
    return foodType;
}

(Seasoning, MainIngredient, FoodType) createdFood = (GetSeasoning(), GetMainIngredient(), GetFoodType());

Console.WriteLine($"You created {createdFood}!");


enum Seasoning {Spicy, Salty, Sweet}
enum MainIngredient {Mushrooms, Carrots, Chicken, Potatos};
enum FoodType {Soup, Stew, Gumbo}