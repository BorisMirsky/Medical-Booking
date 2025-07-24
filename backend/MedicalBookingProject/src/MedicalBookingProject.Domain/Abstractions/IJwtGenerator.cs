using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IJwtGenerator
    {
        string CreateTokenDescriptor(string email, string username, string rolename);
    }
}
