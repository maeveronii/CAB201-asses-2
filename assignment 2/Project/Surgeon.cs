using System.IO.Pipes;
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

    /// <summary>
    /// Displays the surgeon objects details
    /// </summary>
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

    /// <summary>
    /// Displays all UserNames of all patients assigned to the surgeon object
    /// </summary>
    public void seePatients()
    {
        if(Menu.Patients.Count() < 1)
        {
            CMDLine.displayMessage("Your Patients.");
            CMDLine.displayMessage("You do not have any patients assigned.");
            return;
        }
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

    /// <summary>
    /// Displays all upcoming surgeries for the surgeon object
    /// </summary>
    public void seeSchedule()
    {
        if(Menu.Patients.Count() < 1)
        {
            CMDLine.displayMessage("Your schedule.");
            CMDLine.displayMessage("You do not have any patients assigned.");
            return;
        }
        List<DateTime> patientSurgeryDisplayDate = new List<DateTime>();
        List<string> patientSurgeryDisplayName = new List<string>();
        CMDLine.displayMessage("Your schedule.");
        for(var i = 0; i < Menu.Patients.Count(); i++)
        {
            if(!Menu.Patients[i].userSurgeryPerformed)
            {
                patientSurgeryDisplayDate.Add(Menu.Patients[i].patientsSurgeryTime);
            }
        }
        patientSurgeryDisplayDate.Sort((a, b) => a.CompareTo(b));

        for(var i = 0; i < Menu.Patients.Count(); i++) // TO- DO: Figure out how to get this working, see multiple surgeries
        {
            //if(patientSurgeryDisplayDate[i] == Menu.Patients[i].patientsSurgeryTime)
            //{
             CMDLine.displayMessage($"Performing surgery on patient {Menu.Patients[i].UserName} on {Menu.Patients[i].patientsSurgeryTime.ToString(DATETIMEconst.DATETIMEFORMAT)}");
            //}
        }


    }

    /// <summary>
    /// Performs surgery on a scheduled patient, swapping a bool value
    /// </summary>
    public void performSurgery()
    {
        if(Menu.Patients.Count() < 1)
        {
            CMDLine.displayMessage("Your Patients.");
            CMDLine.displayMessage("You do not have any patients assigned.");
            return;
        }
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