

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBookingProject.Domain.Models.Users
{

    [Table("users_role")]
    public class Role
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;
        public Role(string name) => Name = name;
        public List<Doctor>? Doctors { get; set; }
        public List<Patient>? Patients { get; set; }
    }
}
