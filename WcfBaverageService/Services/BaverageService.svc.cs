using System.Collections.Generic;
using BL;
using DomainModel;

namespace WcfBaverageService
{

    public class BaverageService : IBaverageService
    {
        private DrinkService drinkService;
        public BaverageService()
        {
            drinkService = new DrinkService();
        }
        public List<string> GetDrinkChoices()
        {
            return drinkService.GetDrinkList();
        }

        public void PrepareDrink(ChoiceDTO choice,string username)
        {
            drinkService.SaveDrink(choice, username);
        }

        public ChoiceDTO GetLastChoice(string username)
        {
            return drinkService.GetLastChoice(username);
        }
    }
}
