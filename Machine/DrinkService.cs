
using AutoMapper;
using DAL.References;
using DataModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class DrinkService
    {
        private DrinkReference ds;
        private IMapper _mapper;
        public DrinkService()
        {
            MachineSystemSetup();
            ds = new DrinkReference();
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ChoiceDTO, Choice>();
                x.CreateMap<Choice, ChoiceDTO>();
            });

            _mapper = config.CreateMapper();
        }
    private Dictionary<string,IDrinkFactory> drinkFactories = new Dictionary<string, IDrinkFactory>(StringComparer.InvariantCultureIgnoreCase);
        private void MachineSystemSetup()
        {
            string drink;
            foreach(Type t in typeof(DrinkService).Assembly.GetTypes())
            {
                if (typeof(IDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    drink = t.Name.Replace("Factory", string.Empty);
                    drinkFactories.Add(drink, (IDrinkFactory)Activator.CreateInstance(t));
                }
            }
        }
        private Drink SetDrink(string drink)
        {
            if (drinkFactories.ContainsKey(drink))
                return drinkFactories[drink].Prepare();
            return null;
        }
        public List<string> GetDrinkList()
        {
            return drinkFactories.Keys.ToList();
        }
        public void SaveDrink(ChoiceDTO choice, string username)
        {
            PrepareDrink(choice);
            Choice choiceModel = _mapper.Map<Choice>(choice);
            ds.InsertChoice(choiceModel, username);
        }
        public ChoiceDTO GetLastChoice(string username)
        {
            Choice c = ds.ReturningUserChoice(username);
            ChoiceDTO choice = _mapper.Map<ChoiceDTO>(c);
            return choice;
        }
        private void PrepareDrink(ChoiceDTO choice)
        {
            Drink drink = SetDrink(choice.Drink);
            drink.AddSugar(choice.Sugar);
            drink.CheckMug(choice.Mug);
        }
        
    }
}
