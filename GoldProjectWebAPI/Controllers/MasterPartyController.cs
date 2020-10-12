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
    public class MasterPartyController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterPartyController() : base() { }
        public MasterPartyController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterParty/GetData")]
        public List<ModelForMasters.PartyMasterLU> GetData()
        {
            var listCountries = base.PortalEntities.PartyMasters
                .Select(u => new ModelForMasters.PartyMasterLU
                {
                    PID = u.PID,
                    PinCode = u.PinCode,
                    ConactPerson = u.ConactPerson,
                    EmailId = u.EmailId,
                    MobileNo = u.MobileNo,
                    PartyAdd1 = u.PartyAdd1,
                    PartyAdd2 = u.PartyAdd2,
                    PartyAdd3 = u.PartyAdd3,
                    PartyCode = u.PartyCode,
                    PartyName = u.PartyName
                }
            ).ToList();
            return listCountries;

        }

        [HttpPost]
        [Route("api/MasterParty/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.PartyMasterLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.PartyMasters.Add(
                new PartyMaster {
                    PID = data.PID,
                    PinCode = data.PinCode,
                    ConactPerson = data.ConactPerson,
                    EmailId = data.EmailId,
                    MobileNo = data.MobileNo,
                    PartyAdd1 = data.PartyAdd1,
                    PartyAdd2 = data.PartyAdd2,
                    PartyAdd3 = data.PartyAdd3,
                    PartyCode = data.PartyCode,
                    PartyName = data.PartyName
                });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterParty/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.PartyMasterLU data)
        {
            try
            {
                var record = this.PortalEntities.PartyMasters.Where(x => x.PID == data.PID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.PartyMasters.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterParty/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.PartyMasterLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.PartyMasters.Where(x => x.PID == data.PID).First();
                record.PinCode = data.PinCode;
                record.ConactPerson = data.ConactPerson;
                record.EmailId = data.EmailId;
                record.MobileNo = data.MobileNo;
                record.PartyAdd1 = data.PartyAdd1;
                record.PartyAdd2 = data.PartyAdd2;
                record.PartyAdd3 = data.PartyAdd3;
                record.PartyCode = data.PartyCode;
                record.PartyName = data.PartyName;

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
