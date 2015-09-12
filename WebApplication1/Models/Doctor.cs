using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorInitials { get; set; }
        public float GloveSize { get; set; }
        public string GloveType { get; set; }
        public string DoctorComment { get; set; }
    }

    public class DoctorDBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
    }
}
