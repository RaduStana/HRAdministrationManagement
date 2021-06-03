using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public String Type { get; set; }
        public String Reason { get; set; }
        public int UserId { get; set; }
        public string State { get; set; }
        public int DiffDays { get; set; }
        public string fullInfo
        {
            get
            {
                return $"{DateOfStart.Day}/{DateOfStart.Month}/{DateOfStart.Year} \t {DateOfFinish.Day}/{DateOfFinish.Month}/{DateOfFinish.Year} \t {DiffDays} \t {Type} \t\t\t  {Reason} \t\t {State} ";
            }
        }
    }
}
