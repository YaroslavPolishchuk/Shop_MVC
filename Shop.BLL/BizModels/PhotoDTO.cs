using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.BizModels
{
    public class PhotoDTO
    {
        public int PhotoId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(256)]
        public string PhotoPath { get; set; }
    }
}
