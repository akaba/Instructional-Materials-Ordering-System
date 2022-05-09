using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstructionalMaterials.Models
{
    public class Campus
    {
        [ScaffoldColumn(false)]
        public int CampusID { get; set; }        

        [Required, StringLength(500), Display(Name = "Campus Name")]
        public string CampusName { get; set; }

        [Required, Display(Name = "Campus Number")]
        public int CampusNumber { get; set; }

        [Required, StringLength(500), Display(Name = "DistrictName")]
        public string DistrictName { get; set; }

        [Required, Display(Name = "District Number")]
        public int DistrictNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}