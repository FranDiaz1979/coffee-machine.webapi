namespace Entities
{
    public class Order
    {
        public int Id { get; }

        public string DrinkType { get; set; }

        public int Sugars { get; set; }

        public bool Stick { get; set; }

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