using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private GroceryStoreDbContext db = new GroceryStoreDbContext();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [Route("{id:int}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/type/food
        [Route("~/api/Products/{name}")]
        [HttpGet]
        [ResponseType(typeof(List<Product>))]
        public IHttpActionResult type(string name)
        {
            //ProductType pt = db.ProductTypes.Where(p => p.Name == name).FirstOrDefault();
            //if (pt == null)
            //{
            //    return NotFound();
            //}

            List<Product> products = db.Products.Where(p => p.Type.Name == name).ToList();
            Console.Write("\n" + products + "\n");
            if (products.Count() <=0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(ProductViewModal ProductViewModal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductType pt = db.ProductTypes.Where(e => e.Name == ProductViewModal.Type).FirstOrDefault();
            if (pt == null)
            {
                pt = new ProductType() { Name = ProductViewModal.Type };
            }

            Product product = new Product() { Name = ProductViewModal.Name, Type = pt, Price = ProductViewModal.Price };
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}