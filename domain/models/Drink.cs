namespace Models
{
    public class Drink
    {
        public string DrinkType { get; set; }

        public double Money { get; set; }

        public int Sugars { get; set; }

        public int ExtraHot { get; set; }

        public int Stick
        {
            get
            {
                return this.Sugars > 0 ? 1 : 0;
            }
        }
    }
}