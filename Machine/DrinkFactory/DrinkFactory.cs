using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public interface IDrinkFactory
    {
         Drink Prepare();
    }

    public class CoffeeFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new Coffee();
        }
    }
    public class TeaFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new Tea();
        }
    }
    public class ChoclateFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new HotChoclate();
        }
    }
}
