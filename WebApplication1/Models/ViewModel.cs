using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ViewModel
    {
        public IList<Doctor> Doctors { get; set; }
        public IList<Procedure> Procedures { get; set; }
        public IList<Setup> Setups { get; set; }
    }
}
