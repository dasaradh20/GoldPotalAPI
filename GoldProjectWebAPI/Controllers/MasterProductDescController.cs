using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoldProjectWebAPI.Models;
using System.Data.Entity.Infrastructure;

namespace GoldProjectWebAPI.Controllers
{
    public class MasterProductDescController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterProductDescController() : base() { }
        public MasterProductDescController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterProductDesc/GetData")]
        public List<ModelForMasters.ProductDescLU> GetData()
        {
            var listData = base.PortalEntities.ProductDescriptions
                .Select(u => new ModelForMasters.ProductDescLU
                {
                    PID = u.PID,
                    PDesc = u.PDesc,
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterProductDesc/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.ProductDescLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.ProductDescriptions.Add(new ProductDescription { PID = data.PID, PDesc = data.PDesc });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterProductDesc/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.ProductDescLU data)
        {
            try
            {
                var record = this.PortalEntities.ProductDescriptions.Where(x => x.PID == data.PID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.ProductDescriptions.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterProductDesc/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.ProductDescLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.ProductDescriptions.Where(x => x.PID == data.PID).First();
                record.PDesc = data.PDesc;

                try
                {
                    this.PortalEntities.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }


            }
            return Ok(data);

        }        
    }
}
