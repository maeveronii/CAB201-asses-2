using System.Security.Cryptography.X509Certificates;

namespace Hospital;

class Surgeon : Staff
{
    public string UserSpecialty {get; set;}
    public Surgeon(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, int userStaffID, string userSpecialty)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType, userStaffID)
    {
        UserSpecialty = userSpecialty;
    }

    public Surgeon()
    {

    }

}