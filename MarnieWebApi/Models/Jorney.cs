namespace MarnieWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jorney")]
    public partial class Jorney
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string StartLocation { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Destination { get; set; }

        public DateTime EndTime { get; set; }

        public int Status { get; set; }

        public Person Person { get; set; }

        public Route Route { get; set; }
    }
}
