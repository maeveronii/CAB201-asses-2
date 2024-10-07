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

    int floorNumber = 0;
    int staffID = 0;
    bool correctInt = false;
    string specialty = null;
    int emailIndex;

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


    