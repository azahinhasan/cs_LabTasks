using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFast.Models
{
    //1. Data Annotations
    //2. Fluent API
    //[Table("CategoryTbl",Schema ="dbo")]

    public class Category
    {
        //[Key,MaxLength(10),MinLength(1),DatabaseGenerated(DatabaseGeneratedOption.Identity)] //DatabaseGeneratedOption.Identity/computed/none
        public int CategoryId { get; set; }
        //[Required,StringLength(20),Column("Name")]
        public string CategoryName { get; set; }
        //[NotMapped] //it will not create Details in DB
        //public string Details { get; set; }
        //[ForeignKey("CategoryLabelId")]
        //public int CategoryLabelId { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}