

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IJwtGenerator
    {
        string CreateTokenDescriptor(string email, string username, string rolename);
    }
}
