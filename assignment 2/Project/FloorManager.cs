using System.Diagnostics;
using System.Reflection;

namespace Hospital;

public class FloorManager : Staff
{
    //List<Patient> Patients = Menu.GetPatientList();
    public int UserFloorNumber {get; set;}
    public FloorManager(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, int userStaffID, int userFloorNumber)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType, userStaffID)
    {
        UserFloorNumber = userFloorNumber;
    }

    public FloorManager()
    {

    }

    /// <summary>
    /// Displays the floor managers details
    /// </summary>
    public void displayFloorManagerDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
            CMDLine.displayMessage($"Staff ID: {UserStaffID}");
            CMDLine.displayMessage($"Floor: {UserFloorNumber}.");
        }
    
    /// <summary>
    /// Assigns patients that do not already have a room, and are checked in, to a room.
    /// </summary>
    public void assignPatientToRoom()
    {
        if(Menu.Patients.Count() < 1)
        {
            CMDLine.displayMessage("There are no registered patients.");
            return;
        }
        
        int roomAssign;
        int patientToAssignInt;
        List<string> patientSelect = new List<string>();
        string assignPatientStr = "Please select your patient:";
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(Menu.Patients[i].patientsRoom == 0)
            {
                patientSelect.Add(Menu.Patients[i].UserName);
            }
        }
        patientToAssignInt = CMDLine.GetOptionList(assignPatientStr, patientSelect); //TO-DO: Change this to include possibility of out-of-range option (if patienttoassignint > menu.count || patienttoassignint < 1)
        do{
            CMDLine.displayMessage("Please enter your room (1-10):");
            roomAssign = CMDLine.getInt();
            if(roomAssign < 0 || roomAssign > 10 )
            {
                CMDLine.displayError("#Error - Supplied value is out of range, please try again.");
            }
        }while(roomAssign < 0 || roomAssign > 10);
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            //CMDLine.displayMessage(Menu.Patients[i].UserName);
            if(patientSelect[patientToAssignInt] == Menu.Patients[i].UserName)
            {
                Menu.Patients[i].patientsRoom = roomAssign;
                Menu.Patients[i].patientsFloor = UserFloorNumber;
                CMDLine.displayMessage($"Patient {Menu.Patients[i].UserName} has been assigned to room number {roomAssign} on floor {UserFloorNumber}.");
            }
        }
    }

    /// <summary>
    /// Assigns patients that have a room a surgeon, and surgery.
    /// </summary>
    public void assignSurgeryToPatient()
    {
        if(Menu.Patients.Count() < 1)
        {
            CMDLine.displayMessage("There are no registered patients.");
            return;
        }
        //if(Menu.Patients.All.userCheckedIn == false)
        //{

        //}
        int patientToAssignSurgeryInt;
        List<string> patientSurgerySelect = new List<string>();
        string assignPatientStr = "Please select your patient:";
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(String.IsNullOrEmpty(Menu.Patients[i].patientsSurgeon) && Menu.Patients[i].patientsRoom != 0)
            {
                patientSurgerySelect.Add(Menu.Patients[i].UserName);
            }
            //patientSurgerySelect.Add(Menu.Patients[i].UserName);
        }
        patientToAssignSurgeryInt = CMDLine.GetOptionList(assignPatientStr, patientSurgerySelect); //TO-DO: Change this to include possibility of out-of-range option (if patienttoassignint > menu.count || patienttoassignint < 1)
        

        int surgeonToAssignSurgeryInt;
        List<string> surgeonSelect = new List<string>();
        string assignSurgeonStr = "Please select your surgeon:";
        for(var i = 0; i < Menu.Surgeons.Count(); i++)
        {
            surgeonSelect.Add(Menu.Surgeons[i].UserName);
            //CMDLine.displayMessage(Menu.Surgeons[i].UserName);
        }
        surgeonToAssignSurgeryInt = CMDLine.GetOptionList(assignSurgeonStr, surgeonSelect); 
    

        CMDLine.displayMessage("Please enter a date and time (e.g. 14:30 31/01/2024)."); //get the datetime (hard)
        DateTime dateOfSurgery = CMDLine.GetDateTime();

        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(patientSurgerySelect[patientToAssignSurgeryInt] == Menu.Patients[i].UserName)
            {
            //assigning fields
            Menu.Patients[i].patientsSurgeon = Menu.Surgeons[surgeonToAssignSurgeryInt].UserName;
            Menu.Patients[i].patientsSurgeryTime = dateOfSurgery;

            CMDLine.displayMessage($"Surgeon {Menu.Surgeons[surgeonToAssignSurgeryInt].UserName} has been assigned to patient {Menu.Patients[i].UserName}.");                                        
            CMDLine.displayMessage($"Surgery will take place on {dateOfSurgery.ToString(DATETIMEconst.DATETIMEFORMAT)}.");
            }
        }
    }

}