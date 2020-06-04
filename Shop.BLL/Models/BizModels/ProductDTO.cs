using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.BLL.BizModels
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ProductCount { get; set; }

    }
}
