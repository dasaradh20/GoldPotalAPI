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
    public class MasterWorkerController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterWorkerController() : base() { }
        public MasterWorkerController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterWorker/GetData")]
        public List<ModelForMasters.WorkerMasterLU> GetData()
        {
            var listData = base.PortalEntities.WorkerMasters
                .Select(u => new ModelForMasters.WorkerMasterLU
                {
                    WID = u.WID,
                    PinCode = u.PinCode,
                    ConactPerson = u.ConactPerson,
                    EmailId = u.EmailId,
                    MobileNo = u.MobileNo,
                    WorkerAdd1 = u.WorkerAdd1,
                    WorkerAdd2 = u.WorkerAdd2,
                    WorkerAdd3 = u.WorkerAdd3,
                    WorkerCode = u.WorkerCode,
                    WorkerName = u.WorkerName,
                    JoiningDate = u.JoiningDate,
                    SectionCode = u.SectionCode,
                    Working = u.Working
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterWorker/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.WorkerMasterLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.WorkerMasters.Add(
                new WorkerMaster
                {
                    WID = data.WID,
                    PinCode = data.PinCode,
                    ConactPerson = data.ConactPerson,
                    EmailId = data.EmailId,
                    MobileNo = data.MobileNo,
                    WorkerAdd1 = data.WorkerAdd1,
                    WorkerAdd2 = data.WorkerAdd2,
                    WorkerAdd3 = data.WorkerAdd3,
                    WorkerCode = data.WorkerCode,
                    WorkerName = data.WorkerName,
                    JoiningDate = data.JoiningDate,
                    SectionCode = data.SectionCode,
                    Working = data.Working
                });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterWorker/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.WorkerMasterLU data)
        {
            try
            {
                var record = this.PortalEntities.WorkerMasters.Where(x => x.WID == data.WID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.WorkerMasters.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterWorker/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.WorkerMasterLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.WorkerMasters.Where(x => x.WID == data.WID).First();
                record.PinCode = data.PinCode;
                record.ConactPerson = data.ConactPerson;
                record.EmailId = data.EmailId;
                record.MobileNo = data.MobileNo;
                record.WorkerAdd1 = data.WorkerAdd1;
                record.WorkerAdd2 = data.WorkerAdd2;
                record.WorkerAdd3 = data.WorkerAdd3;
                record.WorkerCode = data.WorkerCode;
                record.WorkerName = data.WorkerName;
                record.JoiningDate = data.JoiningDate;
                record.SectionCode = data.SectionCode;
                record.Working = data.Working;

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

        [HttpGet]
        [Route("api/MasterWorker/GetDataByID/{ID}")]
        public List<ModelForMasters.WorkerMasterLU> GetDataByID(int ID)
        {
            var listData = base.PortalEntities.WorkerMasters.Where(x => x.WID == ID)
                .Select(u => new ModelForMasters.WorkerMasterLU
                {
                    WID = u.WID,
                    PinCode = u.PinCode,
                    ConactPerson = u.ConactPerson,
                    EmailId = u.EmailId,
                    MobileNo = u.MobileNo,
                    WorkerAdd1 = u.WorkerAdd1,
                    WorkerAdd2 = u.WorkerAdd2,
                    WorkerAdd3 = u.WorkerAdd3,
                    WorkerCode = u.WorkerCode,
                    WorkerName = u.WorkerName,
                    JoiningDate = u.JoiningDate,
                    SectionCode = u.SectionCode,
                    Working = u.Working
                }
            ).ToList();
            return listData;
        }
    }
}
