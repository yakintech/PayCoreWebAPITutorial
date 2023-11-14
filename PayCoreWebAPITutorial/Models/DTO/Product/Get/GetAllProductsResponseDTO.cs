using PayCoreWebAPITutorial.Models.DTO.Base;

namespace PayCoreWebAPITutorial.Models.DTO.Product.Get
{
    public class GetAllProductsResponseDTO : BaseDTO
    {
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Stock { get; set; }
        public decimal KDVPrice { get; set; }
    }
}
