namespace MarnieWebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Stop")]
    public partial class Stop
    {
        public Stop(int routeId, int stationId, TimeSpan arrivalTime, TimeSpan departureTime)
        {
            RouteId = routeId;
            StationId = stationId;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
        }

        public Stop(int stationId, TimeSpan arrivalTime, TimeSpan departureTime)
        {
            StationId = stationId;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
        }

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
