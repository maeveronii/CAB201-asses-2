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
        //bool success = false;
        
        CMDLine.displayMessage("Login Menu.");

        if(Users.Count() == 0)
        {
            CMDLine.displayError("#Error - There are no people registered.");
            return;
        }

        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();

        for(var i = 0; i < Users.Count(); i++)
        {
            if(Users[i].UserEmail == email)
            {
                activeUser = Users[i];
                emailIndex = i;
                //success = true;
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
                for(var i = 0; i < Patients.Count(); i++)
                {
                    if(Patients[i].UserEmail == email)
                    {
                        activePatient = Patients[i];
                    }
                }
                PatientMenu();
            }
            else if(activeUser.UserType == "Floor Manager") //checks to see if currently logged in user is floor manager
            {
                for(var i = 0; i < FloorManagers.Count(); i++)
                {
                    if(FloorManagers[i].UserEmail == email)
                    {
                        activeFloorManager = FloorManagers[i];
                    }
                }
                FloorManagerMenu();
            }
            else if(activeUser.UserType == "Surgeon") //checks to see if currently logged in user is surgeon
            {
               for(var i = 0; i < Surgeons.Count(); i++)
               {
                    if(Surgeons[i].UserEmail == email)
                   {
                       activeSurgeon = Surgeons[i];
                   }
               }
               SurgeonMenu();
            }

        }
        else
        {
            CMDLine.displayError("#Error - Wrong Password.");
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
        const string checkoutstr = "Check out";
        const string seeroomstr = "See room";
        const string seesurgeonstr = "See surgeon";
        const string seesurgerydetailsstr = "See surgery date and time";
        const string logoutstr = "Log out";

        const int  displaydetailsint = 0, changepasswordint = 1, checkinoutint = 2, seeroomint = 3, seesurgeonint = 4, seesurgerydetailsint = 5, logoutint = 6;
        int option;
        if(!activePatient.userCheckedIn)
        {
            option = CMDLine.GetOption(titlestr, displaydetailsstr, changepasswordstr, checkinstr, seeroomstr, seesurgeonstr, seesurgerydetailsstr, logoutstr);
        }
        else
        {
            option = CMDLine.GetOption(titlestr, displaydetailsstr, changepasswordstr, checkoutstr, seeroomstr, seesurgeonstr, seesurgerydetailsstr, logoutstr);
        }
        switch(option)
        {
            case displaydetailsint:
            activePatient.displayPatientDetails();
            break;

            case changepasswordint:
            activeUser.changePassword();
            activePatient.UserPassword = activeUser.UserPassword;
            return true;
            break; 

            case checkinoutint:
            if(!activePatient.userCheckedIn)
            {
                
                activePatient.checkIn();
            }
            else
            {
                activePatient.checkOut();
            }
            break;

            case seeroomint:
            activePatient.patientSeeRoom();
            return true;
            break;

            case seesurgeonint:
            activePatient.patientSeeSurgeon();
            return true;
            break;

            case seesurgerydetailsint:
            activePatient.patientSeeSurgeryDate();
            return true;
            break;

            case logoutint:
            CMDLine.displayMessage($"Patient {activePatient.UserName} has logged out.");
            activeUser = null;
            activePatient = null;
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
        const string assignsurgerystr = "Assign surgery";
        const string unassignroomstr = "Unassign room";
        const string floorlogoutstr = "Log out";

        const int  floordisplaydetailsint = 0, floorchangepasswordint = 1, assignroomint = 2, assignsurgeryint = 3, unassignroomint = 4, floorlogoutint = 5;

        int option = CMDLine.GetOption(titlestr, floordisplaydetailsstr, floorchangepasswordstr, assignroomstr, assignsurgerystr, unassignroomstr, floorlogoutstr);

        switch(option)
        {
            case floordisplaydetailsint:
            activeFloorManager.displayFloorManagerDetails();
            return true;
            break;

            case floorchangepasswordint:
            activeUser.changePassword();
            activeFloorManager.UserPassword = activeUser.UserPassword;
            return true;
            break;

            case assignroomint:
            activeFloorManager.assignPatientToRoom();
            return true;
            break;

            case assignsurgeryint:
            activeFloorManager.assignSurgeryToPatient();
            return true;
            break;

            case unassignroomint:
            /*CurrentlyLoggedIn.seeSurgeon();*/
            return false;
            break;

            case floorlogoutint:
            CMDLine.displayMessage($"Floor manager {activeUser.UserName} has logged out.");
            activeUser = null;
            activeFloorManager = null;
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option. Please try again.");
            break;
        }
        return true;
    }

    /// <summary>
    /// Method that sets up the workings of the surgeon menu. Works the same as other "setup" methods.
    /// </summary>
    /// <returns></returns>
    private bool SurgeonMenu()
    {
        bool keepRunningSurgeonMenu = true;

        while(keepRunningSurgeonMenu)
        {
            keepRunningSurgeonMenu = displaySurgeonMenu();
        }

        return keepRunningSurgeonMenu;
    }

    /// <summary>
    /// Method that displays the Menu for all Surgeon activities.
    /// </summary>
    /// <returns></returns>
    private bool displaySurgeonMenu() 
    {

        CMDLine.displayMessage();
        CMDLine.displayMessage("Surgeon Menu.");
        
        const string titlestr = "Please choose from the menu below:";
        const string surgeondisplaydetailsstr = "Display my details";
        const string surgeonchangepasswordstr = "Change password";
        const string surgeonseepatientsstr = "See your list of patients";
        const string surgeonseeschedulestr = "See your schedule";
        const string surgeonperformsurgerystr = "Perform surgery";
        const string surgeonlogoutstr = "Log out";

        const int  surgeondisplaydetailsint = 0, surgeonchangepasswordint = 1, surgeonseepatientsint = 2, surgeonseescheduleint = 3, surgeonperformsurgeryint = 4, surgeonlogoutint = 5;

        int option = CMDLine.GetOption(titlestr, surgeondisplaydetailsstr, surgeonchangepasswordstr, surgeonseepatientsstr, surgeonseeschedulestr, surgeonperformsurgerystr, surgeonlogoutstr);

        switch(option)
        {
            case surgeondisplaydetailsint:
            activeSurgeon.displaySurgeonDetails();
            return true;
            break;

            case surgeonchangepasswordint:
            activeUser.changePassword();
            activeSurgeon.UserPassword = activeUser.UserPassword;
            return true;
            break;

            case surgeonseepatientsint:
            activeSurgeon.seePatients();
            return true;
            break;

            case surgeonseescheduleint:
            activeSurgeon.seeSchedule();
            return true;
            break;

            case surgeonperformsurgeryint:
            activeSurgeon.performSurgery();
            return true;
            break;

            case surgeonlogoutint:
            CMDLine.displayMessage($"Surgeon {activeUser.UserName} has logged out.");
            activeUser = null;
            activeSurgeon = null;
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option. Please try again.");
            break;
        }
        return true;
    } 



    } 