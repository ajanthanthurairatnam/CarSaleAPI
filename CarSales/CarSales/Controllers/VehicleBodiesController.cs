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
    public class VehicleBodiesController : ApiController
    {
        private CarSalesEntities db = new CarSalesEntities();

        // GET: api/VehicleBodies
        public IQueryable<VehicleBody> GetVehicleBodies()
        {
            return db.VehicleBodies;
        }

        // GET: api/VehicleBodies/5
        [ResponseType(typeof(VehicleBody))]
        public IHttpActionResult GetVehicleBody(int id)
        {
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return NotFound();
            }

            return Ok(vehicleBody);
        }

        // PUT: api/VehicleBodies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleBody(int id, VehicleBody vehicleBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleBody.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleBody).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleBodyExists(id))
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

        // POST: api/VehicleBodies
        [ResponseType(typeof(VehicleBody))]
        public IHttpActionResult PostVehicleBody(VehicleBody vehicleBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleBodies.Add(vehicleBody);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleBody.ID }, vehicleBody);
        }

        // DELETE: api/VehicleBodies/5
        [ResponseType(typeof(VehicleBody))]
        public IHttpActionResult DeleteVehicleBody(int id)
        {
            VehicleBody vehicleBody = db.VehicleBodies.Find(id);
            if (vehicleBody == null)
            {
                return NotFound();
            }

            db.VehicleBodies.Remove(vehicleBody);
            db.SaveChanges();

            return Ok(vehicleBody);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleBodyExists(int id)
        {
            return db.VehicleBodies.Count(e => e.ID == id) > 0;
        }
    }
}