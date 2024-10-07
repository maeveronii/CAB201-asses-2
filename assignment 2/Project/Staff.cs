namespace Hospital;

class Staff : User
{
    public int UserStaffID {get; set;}
    public Staff(string userName, int userAge, string userMobile, string userEmail, string userPassword, string userType, int userStaffID)
        :base(userName, userAge, userMobile, userEmail, userPassword, userType)
    {
        UserStaffID = userStaffID;
    }
}