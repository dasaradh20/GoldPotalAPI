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
    public class MasterProductController : BaseController
    {
        private goldportalEntities db = new goldportalEntities();
        public MasterProductController() : base() { }
        public MasterProductController(IGoldPortalContext context) : base(context) { }

        [HttpGet]
        [Route("api/MasterProduct/GetData")]
        public List<ModelForMasters.ProductLU> GetData()
        {
            var listData = base.PortalEntities.Products
                .Select(u => new ModelForMasters.ProductLU
                {
                    PID = u.PID,
                    ProdCode = u.ProdCode,
                    ProdDesc = u.ProdDesc,
                    CatID = u.CatID,
                    ProdType = u.ProdType,
                    RawMaterial = u.RawMaterial,
                    Wastage = u.Wastage,
                    EmbededWithStones = u.EmbededWithStones,
                    NoOfPieces = u.NoOfPieces,
                    WeightPerPiece = u.WeightPerPiece,
                    PurchasePerPiece = u.PurchasePerPiece,
                    MakingCharge = u.MakingCharge,
                    Directbilling = u.Directbilling,
                    PerPiecePrice = u.PerPiecePrice     
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterProduct/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(ModelForMasters.ProductLU data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            base.PortalEntities.Products.Add(new Product {
                PID = data.PID,
                ProdCode = data.ProdCode,
                ProdDesc = data.ProdDesc,
                CatID = data.CatID,
                ProdType = data.ProdType,
                RawMaterial = data.RawMaterial,
                Wastage = data.Wastage,
                EmbededWithStones = data.EmbededWithStones,
                NoOfPieces = data.NoOfPieces,
                WeightPerPiece = data.WeightPerPiece,
                PurchasePerPiece = data.PurchasePerPiece,
                MakingCharge = data.MakingCharge,
                Directbilling = data.Directbilling,
                PerPiecePrice = data.PerPiecePrice
            });
            base.PortalEntities.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterProduct/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(ModelForMasters.PartyMasterLU data)
        {
            try
            {
                var record = this.PortalEntities.Products.Where(x => x.PID == data.PID).First();
                if (record == null)
                {
                    return NotFound();
                }

                this.PortalEntities.Products.Remove(record);
                this.PortalEntities.SaveChanges();

                return Ok(record);
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/MasterProduct/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(ModelForMasters.ProductLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = this.PortalEntities.Products.Where(x => x.PID == data.PID).First();
                record.PID = data.PID;
                record.ProdCode = data.ProdCode;
                record.ProdDesc = data.ProdDesc;
                record.CatID = data.CatID;
                record.ProdType = data.ProdType;
                record.RawMaterial = data.RawMaterial;
                record.Wastage = data.Wastage;
                record.EmbededWithStones = data.EmbededWithStones;
                record.NoOfPieces = data.NoOfPieces;
                record.WeightPerPiece = data.WeightPerPiece;
                record.PurchasePerPiece = data.PurchasePerPiece;
                record.MakingCharge = data.MakingCharge;
                record.Directbilling = data.Directbilling;
                record.PerPiecePrice = data.PerPiecePrice;

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
        [Route("api/MasterProduct/GetDataByID/{ID}")]
        public List<ModelForMasters.ProductLU> GetDataByID(int ID)
        {
            var listData = base.PortalEntities.Products.Where(x => x.PID == ID)
                .Select(u => new ModelForMasters.ProductLU
                {
                    PID = u.PID,
                    ProdCode = u.ProdCode,
                    ProdDesc = u.ProdDesc,
                    CatID = u.CatID,
                    ProdType = u.ProdType,
                    RawMaterial = u.RawMaterial,
                    Wastage = u.Wastage,
                    EmbededWithStones = u.EmbededWithStones,
                    NoOfPieces = u.NoOfPieces,
                    WeightPerPiece = u.WeightPerPiece,
                    PurchasePerPiece = u.PurchasePerPiece,
                    MakingCharge = u.MakingCharge,
                    Directbilling = u.Directbilling,
                    PerPiecePrice = u.PerPiecePrice
                }
            ).ToList();
            return listData;
        }
    }
}
