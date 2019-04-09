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
    public class SalesTransactionsController : ApiController
    {
        private GroceryStoreDbContext db = new GroceryStoreDbContext();

        // GET: api/SalesTransactions
        public IQueryable<SalesTransactions> GetCerealSales()
        {
            return db.CerealSales;
        }

        // GET: api/SalesTransactions/5
        [ResponseType(typeof(SalesTransactions))]
        public IHttpActionResult GetSalesTransactions(int id)
        {
            SalesTransactions salesTransactions = db.CerealSales.Find(id);
            if (salesTransactions == null)
            {
                return NotFound();
            }

            return Ok(salesTransactions);
        }

        // PUT: api/SalesTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesTransactions(int id, SalesTransactions salesTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesTransactions.SalesTransactionsId)
            {
                return BadRequest();
            }

            db.Entry(salesTransactions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesTransactionsExists(id))
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

        // POST: api/SalesTransactions
        [ResponseType(typeof(SalesTransactions))]
        public IHttpActionResult PostSalesTransactions(SalesTransactions salesTransactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CerealSales.Add(salesTransactions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesTransactions.SalesTransactionsId }, salesTransactions);
        }

        // DELETE: api/SalesTransactions/5
        [ResponseType(typeof(SalesTransactions))]
        public IHttpActionResult DeleteSalesTransactions(int id)
        {
            SalesTransactions salesTransactions = db.CerealSales.Find(id);
            if (salesTransactions == null)
            {
                return NotFound();
            }

            db.CerealSales.Remove(salesTransactions);
            db.SaveChanges();

            return Ok(salesTransactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesTransactionsExists(int id)
        {
            return db.CerealSales.Count(e => e.SalesTransactionsId == id) > 0;
        }
    }
}