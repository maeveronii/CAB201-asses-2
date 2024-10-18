using System.Security.Cryptography.X509Certificates;

namespace Hospital;

public class Surgeon : Staff
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

    public void displaySurgeonDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
            CMDLine.displayMessage($"Staff ID: {UserStaffID}");
            CMDLine.displayMessage($"Speciality: {UserSpecialty}");
        }

}