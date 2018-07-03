using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pharmacy.Models
{
    public class PharContext : DatabasePharmacyEntities
    {
        public DbSet<Medication> Meds { get; set; }
        public DbSet<Order> Ords { get; set; }
    }
}