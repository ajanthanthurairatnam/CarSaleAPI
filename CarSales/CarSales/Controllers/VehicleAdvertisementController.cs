using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarSalesDataAccess;

namespace CarSales.Controllers
{
        public class VehicleAdvertisementController : ApiController
        {
        
        public IEnumerable<VehicleAdvertisement> Get( string SearchText = "")
        {
            using (CarSalesEntities entities = new CarSalesEntities())
            {
                if (string.IsNullOrEmpty(SearchText))
                {
                    return entities.VehicleAdvertisements.ToList();
                }
                else
                {
                    return entities.VehicleAdvertisements.Where(e=>e.Description.Contains(SearchText)||(e.Reference_ID.ToString().Contains(SearchText))||(e.Reference_No.Contains(SearchText))).ToList();
                }
            }
           
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    var entity= entities.VehicleAdvertisements.FirstOrDefault(e => e.Reference_ID == id);
                    if(entity !=null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound , "Vehicle with id ="+id.ToString()+" not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage  Post([FromBody] VehicleAdvertisement vehicleadvertisement,string SearchText="")
         {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    entities.VehicleAdvertisements.Add(vehicleadvertisement);
                    entities.SaveChanges();

                    var entity = entities.ConfigSettings.FirstOrDefault(e => e.ID == 1);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Config with id =" + 1.ToString() + " not found");
                    }
                    else
                    {

                        entity.ID = 1;
                        entity.VehicleAdvertisementNextRefNo = entity.VehicleAdvertisementNextRefNo+1;
                        entities.SaveChanges();
                    }

                    var message = Request.CreateResponse(HttpStatusCode.Created, vehicleadvertisement);
                    message.Headers.Location = new Uri(Request.RequestUri + vehicleadvertisement.Reference_ID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
      
        public HttpResponseMessage Put(int id,[FromBody] VehicleAdvertisement vehicleadvertisement)
        {
            try
            {
                using (CarSalesEntities entities = new CarSalesEntities())
                {
                    var entity = entities.VehicleAdvertisements.FirstOrDefault(e => e.Reference_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vehicle with id =" + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.AudoMeter = vehicleadvertisement.AudoMeter;
                        entity.BodyType = vehicleadvertisement.BodyType;
                        entity.Description = vehicleadvertisement.Description;
                        entity.EngineCapacity = vehicleadvertisement.EngineCapacity;
                        entity.Fuel = vehicleadvertisement.Fuel;
                        entity.Price = vehicleadvertisement.Price;
                        entity.Reference_No = vehicleadvertisement.Reference_No;
                        entity.Title = vehicleadvertisement.Title;
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
                    var entity = entities.VehicleAdvertisements.FirstOrDefault(e => e.Reference_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vehicle with id =" + id.ToString() + " not found");
                    }
                    else
                    {
                        entities.VehicleAdvertisements.Remove(entity);
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
