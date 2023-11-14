using PayCoreWebAPITutorial.Models.DTO.Base;

namespace PayCoreWebAPITutorial.Models.DTO.Product.Get
{
    public class GetByIdProductResponseDTO : BaseDTO
    {
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
