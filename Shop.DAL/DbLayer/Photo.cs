namespace Shop.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        public int PhotoId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(256)]
        public string PhotoPath { get; set; }

        public virtual Product Product { get; set; }
    }
}
