using System.ComponentModel;
using System.ComponentModel.Design;

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

    public void changePassword()
    {
        CMDLine.displayMessage("Enter new password:");
        string newPass = CMDLine.getString();
        UserPassword = newPass;
        CMDLine.displayMessage("Password has been changed.");

    }
}

