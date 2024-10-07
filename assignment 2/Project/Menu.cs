using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Hospital;

public partial class Menu{

    private Patient userPatient;
    private FloorManager userFloorManager;
    private Surgeon userSurgeon;
    int age = -1;
    string name = null;
    string mobile = "";
    string email = "";
    string password = "";
    

    int floorNumber = 0;
    int staffID = 0;
    bool correctInt = false;
    string specialty = null;
    int emailIndex;

    bool loggedIn = false;
    User activeUser = new();
    List<User> Users = new List<User>();

    /// <summary>
    /// Creates a bool that when true, loops through attached menu, in this case, the main menu.
    /// </summary>
    public void Run()
    {
        bool keepRunning = true;
        while(keepRunning)
        {
            keepRunning = displayMainMenu();
        }
    }

    /// <summary>
    /// The main menu of the application, giving a Login and Register option. Runs constantly until a proper option is picked, i.e. bool returns false.
    /// </summary>
    /// <returns></returns>
    private bool displayMainMenu()
    {
        CMDLine.displayMessage();

        /*Patient john = new Patient("john", 13, 012345, "maeve@maeve", password, "patient");
        Users.Add(john);

        FloorManager john2 = new FloorManager("john", 13, 012345, "maeve2@maeve", password, "patient", 503, 1);
        Users.Add(john2);

        User john3 = new User("john", 13, 012345, "maeve3@maeve", password, "patient");
        Users.Add(john3);

        for(var i = 0; i < Users.Count(); i++)
        {
            CMDLine.displayMessage(Users[i].UserEmail);
        }*/


        
        const string MAINMENUSTR = "Please choose from the menu below:";
        const string LOGINSTR = "Login as a registered user";
        const string REGISTERSTR = "Register as a new user";
        const string EXITSTR = "Exit";

        const int  LOGININT = 0, REGISTERINT = 1, EXITINT = 2;

        int option = CMDLine.GetOption(MAINMENUSTR, LOGINSTR, REGISTERSTR, EXITSTR);

        switch(option)
        {
            case LOGININT:
            //login menu
            LoginBaseMenu();
            break;

            case REGISTERINT:
            registerMenu();
            break;

            case EXITINT:
            CMDLine.displayMessage("Goodbye. Please stay safe.");
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option, please try again.");
            break;
        }
        return true; //keep looping through the menu 

    }

}


    