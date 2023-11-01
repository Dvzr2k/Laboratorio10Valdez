using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {


            BProduct business = new BProduct();
            List<Product> products = business.GetByName("");

            List<ProductModel> productsModel = products.Select(x => new ProductModel
            {
                Id = x.ProductId,
                Name = x.Name,
                Price = x.Price,
            }).ToList();


            return View(productsModel);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BProduct business = new BProduct();
                    Product product = new Product
                    {
                        
                        Name = model.Name,
                        Price = model.Price,
                        
                    };
                    business.CreateProduct(product);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
       

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            BProduct business = new BProduct();
            Product product = business.GetById(id);
            ProductModel productModel = new ProductModel
            {
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
            };

            return View(productModel);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                BProduct business = new BProduct();
                business.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
