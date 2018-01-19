using sample_web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace sample_web_api.Controllers
{
    /// <summary>
    /// Impelments Http restful operations on Product entity
    /// </summary>
    public class ProductsController:ApiController
    {
        private List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Monitor",
                    Price = 250.00M
                },
                new Product()
                {
                    Id = 2,
                    Name = "Keyboard",
                    Price = 29.50M
                },
                new Product()
                {
                    Id = 3,
                    Name = "Mouse",
                    Price = 19.99M
                }
            };
        }

        /// <summary>
        /// Retrieves all products defined in the system
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successful read</response>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        /// <summary>
        /// Create a new product and add into existing product list
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <response code="201">Successful Creation</response>
        /// <response code="400">Incorrect product create request</response>
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(product);
                return Created("/product" + product.Id, product);
            }
            else
                return BadRequest("Incorrect update request");
        }

        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            if (ModelState.IsValid)
                _products.Add(product);

            return Ok(product);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}