using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Controllers;
using ToysAndGames.Data;
using ToysAndGames.Models;
using Xunit;

namespace ToysAndGamesTests
{
    public class ProductsTest
    {

        private readonly ProductController _controller;

        //MOCKS
        private readonly Mock<IProductRepository> _productRepo;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IResponse> _response;

        public ProductsTest()
        {
            //Initialize mocks.
            _productRepo = new Mock<IProductRepository>();
            _mapper = new Mock<IMapper>();
            _response = new Mock<IResponse>();

            _controller = new ProductController(_productRepo.Object, _mapper.Object, _response.Object);
        }

        [Fact]
        public void Products_GivenNoArgument_ReturnAResponse()
        {
            //Arrange
            //Mocking of response
            var response = Mock.Of<ResponseModel>(x => x.Status == 200 && x.Message == "Success" && x.Products == null);
            _response.Setup(x => x.Response()).Returns(response);

            //Mocking of products.
            var products = Mock.Of<List<ProductDataDictionary>>();
            _productRepo.Setup(x => x.FindAll()).Returns(products);


            //Act
            var result = _controller.Products();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Product_GivenANotValidId_RetunrProductsPropertyAsNull()
        {
            //Arrange
            //Mocking of response
            var productMok = Mock.Of<ProductDataDictionary>();
            var product = _productRepo.Setup(x => x.FindById(1)).Returns(productMok);

            var response = Mock.Of<ResponseModel>(x => x.Status == 200 && x.Message == "Success" && x.Products == product);
            _response.Setup(x => x.Response()).Returns(response);

            //Act
            var result = _controller.Product(1);

            //Assert
            Assert.Null(response.Products);
        }

        [Fact]
        public void Product_GivenANotValidId_RetunrProductsPropertyWithAnElement()
        {
            //Arrange
            //Mocking of response
            var productMoq = Mock.Of<ProductDataDictionary>(x => x.AgeRestriction == 12 && x.Company == "Mattel" && x.Description == "Something" &&
                x.Id == 1 && x.Name == "Black Phanter" && x.Price == 125);
            var product = _productRepo.Setup(x => x.FindById(1)).Returns(productMoq);

            var response = Mock.Of<ResponseModel>(x => x.Status == 200 && x.Message == "Success" && x.Products == productMoq);
            _response.Setup(x => x.Response()).Returns(response);

            //Mapper Mock
            var ProductModel = Mock.Of<ProductModel>();
            _mapper.Setup(x => x.Map<ProductDataDictionary, ProductModel>(productMoq)).Returns(ProductModel);

            //Act
            var result = _controller.Product(1);

            //Assert
            Assert.NotNull(response.Products);
        }


        [Fact]
        public void Delete_GivenAValidId_ReturnSuccessMessage()
        {
            //Mock of product to delete
            var productMoq = Mock.Of<ProductDataDictionary>(x => x.AgeRestriction == 12 && x.Company == "Mattel" && x.Description == "Something" &&
                x.Id == 1 && x.Name == "Black Phanter" && x.Price == 125);
            var product = _productRepo.Setup(x => x.FindById(1)).Returns(productMoq);

            //Mock response
            var response = Mock.Of<ResponseModel>(x => x.Status == 200 && x.Message == "Danger" && x.Products == null);
            _response.Setup(x => x.Response()).Returns(response);

            var isSuccess = _productRepo.Setup(x => x.Delete(productMoq)).Returns(true);

            _controller.DeleteProduct(1);


            Assert.Equal("Success", response.Message);

        }

        [Fact]
        public void Delete_GivenInvalidIdReturnProductNotFoundMessage()
        {
            //Mock of product to delete
            var productMoq = Mock.Of<ProductDataDictionary>();
            productMoq = null;
            var product = _productRepo.Setup(x => x.FindById(1)).Returns(productMoq);

            //Mock response
            var response = Mock.Of<ResponseModel>(x => x.Status == 200 && x.Message == "Success" && x.Products == productMoq);
            _response.Setup(x => x.Response()).Returns(response);

            _controller.DeleteProduct(1);


            Assert.Equal("Product not found", response.Message);

        }


    }
}
