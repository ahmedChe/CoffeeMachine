using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class DrinkServiceTest
    {
        [TestMethod]
        public void TestInexistantDrink()
        {
            //Arrange
            string macchiato = "macchiato";
            DrinkService ds = new DrinkService();
            //ACT
            Drink d = ds.SetDrink(macchiato);
            //Assert
            Assert.IsNull(d);
        }
        [TestMethod]
        public void TestValidFactory()
        {
            //Arrange
            string tea = "Tea";
            DrinkService ds = new DrinkService();
            //ACT
            Drink d = ds.SetDrink(tea);
            //Assert
            Assert.IsTrue(d.GetType() == typeof(Tea));
        }

        [TestMethod]
        public void CheckValidNumberOfFactoriesDrinks()
        {
            //Arrange

            //ACT
            DrinkService ds = new DrinkService();
            // factories are built inside the constructor

            //Assert
           Assert.IsTrue(ds.drinkFactories.Count==3);
            Assert.IsTrue(ds.drinkFactories["Tea"].GetType() == typeof(TeaFactory));
        }
    }
}
