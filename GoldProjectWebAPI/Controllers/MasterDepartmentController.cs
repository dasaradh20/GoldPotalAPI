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
    public class MasterDepartmentController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterDepartmentController() : base() { }
        public MasterDepartmentController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterDepartment/GetData")]
        public List<ModelForMasters.DepartmentLU> GetData()
        {
            var listCountries = base.PortalEntities.Departments
                .Select(u => new ModelForMasters.DepartmentLU
                {
                    DID = u.DID,
                    DeptName = u.DeptName,
                    DeptCode = u.Deptcode
                }
            ).ToList();

            //var serializer = new JavaScriptSerializer();
            //string json = serializer.Serialize(listCountries);
            //return json;
            return listCountries;

        }

        [HttpPost]
        [Route("api/MasterDepartment/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.DepartmentLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.Departments.Add(new Department { DID = data.DID, DeptName = data.DeptName, Deptcode = data.DeptCode });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterDepartment/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.DepartmentLU data)
        {
            try { 
                var record = this.PortalEntities.Departments.Where(x => x.DID == data.DID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.Departments.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterDepartment/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.DepartmentLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.Departments.Where(x => x.DID == data.DID).First();
                record.Deptcode = data.DeptCode;
                record.DeptName = data.DeptName;

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
