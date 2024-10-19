using System.Security.Cryptography.X509Certificates;

namespace Hospital;

public class Surgeon : Staff
{
    public string UserSpecialty {get; set;}
    public Surgeon(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, int userStaffID, string userSpecialty)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType, userStaffID)
    {
        UserSpecialty = userSpecialty;
    }

    public Surgeon()
    {

    }

    public void displaySurgeonDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
            CMDLine.displayMessage($"Staff ID: {UserStaffID}");
            CMDLine.displayMessage($"Speciality: {UserSpecialty}");
        }

    public void seePatients()
    {
        int numToGoUp = 1;
        CMDLine.displayMessage("Your Patients.");
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(!Menu.Patients[i].userSurgeryPerformed)
            {
                CMDLine.displayMessage($"{numToGoUp}. {Menu.Patients[i].UserName}");
                numToGoUp += 1;
            }
        }
    }
    public void performSurgery()
    {
        int patientSurgeryInt;
        List<string> patientSelect = new List<string>();
        string assignPatientStr = "Please select your patient:";
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(!Menu.Patients[i].userSurgeryPerformed)
            {
                patientSelect.Add(Menu.Patients[i].UserName);
            }
        }
        patientSurgeryInt = CMDLine.GetOptionList(assignPatientStr, patientSelect);


        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(patientSelect[patientSurgeryInt] == Menu.Patients[i].UserName)
            {
           //assigning values
            Menu.Patients[i].userSurgeryPerformed = true;

            CMDLine.displayMessage($"Surgery performed on {Menu.Patients[i].UserName} by {UserName}.");

            }
        }


    }

}