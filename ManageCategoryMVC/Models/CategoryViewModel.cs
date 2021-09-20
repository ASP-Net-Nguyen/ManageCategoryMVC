using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCategoryMVC.Models
{
    public class CategoryViewModel
    {
        [DisplayName("CategoryId")]
        public int id { get; set; }
        public List<SelectListItem> ListOfCategories { get; set; }
    }
}
