//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoldProjectWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
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
}
