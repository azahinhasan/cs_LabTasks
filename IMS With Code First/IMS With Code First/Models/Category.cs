using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS_With_Code_First.Models
{
    //1. Data Annotations
    //2. Fluent API

    //[Table("CategoryTbl",Schema ="dbo")]
    public class Category
    {
        //[Key,MaxLength(10),MinLength(1),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        //[Required,StringLength(20),Column("Name")]
        public string CategoryName { get; set; }
        //[NotMapped]
        //public string Details { get; set; }
        //[ForeignKey("CategoryLabelId")]
        //public int CategoryLabelId { get; set; }
    }
}