using FluentValidation;
using PayCoreWebAPITutorial.Models.DTO.Product.Create;

namespace PayCoreWebAPITutorial.Models.Validations.Product
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequestDTO>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Unit Price bos gecilemez");
        }
    }
}
