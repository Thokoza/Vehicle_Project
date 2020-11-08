using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Project_Vehicle.Models
{
    public class Waybill
    {
        public int Id { get; set; }
        [Display(Name = "Waybill Number")]
        [StringLength(30)]
        [Required]
        public string WaybilNumber { get; set; }
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string Quantity { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        

        public virtual List<Vehicle> Vehicle { get; set; }
    }
}
