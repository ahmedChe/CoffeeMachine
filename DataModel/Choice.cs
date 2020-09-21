using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class Choice
    {
        public Choice(string drink,int sugar, bool mug)
        {
            Drink = drink;
            Sugar = sugar;
            Mug = mug;
        }
        public Choice()
        {

        }
       public string Drink { get; set; }
       public int Sugar { get; set; }
       public bool Mug { get; set; }
    }
}
