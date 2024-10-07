using System.ComponentModel;

namespace Hospital;
public class User
{
    public string UserName {get; set;}
    public int UserAge {get; set;}
    public string UserMobile {get; set;}
    public string UserEmail {get; set;}
    public string UserPassword {get; set;}
    public string UserType {get; set;}

    public User (string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType)
    {
        UserName = userName;
        UserAge = userAge;
        UserMobile = userMobile;
        UserEmail = userEmail;
        UserPassword = userPassword;
        UserType = userType;

    }

    public User()
    {

    }
    public void displayPatientDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
        }
}

