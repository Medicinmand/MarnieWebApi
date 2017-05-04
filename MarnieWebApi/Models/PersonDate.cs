namespace MarnieWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDate")]
    public partial class PersonDate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        // Status: 0 = pending, 1 = Yes, 2 = No.
        public int Status { get; set; }

        public Date Date { get; set; }

        public Person Person { get; set; }

        public PersonDate(int personId, int status)
        {
            PersonId = personId;
            Status = status;
        }

        public PersonDate()
        {

        }
    }
}
