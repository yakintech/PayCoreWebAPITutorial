using Microsoft.AspNetCore.Mvc;
using PayCoreWebAPITutorial.Models.ORM;

namespace PayCoreWebAPITutorial.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        PayCoreContext db;
        public ProductController()
        {
            db = new PayCoreContext();
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            return Ok(db.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
           // var product = db.Products.Find(id);


            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return StatusCode(201, product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Put(Product model)
        {
             
            var product = db.Products.FirstOrDefault(x => x.Id == model.Id);

            if(product == null)
            {
                model.Id = 0;
                db.Products.Add(model);
                db.SaveChanges();
                return StatusCode(201,model);
            }
            else
            {
                db.Products.Update(product);
                db.SaveChanges();

                return Ok(product);
            }

  
        }
    }
}
