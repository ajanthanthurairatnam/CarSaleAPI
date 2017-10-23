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
using CarSalesDataAccess;

namespace CarSales.Controllers
{
    public class VehicleFuelsController : ApiController
    {
        private CarSalesEntities db = new CarSalesEntities();

        // GET: api/VehicleFuels
        public IQueryable<VehicleFuel> GetVehicleFuels()
        {
            return db.VehicleFuels;
        }

        // GET: api/VehicleFuels/5
        [ResponseType(typeof(VehicleFuel))]
        public IHttpActionResult GetVehicleFuel(int id)
        {
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return NotFound();
            }

            return Ok(vehicleFuel);
        }

        // PUT: api/VehicleFuels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleFuel(int id, VehicleFuel vehicleFuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleFuel.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleFuel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleFuelExists(id))
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

        // POST: api/VehicleFuels
        [ResponseType(typeof(VehicleFuel))]
        public IHttpActionResult PostVehicleFuel(VehicleFuel vehicleFuel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleFuels.Add(vehicleFuel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleFuel.ID }, vehicleFuel);
        }

        // DELETE: api/VehicleFuels/5
        [ResponseType(typeof(VehicleFuel))]
        public IHttpActionResult DeleteVehicleFuel(int id)
        {
            VehicleFuel vehicleFuel = db.VehicleFuels.Find(id);
            if (vehicleFuel == null)
            {
                return NotFound();
            }

            db.VehicleFuels.Remove(vehicleFuel);
            db.SaveChanges();

            return Ok(vehicleFuel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleFuelExists(int id)
        {
            return db.VehicleFuels.Count(e => e.ID == id) > 0;
        }
    }
}