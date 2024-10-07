using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

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
        
        CMDLine.displayMessage("Login Menu.");
        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();


        for(var i = 0; i < Users.Count(); i++)
        {
            if(Users[i].UserEmail == email)
            {
                activeUser = Users[i];
                emailIndex = i;
                success = true;
            }
        }
        // TO-DO       if email is not registered, say that and spit back to old menu
        
        CMDLine.displayMessage("Please enter in your password:");
        string password = CMDLine.getString();

        if(activeUser.UserPassword == password)
        {
            CMDLine.displayMessage($"Hello {activeUser.UserName} welcome back.");
            if(activeUser.UserType == "Patient") //checks to see if currently logged in user is patient
            {
                PatientMenu();
                success = true;
            }
            else if(activeUser.UserType == "Floor Manager") //checks to see if currently logged in user is floor manager
            {
                success = true;
            }
            else if(activeUser.UserType == "Surgeon") //checks to see if currently logged in user is surgeon
            {
                success = true;
            }

        }
        else
        {
            CMDLine.displayMessage("#Error - Wrong Password");
            Run();
        }
    }

    /// <summary>
    /// Method that sets up the workings of the patient menu. Works the same as other "setup" methods.
    /// </summary>
    /// <returns></returns>
    private bool PatientMenu()
    {
        bool keepRunningPatientMenu = true;

        while(keepRunningPatientMenu)
        {
            keepRunningPatientMenu = displayPatientMenu();
        }

        return keepRunningPatientMenu;
    }

    /// <summary>
    /// Method that displays the Menu for all Patient activities.
    /// </summary>
    /// <returns></returns>
    private bool displayPatientMenu() 
    {

        CMDLine.displayMessage();
        CMDLine.displayMessage("Patient Menu.");
        
        const string titlestr = "Please choose from the menu below:";
        const string displaydetailsstr = "Display my details";
        const string changepasswordstr = "Change password";
        const string checkinstr = "Check in";
        const string seeroomstr = "See room";
        const string seesurgeonstr = "See surgeon";
        const string seesurgerydetailsstr = "See surgery date and time";
        const string logoutstr = "Log out";

        const int  displaydetailsint = 0, changepasswordint = 1, checkinint = 2, seeroomint = 3, seesurgeonint = 4, seesurgerydetailsint = 5, logoutint = 6;

        int option = CMDLine.GetOption(titlestr, displaydetailsstr, changepasswordstr, checkinstr, seeroomstr, seesurgeonstr, seesurgerydetailsstr, logoutstr);

        switch(option)
        {
            case displaydetailsint:
            activeUser.displayPatientDetails();
            return true;
            break;

            case changepasswordint:
            /*CurrentlyLoggedIn.changePassword();*/
            return false;
            break;

            case checkinint:
            /*CurrentlyLoggedIn.checkIn();*/
            return false;
            break;

            case seeroomint:
            /*CurrentlyLoggedIn.seeRoom();*/
            return false;
            break;

            case seesurgeonint:
            /*CurrentlyLoggedIn.seeSurgeon();*/
            return false;
            break;

            case seesurgerydetailsint:
            /*CurrentlyLoggedIn.seeSurgeryDetails();*/
            return false;
            break;

            case logoutint:
            CMDLine.displayMessage($"Patient {activeUser.UserName} has logged out.");
            activeUser = null;
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option. Please try again.");
            break;
        }
        return true;
    }

    /// <summary>
    /// Method that sets up the workings of the floor manager menu. Works the same as other "setup" methods.
    /// </summary>
    /// <returns></returns>
    private bool FloorManagerMenu()
    {
        bool keepRunningFloorManagerMenu = true;

        while(keepRunningFloorManagerMenu)
        {
            keepRunningFloorManagerMenu = displayFloorManagerMenu();
        }

        return keepRunningFloorManagerMenu;
    }

    /// <summary>
    /// Method that displays the Menu for all Floor Manager activities.
    /// </summary>
    /// <returns></returns>
    private bool displayFloorManagerMenu() 
    {

        CMDLine.displayMessage();
        CMDLine.displayMessage("Floor Manager Menu.");
        
        const string titlestr = "Please choose from the menu below:";
        const string floordisplaydetailsstr = "Display my details";
        const string floorchangepasswordstr = "Change password";
        const string assignroomstr = "Assign room to patient";
        const string assignsurgery = "Assign surgery";
        const string unassignroomstr = "Unassign room";
        const string floorlogoutstr = "Log out";

        const int  floordisplaydetailsint = 0, floorchangepasswordint = 1, assignroomint = 2, assignsurgeryint = 3, unassignroomint = 4, floorlogoutint = 5;

        int option = CMDLine.GetOption(titlestr, floordisplaydetailsstr, floorchangepasswordstr, assignroomstr, assignsurgery, unassignroomstr, floorlogoutstr,);

        switch(option)
        {
            case floordisplaydetailsint:
            activeUser.displayFloorManagerDetails();
            return true;
            break;

            case floorchangepasswordint:
            /*CurrentlyLoggedIn.changePassword();*/
            return false;
            break;

            case assignroomint:
            /*CurrentlyLoggedIn.checkIn();*/
            return false;
            break;

            case assignsurgeryint:
            /*CurrentlyLoggedIn.seeRoom();*/
            return false;
            break;

            case unassignroomint:
            /*CurrentlyLoggedIn.seeSurgeon();*/
            return false;
            break;

            case floorlogoutint:
            CMDLine.displayMessage($"Floor Manager {activeUser.UserName} has logged out.");
            activeUser = null;
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option. Please try again.");
            break;
        }
        return true;
    }


    } 