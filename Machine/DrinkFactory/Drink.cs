using System;

namespace BL
{
     public abstract class Drink
    {
        public void AddSugar(int amount)
        {
            Console.WriteLine($"Add {amount} of sugar");
        }

        public void CheckMug(bool use)
        {
            Console.WriteLine($"use {(use? "Personal": "Default")} mug");
        }
    }

    public class Tea : Drink { }
    public class Coffee : Drink { }
    public class HotChoclate : Drink { }
}
