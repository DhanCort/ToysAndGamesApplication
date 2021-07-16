using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Data;
using ToysAndGames.Repository;

namespace ToysAndGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepo;

        public ProductController(
            ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //-------------------------------------------------------------------------------------------------------------
        // api/product/products
        [HttpGet("products")]
        public ActionResult Products()
        {
            var products = _productRepo.FindAll();

            ActionResult result = base.Ok("Hello Word!!!");
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------
        // api/product/products
        [HttpGet("product")]
        public ActionResult Product(int id)
        {
            var products = _productRepo.FindById(id);

            ActionResult result = base.Ok("Hello Word!!!");
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpPost("create")]
        public ActionResult CreateProduct()
        {
            ActionResult result = base.Ok("Hello Word!!!");
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpPut("update")]
        public ActionResult UpdateProduct(int id)
        {
            ActionResult result = base.Ok("Hello Word!!!");
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpDelete("delete")]
        public ActionResult DeleteProduct()
        {
            ActionResult result = base.Ok("Hello Word!!!");
            return result;
        }











        ////-------------------------------------------------------------------------------------------------------------

        //// POST: ProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////-------------------------------------------------------------------------------------------------------------

        //// GET: ProductController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////-------------------------------------------------------------------------------------------------------------

        //// POST: ProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////-------------------------------------------------------------------------------------------------------------

        //// GET: ProductController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////-------------------------------------------------------------------------------------------------------------

        //// POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //-------------------------------------------------------------------------------------------------------------
    }
}
