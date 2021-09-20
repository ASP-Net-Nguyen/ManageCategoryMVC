using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCategoryMVC.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required, DisplayName("Tên ")]
        public string Name { get; set; }
        [Required, DisplayName("Thứ tự")]
        [Range (1, int.MaxValue, ErrorMessage ="Số phải lớn hơn 0")]
        public int DisplayOder { get; set; }

    }
}
