using System;
using System.Collections.Generic;

namespace models
{
    public class DrinkPrice
    {
        public string Name { get; set; }

        public float Price { get; set; }
    }

    public class Drink
    {
        public string DrinkType { get; set; }

        public float Money { get; set; }

        public int Sugars { get; set; }

        public int ExtraHot { get; set; }
    }
}
