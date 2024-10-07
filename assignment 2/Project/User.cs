using System.ComponentModel;

namespace Hospital;
public class User
{
    public string UserName {get; set;}
    public int UserAge {get; set;}
    public int UserMobile {get; set;}
    public string UserEmail {get; set;}
    public string UserPassword {get; set;}

    public User (string userName, int userAge, int userMobile, string userEmail, string userPassword)
    {
        UserName = userName;
        UserAge = userAge;
        UserMobile = userMobile;
        UserEmail = userEmail;
        UserPassword = userPassword;
    }

    
}

