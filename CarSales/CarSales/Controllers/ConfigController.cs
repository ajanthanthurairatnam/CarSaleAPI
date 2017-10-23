using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarSalesDataAccess;

namespace CarSales.Controllers
{
    public class ConfigController : ApiController
    {

        public IEnumerable<ConfigSetting> Get()
        {
            using (CarSalesEntities entities = new CarSalesEntities())
            {
                return entities.ConfigSettings.ToList();
            }

        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    var entity = entities.ConfigSettings.FirstOrDefault(e => e.ID == id);
                    if (entity != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Config with id =" + id.ToString() + " not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Post([FromBody] ConfigSetting configsetting)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    entities.ConfigSettings.Add(configsetting);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, configsetting);
                    message.Headers.Location = new Uri(Request.RequestUri + configsetting.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Put(int id, [FromBody] ConfigSetting configsetting)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    var entity = entities.ConfigSettings.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Config with id =" + id.ToString() + " not found");
                    }
                    else
                    {
                      
                        entity.ID = id;
                        entity.VehicleAdvertisementNextRefNo = configsetting.VehicleAdvertisementNextRefNo;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    var entity = entities.ConfigSettings.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Config with id =" + id.ToString() + " not found");
                    }
                    else
                    {
                        entities.ConfigSettings.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
