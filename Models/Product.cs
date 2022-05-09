using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace InstructionalMaterials.Models
{
    public class Product
    {
        [Key, Display(Name = "ProductID")]
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Required, Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required, Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required, Display(Name = "Language")]
        public string Language { get; set; }

        [Required, Display(Name = "Subject Area")]
        public string SubjectArea { get; set; }

        [Required, Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required, Display(Name = "Material Type")]
        public string MaterialType { get; set; }

        [Required, Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required, Display(Name = "Grade Level")]
        public string GradeLevel { get; set; }       

        [Required, Display(Name = "Copyright Year")]
        public int CopyrightYear { get; set; }

        [Required, Display(Name = "Media Format")]
        public string MediaFormat { get; set; }

        [Required, Display(Name = "% of TEKS Covered")]
        public int TEKS { get; set; }

        [Required, Display(Name = "Unit Price")]
        public double? UnitPrice { get; set; }

        [Required, Display(Name = "Allotment Type")]
        public string AllotmentType { get; set; }

        [Required, Display(Name = "Web Link")]
        public string WebLink { get; set; }

        [Required, Display(Name = "MLC")]
        public string MLC { get; set; }

        [Required, Display(Name = "Purchaser")]
        public string Purchaser { get; set; }
      
             
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        

    }

   

 



    

  

    

}