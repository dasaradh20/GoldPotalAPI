using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoldProjectWebAPI.Models
{
    public interface IGoldPortalContext
    {
        int SaveChanges();
        DbSet<Category> Categories { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<PartyMaster> PartyMasters { get; set; }
        DbSet<SectionMaster> SectionMasters { get; set; }
        DbSet<WorkerMaster> WorkerMasters { get; set; }
        DbSet<SalesMan> SalesMen { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDescription> ProductDescriptions { get; set; }
    }
}
