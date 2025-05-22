using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.MedicalCards
{
    public class MedicalCard
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public List<Guid> Records { get; set; } = [];
    }
}
