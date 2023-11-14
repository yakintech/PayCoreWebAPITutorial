using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCoreWebAPITutorial.Models.ORM
{
    public class Product : BaseModel
    {

        [MaxLength(100)]
        public string? Name { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }

        [Column("Stock")]
        public int UnitsInStock { get; set; }

        [NotMapped]
        public decimal KDVPrice { get; set; }
    }
}
