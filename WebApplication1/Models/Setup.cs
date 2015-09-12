using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Setup
    {
        public int ID { get; set; }
        public string Doctor { get; set; }
        public string Procedure { get; set; }
        public string Modality { get; set; }
        public string Orientation { get; set; }
        public string Bilateral { get; set; }

        public int NeedleDrawingUp { get; set; }
        public int NeedleOrange { get; set; }
        public int NeedleWhite { get; set; }
        public int NeedleGrey { get; set; }
        public int NeedleSpinal { get; set; }
        public int NeedleGauge { get; set; }

        public int Syringe1ml { get; set; }
        public int Syringe3ml { get; set; }
        public int Syringe5ml { get; set; }
        public int Syringe10ml { get; set; }

        public int Lignocaine { get; set; }
        public int Bupivacaine { get; set; }

        public string Steroid { get; set; }
        public int SteroidAmount { get; set; }
        public string Contrast { get; set; }

        public string OtherEquipment { get; set; }
        public string Comments { get; set; }

        public IList<Doctor> Doctors { get; set; }
        public IList<Procedure> Procedures { get; set; }
        public IList<Setup> Setups { get; set; }
    }

    public class SetupDBContext : DbContext 
    {
        public DbSet<Setup> Setups { get; set; }
    }

}
