namespace MarnieWebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Stop")]
    public partial class Stop
    {
        public Stop()
        {

        }

        public int Id { get; set; }

        public int RouteId { get; set; }

        public int StationId { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public Route Route { get; set; }

        public Station Station { get; set; }
    }
}
