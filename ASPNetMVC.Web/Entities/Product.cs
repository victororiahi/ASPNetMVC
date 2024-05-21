using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Web.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Categories  { get; set;}

        [NotMapped]
        public int SelectedCategoryId { get; set; }
    }
}