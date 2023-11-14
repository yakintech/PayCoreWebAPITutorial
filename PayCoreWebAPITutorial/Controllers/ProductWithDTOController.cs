using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoreWebAPITutorial.Models.DTO.Product.Create;
using PayCoreWebAPITutorial.Models.DTO.Product.Get;
using PayCoreWebAPITutorial.Models.ORM;

namespace PayCoreWebAPITutorial.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductWithDTOController : ControllerBase
    {
        PayCoreContext db;

        public ProductWithDTOController()
        {
            db = new PayCoreContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            List<GetAllProductsResponseDTO> model = db.Products.Select(x => new GetAllProductsResponseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                KDVPrice = x.UnitPrice ?? 0 * 1.2M,
            }).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //FromSqlRaw kullanilirken disaridan bir parametre alirsaniz sql injection yiyebilirsiniz
            //var data = db.Products.FromSqlRaw("select * from Products where Id = " + id);
            
            //Disaridan parametre alacaksaniz asagidaki yol daha guvenlidir
            //var data2 = db.Products.FromSqlInterpolated($"select * from Products where Id = {id}");
           
            
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if(product != null)
            {
                var response = new GetByIdProductResponseDTO();
                response.Id = id;
                response.Name = product.Name;
                response.UnitPrice = product.UnitPrice;

                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;

                db.Products.Add(product);
                db.SaveChanges();

                var response = new CreateProductResponseDTO();
                response.Name = product.Name;
                response.UnitsInStock = product.UnitsInStock;
                response.UnitPrice = product.UnitPrice;
                response.Id = product.Id;

                return StatusCode(StatusCodes.Status201Created, response);
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
           

        }
    }
}
