using System.Security.Cryptography.X509Certificates;

namespace Hospital;

class Surgeon : Staff
{
    public string UserSpecialty {get; set;}
    public Surgeon(string userName, int userAge, int userMobile, string userEmail, string userPassword, int userStaffID, string userSpecialty)
        :base(userName, userAge, userMobile, userEmail, userPassword, userStaffID)
    {
        UserSpecialty = userSpecialty;
    }

}