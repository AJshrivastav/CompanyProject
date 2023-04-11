using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Product { get; set;}
    }
}