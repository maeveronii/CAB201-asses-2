namespace Hospital;

class FloorManager : Staff
{
    public int UserFloorNumber {get; set;}
    public FloorManager(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, int userStaffID, int userFloorNumber)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType, userStaffID)
    {
        UserFloorNumber = userFloorNumber;
    }

    public void displayFloorManagerDetails()
        {
            CMDLine.displayMessage("Your details.");
            CMDLine.displayMessage($"Name: {UserName}");
            CMDLine.displayMessage($"Age: {UserAge}");
            CMDLine.displayMessage($"Mobile phone: {UserMobile}");
            CMDLine.displayMessage($"Email: {UserEmail}");
            CMDLine.displayMessage($"Staff ID: {UserStaffID}");
            CMDLine.displayMessage($"Floor: {UserFloorNumber}");
        }
}