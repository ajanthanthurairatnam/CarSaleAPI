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
    public class ConfigSettingsController : ApiController
    {
        private CarSalesEntities db = new CarSalesEntities();

        // GET: api/ConfigSettings
        public IQueryable<ConfigSetting> GetConfigSettings()
        {
            return db.ConfigSettings;
        }

        // GET: api/ConfigSettings/5
        [ResponseType(typeof(ConfigSetting))]
        public IHttpActionResult GetConfigSetting(int id)
        {
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return NotFound();
            }

            return Ok(configSetting);
        }

        // PUT: api/ConfigSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfigSetting(int id, ConfigSetting configSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configSetting.ID)
            {
                return BadRequest();
            }

            db.Entry(configSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigSettingExists(id))
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

        // POST: api/ConfigSettings
        [ResponseType(typeof(ConfigSetting))]
        public IHttpActionResult PostConfigSetting(ConfigSetting configSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConfigSettings.Add(configSetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = configSetting.ID }, configSetting);
        }

        // DELETE: api/ConfigSettings/5
        [ResponseType(typeof(ConfigSetting))]
        public IHttpActionResult DeleteConfigSetting(int id)
        {
            ConfigSetting configSetting = db.ConfigSettings.Find(id);
            if (configSetting == null)
            {
                return NotFound();
            }

            db.ConfigSettings.Remove(configSetting);
            db.SaveChanges();

            return Ok(configSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfigSettingExists(int id)
        {
            return db.ConfigSettings.Count(e => e.ID == id) > 0;
        }
    }
}