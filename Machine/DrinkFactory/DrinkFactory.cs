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

    internal class CoffeeFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new Coffee();
        }
    }
    internal class TeaFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new Tea();
        }
    }
    internal class ChoclateFactory : IDrinkFactory
    {
        public Drink Prepare()
        {
            return new HotChoclate();
        }
    }
}
