namespace FindAnnouncements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnnounID { get; set; }

        [StringLength(30)]
        public string AnimalName { get; set; }

        [StringLength(30)]
        public string AnimalCategory { get; set; }

        [StringLength(50)]
        public string Wool { get; set; }

        [StringLength(30)]
        public string Size { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [StringLength(30)]
        public string Gender { get; set; }

        public bool? Chiped { get; set; }

        [StringLength(50)]
        public string ChipCode { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishDate { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
