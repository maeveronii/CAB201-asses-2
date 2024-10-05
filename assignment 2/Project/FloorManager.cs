namespace Hospital;

class FloorManager : Staff
{
    public int UserFloorNumber {get; set;}
    public FloorManager(string userName, int userAge, int userMobile, string userEmail, string userPassword, int userStaffID, int userFloorNumber)
        :base(userName, userAge, userMobile, userEmail, userPassword, userStaffID)
    {
        UserFloorNumber = userFloorNumber;
    }
}