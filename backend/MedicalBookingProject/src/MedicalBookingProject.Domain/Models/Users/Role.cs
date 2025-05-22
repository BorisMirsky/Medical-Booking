using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role(string name) => Name = name;
    }
}
