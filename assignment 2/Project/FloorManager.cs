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
    
    public void assignPatientToRoom()
    {
        List<string> patientSelect = new List<string>();
        string assignPatientStr = "Please select your patient:";
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(Menu.Patients[i].patientsRoom != 0)
            {
                patientSelect.Add(Menu.Patients[i].UserName);
            }
        }
        int patientToAssign = CMDLine.GetOptionList(assignPatientStr, patientSelect);
        CMDLine.displayMessage("Please enter your room (1-10):");
        int roomAssign = CMDLine.getInt();
        Menu.Patients[patientToAssign].patientsRoom = roomAssign;
        Menu.Patients[patientToAssign].patientsFloor = UserFloorNumber;
        CMDLine.displayMessage($"Patient {Menu.Patients[patientToAssign].UserName} has been assigned to room number {roomAssign} on floor {UserFloorNumber}.");


    }


}