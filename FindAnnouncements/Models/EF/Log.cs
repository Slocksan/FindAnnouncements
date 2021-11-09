namespace FindAnnouncements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Operation { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}
