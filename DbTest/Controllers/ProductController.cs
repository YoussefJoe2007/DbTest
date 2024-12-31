using DbTest.DbContext;
using DbTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbTest.Controllers
{
    public class ProductController : Controller
    {
        private ProdectlDbContext _context;

        public ProductController(ProdectlDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost] 
        public IActionResult Update(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);
//or find(ID)
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
