using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Data;
using ToysAndGames.Models;
using ToysAndGames.Repository;

namespace ToysAndGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly IResponse _response;

        public ProductController(
            IProductRepository productRepo,
            IMapper mapper,
            IResponse response)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _response = response;
        }

        //-------------------------------------------------------------------------------------------------------------
        // api/product/products
        [HttpGet("products")]
        public ActionResult Products()
        {
            //Create Default response;
            var response = _response.Response();

            var products = _productRepo.FindAll();

            response.Message = "There are not records to show";
            if (products.Count > 0)
            {
                //Map to model
                var productsModel = _mapper.Map<List<ProductDataDictionary>, List<ProductModel>>(products.ToList());
                //Assign records to response.
                response.Products = productsModel;
                response.Message = "Success";
            }

            ActionResult result = base.Ok(response);
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------
        // api/product/products
        [HttpGet("product")]
        public ActionResult Product(int Id)
        {
            //Create Default response;
            var response = _response.Response();

            var product = _productRepo.FindById(Id);

            response.Message = "Product does not exists";
            if (product != null)
            {
                //Map to model
                var productModel = _mapper.Map<ProductDataDictionary, ProductModel>(product);
                response.Products = productModel;
                response.Message = "Success";
            }           

            ActionResult result = base.Ok(response);
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpPost("create")]
        public ActionResult CreateProduct(
            [FromBody] JsonElement product
            )
        {
            //Create Default response;
            var response = _response.Response();

            var productModel = JsonSerializer.Deserialize<ProductModel>(product.ToString());

            //Map to an object to be save to DB
            var ProductToSave = _mapper.Map<ProductModel, ProductDataDictionary>(productModel);
            var isSuccess = _productRepo.Create(ProductToSave);

            response.Message = "Something went wrong creating the product";
            if (isSuccess)
            {
                response.Message = "Success";
            }

            ActionResult result = base.Ok(response);
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpPut("update")]
        public ActionResult UpdateProduct(
            [FromBody] JsonElement product
            )
        {
            //Create Default response;
            var response = _response.Response();

            var productModel = JsonSerializer.Deserialize<ProductModel>(product.ToString());

            response.Message = "Invalid Information";
            if (ModelState.IsValid)
            {
                //Verify if the product to update exists
                var ProductDB = _productRepo.FindById(productModel.Id);

                response.Message = "The product you are trying to update does not exists";
                if (ProductDB != null)
                {
                    //Update values
                    ProductDB.Name = productModel.Name;
                    ProductDB.Description = productModel.Description;
                    ProductDB.AgeRestriction = productModel.AgeRestriction;
                    ProductDB.Company = productModel.Company;
                    ProductDB.Price = productModel.Price;

                    //Map to an object to be save to DB
                    //var ProductToUpdate = _mapper.Map<ProductModel, ProductDataDictionary>(productModel);
                    var isSuccess = _productRepo.Update(ProductDB);

                    response.Message = "Something went wrong updating the product";
                    if (isSuccess)
                    {
                        response.Message = "Success";
                    }
                }
            }

            ActionResult result = base.Ok(response);
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------

        [HttpDelete("delete")]
        public ActionResult DeleteProduct(int id)
        {
            //Create Default response;
            var response = _response.Response();

            //Find record to delete
            var ProductToDelete = _productRepo.FindById(id);

            response.Message = "Product not found";
            if (ProductToDelete != null)
            {
                var isSuccess = _productRepo.Delete(ProductToDelete);
                response.Message = "Something went wrong deleting the product";
                if (isSuccess)
                {
                    response.Message = "Success";
                }
            }
            
            ActionResult result = base.Ok(response);
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------
    }
}
