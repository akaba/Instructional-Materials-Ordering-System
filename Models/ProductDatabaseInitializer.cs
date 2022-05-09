using System.Collections.Generic;
using System.Data.Entity;

namespace InstructionalMaterials.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
            GetCampuses().ForEach(p => context.Campuses.Add(p));
           
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Category-1"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Category-2"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Category-3"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Category-4"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Category-5"
                },
            };

            return categories;
        }


        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    Publisher="Holt McDougal, a division of Houghton Mifflin Harcourt Publishing Company",
                    ProductName = "Calculus", 
                    ISBN="0618751815",
                    Language="English",
                    SubjectArea="CAREER & TECHNICAL EDUCATION (CTE)",
                    CourseName="Math-Calculus BC",
                    MaterialType="Student Material",
                    Grade="07-Seventh - 12-Twelfth",
                    GradeLevel="High School",
                    CopyrightYear=2006,
                    MediaFormat="Primarily Print",
                    TEKS=100,
                    UnitPrice = 22.50,
                    AllotmentType="Adopted",   
                    WebLink="http://www.hmhco.com/", 
                    MLC="9183",
                    Purchaser="Campus",
                    ImagePath1="carconvert.png",                    
                    CategoryID = 1
               },
                new Product 
                {
                    ProductID = 2,
                    Publisher="Holt McDougal, a division of Houghton Mifflin Harcourt Publishing Company",
                    ProductName = "Calculus", 
                    ISBN="0618751815",
                    Language="English",
                    SubjectArea="ENGLISH LANGUAGE ARTS AND READING, GRADES K-5",
                    CourseName="Math-Calculus BC",
                    MaterialType="Student Material",
                    Grade="07-Seventh - 12-Twelfth",
                    GradeLevel="High School",
                    CopyrightYear=2006,
                    MediaFormat="Primarily Print",
                    TEKS=100,
                    UnitPrice = 22,
                    AllotmentType="Adopted",   
                    WebLink="http://www.hmhco.com/", 
                    MLC="9183",
                    Purchaser="Campus",
                    ImagePath1="carconvert.png",                    
                    CategoryID = 2
               },
                new Product
                {
                   ProductID = 3,
                    Publisher="Holt McDougal, a division of Houghton Mifflin Harcourt Publishing Company",
                    ProductName = "Calculus", 
                    ISBN="0618751815",
                    Language="English",
                    SubjectArea="CAREER & TECHNICAL EDUCATION (CTE)",
                    CourseName="Math-Calculus BC",
                    MaterialType="Student Material",
                    Grade="07-Seventh - 12-Twelfth",
                    GradeLevel="High School",
                    CopyrightYear=2006,
                    MediaFormat="Primarily Print",
                    TEKS=100,
                    UnitPrice = 22.50,
                    AllotmentType="Adopted",   
                    WebLink="http://www.hmhco.com/", 
                    MLC="9183",
                    Purchaser="Campus",
                    ImagePath1="carconvert.png",                    
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 4,
                    Publisher="Holt McDougal, a division of Houghton Mifflin Harcourt Publishing Company",
                    ProductName = "Calculus", 
                    ISBN="0618751815",
                    Language="English",
                    SubjectArea="CAREER & TECHNICAL EDUCATION (CTE)",
                    CourseName="Math-Calculus BC",
                    MaterialType="Student Material",
                    Grade="07-Seventh - 12-Twelfth",
                    GradeLevel="High School",
                    CopyrightYear=2006,
                    MediaFormat="Primarily Print",
                    TEKS=100,
                    UnitPrice = 22.50,
                    AllotmentType="Adopted",   
                    WebLink="http://www.hmhco.com/", 
                    MLC="9183",
                    Purchaser="Campus",
                    ImagePath1="carconvert.png",                    
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 5,
                    Publisher="Holt McDougal, a division of Houghton Mifflin Harcourt Publishing Company",
                    ProductName = "Calculus", 
                    ISBN="0618751815",
                    Language="English",
                    SubjectArea="ENGLISH LANGUAGE ARTS AND READING, GRADES K-5",
                    CourseName="Math-Calculus BC",
                    MaterialType="Student Material",
                    Grade="07-Seventh - 12-Twelfth",
                    GradeLevel="High School",
                    CopyrightYear=2006,
                    MediaFormat="Primarily Print",
                    TEKS=100,
                    UnitPrice = 22.50,
                    AllotmentType="Adopted",   
                    WebLink="http://www.hmhco.com/", 
                    MLC="9183",
                    Purchaser="Campus",
                    ImagePath1="carconvert.png",                    
                    CategoryID = 4
                }
             
              
            };

            return products;
        }


        private static List<Campus> GetCampuses()
        {
            var campuses = new List<Campus> {
                new Campus
                {
                    CampusID=1,
                    CampusName = "HSA-Austin",
                    CampusNumber=1,
                    DistrictName="Austin",
                    DistrictNumber=1
                },
                 new Campus
                {
                    CampusID=2,
                    CampusName = "HSA-North-Austin", 
                    CampusNumber=2,
                    DistrictName="Austin",
                    DistrictNumber=1                
                },

                 new Campus
                {
                    CampusID = 3,
                    CampusName = "HSE-Austin",
                    CampusNumber=3,
                    DistrictName="Austin",
                    DistrictNumber=1                
                },
              
               
            };

            return campuses;
        }

       
    }
}

