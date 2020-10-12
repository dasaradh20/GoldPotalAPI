using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldProjectWebAPI.Models
{
    public class ModelForMasters
    {
        public class CategoryLU
        {
            public int CID { get; set; }
            public string CatgCode { get; set; }
            public string CatgDesc { get; set; }
            public Nullable<int> DeptDID { get; set; }            
        }
        public class DepartmentLU
        {
            public int DID { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
        }
        public class PartyMasterLU
        {
            public int PID { get; set; }
            public string PartyCode { get; set; }
            public string PartyName { get; set; }
            public string ConactPerson { get; set; }
            public string PartyAdd1 { get; set; }
            public string PartyAdd2 { get; set; }
            public string PartyAdd3 { get; set; }
            public string PinCode { get; set; }
            public string MobileNo { get; set; }
            public string EmailId { get; set; }
        }
        public class SectionMasterLU
        {
            public int SecID { get; set; }
            public string SectionCode { get; set; }
            public string SectionName { get; set; }
        }
        public class WorkerMasterLU
        {
            public int WID { get; set; }
            public string WorkerCode { get; set; }
            public string WorkerName { get; set; }
            public string ConactPerson { get; set; }
            public string WorkerAdd1 { get; set; }
            public string WorkerAdd2 { get; set; }
            public string WorkerAdd3 { get; set; }
            public string PinCode { get; set; }
            public string MobileNo { get; set; }
            public string EmailId { get; set; }
            public Nullable<System.DateTime> JoiningDate { get; set; }
            public string Working { get; set; }
            public string SectionCode { get; set; }
        }
        public class SalesmanLU
        {
            public int SMID { get; set; }
            public string SMCode { get; set; }
            public string SMName { get; set; }
        }
        public class ProductLU
        {
            public int PID { get; set; }
            public string ProdCode { get; set; }
            public string ProdDesc { get; set; }
            public Nullable<int> CatID { get; set; }
            public string ProdType { get; set; }
            public string RawMaterial { get; set; }
            public Nullable<int> Wastage { get; set; }
            public Nullable<bool> EmbededWithStones { get; set; }
            public Nullable<int> NoOfPieces { get; set; }
            public Nullable<int> WeightPerPiece { get; set; }
            public Nullable<int> PurchasePerPiece { get; set; }
            public string MakingCharge { get; set; }
            public Nullable<bool> Directbilling { get; set; }
            public Nullable<int> PerPiecePrice { get; set; }
        }
        public class ProductDescLU
        {
            public int PID { get; set; }
            public string PDesc { get; set; }
        }
    }
}