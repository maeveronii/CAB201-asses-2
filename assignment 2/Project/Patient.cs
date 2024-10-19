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

    public void displayPatientDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
        }

    public void checkIn()
    {
        userCheckedIn = true;
        CMDLine.displayMessage($"Patient {UserName} has been checked in.");
    }

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

    public void patientSeeSurgeryDate()
    {
        if(!String.IsNullOrEmpty(patientsSurgeryTime.ToString(DATETIMEconst.DATETIMEFORMAT)))
        {
            CMDLine.displayMessage($"Your surgery time is {patientsSurgeryTime.ToString(DATETIMEconst.DATETIMEFORMAT)}.");
        }

        else
        {
            CMDLine.displayMessage("You do not have an assigned surgery.");
        }
    }

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