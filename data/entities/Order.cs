namespace Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("orders")]
    public class Order
    {
        [Key, Column("id")]
        public int Id { get; }

        [Column("drink_type")]
        public string DrinkType { get; set; }

        public int Sugars { get; set; }

        public int Stick { get; set; }

        [Column("extra_hot")]
        public int ExtraHot { get; set; }
    }
}