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
    public class MasterSalesmanController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterSalesmanController() : base() { }
        public MasterSalesmanController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterSalesman/GetData")]
        public List<ModelForMasters.SalesmanLU> GetData()
        {
            var listCountries = base.PortalEntities.SalesMen
                .Select(u => new ModelForMasters.SalesmanLU
                {
                    SMID = u.SMID,
                    SMCode = u.SMCode,
                    SMName = u.SMName
                }
            ).ToList();
            return listCountries;

        }

        [HttpPost]
        [Route("api/MasterSalesman/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.SalesmanLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.SalesMen.Add(new SalesMan { SMID = data.SMID, SMCode = data.SMCode, SMName = data.SMName});
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSalesman/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.SalesmanLU data)
        {

            var record = this.PortalEntities.SalesMen.Where(x => x.SMID == data.SMID).First();
            if (record == null)
            {
                return NotFound();
            }

            this.PortalEntities.SalesMen.Remove(record);
            this.PortalEntities.SaveChanges();

            return Ok(record);
        }

        [HttpPut]
        [Route("api/MasterSalesman/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.SalesmanLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.SalesMen.Where(x => x.SMID == data.SMID).First();
                record.SMCode = data.SMCode;
                record.SMName = data.SMName;

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
