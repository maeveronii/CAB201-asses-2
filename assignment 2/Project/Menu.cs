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

    /*The "active users" below are created in order to be used when someone is "logged in". whenever a floor manager, or surgeon, or patient is logged in, 
    the object corresponding to their class has all of the constructors of the specific floor manager, surgeon, or patient added to it.*/
    User activeUser = new();
    Patient activePatient = new();
    FloorManager activeFloorManager = new();
    Surgeon activeSurgeon = new();

    /*These lists work in similar ways to their respective "active" objects. They are used for logging in to the system. When a new user is registered, 
    they are added to their respective list, and then later, when logging in, if an object matching the users email and password inputs is found in one
    of these lists, the user is transported to the respective menu, e.g. the patient menu. */
    List<User> Users = new List<User>();
    List<Patient> Patients = new List<Patient>();
    List<FloorManager> FloorManagers = new List<FloorManager>();
    List<Surgeon> Surgeons = new List<Surgeon>();

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


    