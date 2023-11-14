using PayCoreWebAPITutorial.Models.ORM;

namespace PayCoreWebAPITutorial.Models.DTO.Product.Create
{
    public class CreateProductResponseDTO : BaseModel
    {
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
