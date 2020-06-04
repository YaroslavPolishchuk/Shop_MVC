using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.BizModels
{
    public class ManufacturerDTO
    {
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(20)]
        public string ManufacturerName { get; set; }
    }
}
