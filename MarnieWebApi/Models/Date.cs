namespace MarnieWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Date")]
    public partial class Date
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Date()
        {

        }

        public Date(int routeId, string dateStartLocation, DateTime startTime, string dateDestination, DateTime endTime, int status)
        {
            RouteId = routeId;
            DateStartLocation = dateStartLocation;
            StartTime = startTime;
            DateDestination = dateDestination;
            EndTime = endTime;
            Status = status;
        }

        public int Id { get; set; }

        public int RouteId { get; set; }

        [Required]
        [StringLength(50)]
        public string DateStartLocation { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string DateDestination { get; set; }

        public DateTime EndTime { get; set; }

        public int Status { get; set; }

        public Route Route { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<PersonDate> PersonDates { get; set; } = new HashSet<PersonDate>();
    }
}
