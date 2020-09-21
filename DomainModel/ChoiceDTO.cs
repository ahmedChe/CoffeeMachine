using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DomainModel
{
    [DataContract]

    public class ChoiceDTO
    {
            private string drink;
            private int sugar;
            private bool mug;  
            [DataMember(Name = "drink")]
            public string Drink
            {
                get
                {
                    return drink;
                }
                set
                {
                    drink = value;
                }
            }
            [DataMember(Name = "sugar")]
            public int Sugar
            {
                get
                {
                    return sugar;
                }
                set
                {
                    sugar = value;
                }
            }
            [DataMember(Name = "mug")]
            public bool Mug
            {
                get
                {
                    return mug;
                }
                set
                {
                    mug = value;
                }
        }
    }
}