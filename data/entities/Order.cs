namespace Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public int Id { get; }

        [Column("drink_type")]
        public string DrinkType { get; set; }

        public int Sugars { get; set; }

        public bool Stick { get; set; }

        [Column("extra_hot")]
        public int ExtraHot { get; set; }
    }
}

// CREATE TABLE IF NOT EXISTS orders (
//   `id` INT(10) unsigned NOT NULL AUTO_INCREMENT,
//   `drink_type` VARCHAR(20) NOT NULL,
//   `sugars` TINYINT(2) NOT NULL,
//   `stick` TINYINT(1) NOT NULL,
//   `extra_hot` TINYINT(1) NOT NULL,
//   PRIMARY KEY (`id`)
// ) ENGINE=InnoDB DEFAULT CHARSET=utf8;