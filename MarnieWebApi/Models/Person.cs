namespace MarnieWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Jorneys = new HashSet<Jorney>();
            PersonDates = new HashSet<PersonDate>();
        }

        public Person(int authId, string name, DateTime birthday, string gender, string profilePicture)
        {
            AuthId = authId;
            Name = name;
            Birthday = birthday;
            Gender = gender;
            ProfilePicture = profilePicture;
            Jorneys = new HashSet<Jorney>();
            PersonDates = new HashSet<PersonDate>();
        }

        public int Id { get; set; }

        public int AuthId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(200)]
        public string ProfilePicture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Jorney> Jorneys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<PersonDate> PersonDates { get; set; }
    }
}
