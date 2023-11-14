using System.ComponentModel.DataAnnotations;

namespace PayCoreWebAPITutorial.Models.DTO.Product.Create
{
    public class CreateProductRequestDTO
    {
        public string Name { get; set; }

        //[Required(ErrorMessage = "UnitPrice alani zorunludur")]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
