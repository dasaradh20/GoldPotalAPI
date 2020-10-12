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
    public class MasterSectionController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterSectionController() : base() { }
        public MasterSectionController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterSection/GetData")]
        public List<ModelForMasters.SectionMasterLU> GetData()
        {
            var listCountries = base.PortalEntities.SectionMasters
                .Select(u => new ModelForMasters.SectionMasterLU
                {
                    SecID = u.SecID,
                    SectionName = u.SectionName,
                    SectionCode = u.SectionCode
                }
            ).ToList();          
            return listCountries;

        }

        [HttpPost]
        [Route("api/MasterSection/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.SectionMasterLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.SectionMasters.Add(new SectionMaster { SecID = data.SecID, SectionName = data.SectionName, SectionCode = data.SectionCode });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSection/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.SectionMasterLU data)
        {
            try
            {
                var record = this.PortalEntities.SectionMasters.Where(x => x.SecID == data.SecID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.SectionMasters.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterSection/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.SectionMasterLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.SectionMasters.Where(x => x.SecID == data.SecID).First();
                record.SectionCode = data.SectionCode;
                record.SectionName = data.SectionName;

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
