using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Hospital;

class Patient : User
{
    public bool checkedIn {get; set;}
    public string patientsSurgeon {get; set;}
    public int patientsRoom {get; set;}
    public Patient(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType)
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
    
}