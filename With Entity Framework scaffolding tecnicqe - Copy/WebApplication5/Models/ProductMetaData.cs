using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class ProductMetaData
    {
        public int ProductsId { get; set; }
        // [Required]  //Name is required or it will give error
        // [Required(ErrorMessage = "Something Wrong Homie")]
        //[Required(ErrorMessage = "Something Wrong Homie"),MaxLength(10)]
        [Required(ErrorMessage = "Something Wrong Homie"), MaxLength(10,ErrorMessage ="Max Length is 10"), Display(Name ="Product name")]
        public string ProductsName { get; set; }

        [Required, Range(0,1000)]
        public Nullable<int> Price { get; set; }
        public int CatagoriesId { get; set; }

        public virtual Catagory Catagory { get; set; }
    }
}