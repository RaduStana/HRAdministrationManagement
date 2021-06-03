using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.Models
{
    public class CountHolidayScales
    {
        public int TakenDays { get; set; }
        public int TotalDays { get; set; }
        public int Difference { get { return TotalDays- TakenDays; } }

        public string FullInfo
        { get
            {
                return $"\t{TotalDays} \t\t {TakenDays} \t\t {Difference}";
            }
        }

    }
}
