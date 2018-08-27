namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "do dai toi da la 50")]
        [Required(ErrorMessage = "Ban chua nhap Name")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "do dai toi da la 50")]
        public string Alias { get; set; }

        public int? ParentID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
