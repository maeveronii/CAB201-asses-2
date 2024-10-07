namespace Hospital;

public partial class Menu
// handles all login functions
{
    // <summary>
    /// Menu to Login. Various input checks necessary.
    /// </summary>
    private void LoginBaseMenu()
    {
        bool success = false;
        CMDLine.displayMessage();
        CMDLine.displayMessage("Login Menu.");
        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();


        for(var i = 0; i < Users.Count(); i++)
        {
            if(Users[i].UserEmail == email)
            {
                emailIndex = i;
                success = true;
            }
            else
            {
                CMDLine.displayMessage("#Error - Email is not registered.");
                Run();
            }
        }
        
        CMDLine.displayMessage("Please enter in your password:");
        string password = CMDLine.getString();

        if(Users[emailIndex].UserPassword == password)
        {
            success = true;
        }
        else
        {
            CMDLine.displayMessage("#Error - Wrong Password");
            Run();
        }




    }
}