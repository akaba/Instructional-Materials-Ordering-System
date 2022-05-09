using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstructionalMaterials.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }        

        public virtual ICollection<Product> Products { get; set; }
    }
}