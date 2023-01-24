// See https://aka.ms/new-console-template for more information

using FoodDelivery.Backennd.DAL;
using FoodDelivery.View;

await DataBaseContextSeed.SeedDefoltRolesAsync();
new Menu().DisplayMainMenu();

