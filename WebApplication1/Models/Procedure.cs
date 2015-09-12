using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Procedure
    {
        public int ID { get; set; }
        public string ProcedureName { get; set; }
    }

    public class ProcedureDBContext : DbContext
    {
        public DbSet<Procedure> Procedures { get; set; }
    }
}
