using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Hospital;

public class Patient : User
{
    public bool userCheckedIn {get; set;}
    public bool userSurgeryPerformed {get; set;}
    public string patientsSurgeon {get; set;}
    public DateTime patientsSurgeryTime {get; set;}
    public int patientsRoom {get; set;}
    public int patientsFloor {get; set;}
    public Patient(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, bool userCheckedIn, bool userSurgeryPerformed, string patientsSurgeon, DateTime patientsSurgeryTime, int patientsRoom, int patientsFloor)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType)
    {

    }

    public Patient()
    {

    }

    /// <summary>
    /// Displays the patients details
    /// </summary>
    public void displayPatientDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
        }

    /// <summary>
    /// Swaps the bool value userCheckedIn to check in the patient
    /// </summary>
    public void checkIn()
    {
        userCheckedIn = true;
        CMDLine.displayMessage($"Patient {UserName} has been checked in.");
    }

    /// <summary>
    /// Checks the patient out, but only if they have had surgery performed on them
    /// </summary>
    public void checkOut()
    {
        if(userCheckedIn && userSurgeryPerformed)
        {
            CMDLine.displayMessage($"Patient {UserName} has been checked out.");
            userCheckedIn = false;
        }
        else if(!userCheckedIn)
        {
            CMDLine.displayError("Error - You are unable to check out at this time.");
        }
        else if(userCheckedIn && !userSurgeryPerformed)
        {
            CMDLine.displayError("Error - You are unable to check out at this time.");
        }
    }

    /// <summary>
    /// Allows patient to see what room, if any, they have been assigned
    /// </summary>
    public void patientSeeRoom()
    {
        if(patientsRoom != 0 && patientsFloor != 0)
        {
            CMDLine.displayMessage($"Your room is number {patientsRoom} on floor {patientsFloor}.");
        }

        else if(patientsRoom == 0)
        {
            CMDLine.displayMessage("You do not have an assigned room.");
        }
    }

    /// <summary>
    /// Allows patient to see their assigned surgery
    /// </summary>
    public void patientSeeSurgeryDate()
    {
        if(!String.IsNullOrEmpty(patientsSurgeryTime.ToString(DATETIMEconst.DATETIMEFORMAT))) //DOESNT WORK
        {
            CMDLine.displayMessage($"Your surgery time is {patientsSurgeryTime.ToString(DATETIMEconst.DATETIMEFORMAT)}.");
        }

        else
        {
            CMDLine.displayMessage("You do not have an assigned surgery.");
        }
    }

    /// <summary>
    /// Allows patient to see their assigned surgeon
    /// </summary>
    public void patientSeeSurgeon()
    {
        if(!String.IsNullOrEmpty(patientsSurgeon))
        {
            CMDLine.displayMessage($"Your surgeon is {patientsSurgeon}.");
        }

        else
        {
            CMDLine.displayMessage("You do not have an assigned surgeon.");
        }
    }


    
}