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
    public class MasterCategoryController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterCategoryController() : base() { }
        public MasterCategoryController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterCategory/GetData")]
        public List<ModelForMasters.CategoryLU> GetData()
        {
            var listCountries = base.PortalEntities.Categories
                .Select(u => new ModelForMasters.CategoryLU
                {
                    CID = u.CID,
                    CatgCode = u.CatgCode,
                    CatgDesc = u.CatgDesc,
                    DeptDID = u.DeptDID
                }
            ).ToList();            
            return listCountries;

        }

        [HttpPost]
        [Route("api/MasterCategory/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.CategoryLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.Categories.Add(new Category { CID = data.CID, CatgCode = data.CatgCode, CatgDesc = data.CatgDesc, DeptDID = data.DeptDID });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterCategory/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.CategoryLU data)
        {

            var record = this.PortalEntities.Categories.Where(x => x.CID == data.CID).First();
            if (record == null)
            {
                return NotFound();
            }

            this.PortalEntities.Categories.Remove(record);
            this.PortalEntities.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterCategory/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.CategoryLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.Categories.Where(x => x.CID == data.CID ).First();
                record.CatgDesc = data.CatgDesc;
                record.CatgCode = data.CatgCode;
                record.DeptDID = data.DeptDID;

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
