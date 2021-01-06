namespace Models
{
    public class Drink
    {
        public string DrinkType { get; set; }

        public float Money { get; set; }

        public int Sugars { get; set; }

        public int ExtraHot { get; set; }

        public int Stick
        {
            get
            {
                return Sugars > 0 ? 1 : 0;
            }
        }
    }
}