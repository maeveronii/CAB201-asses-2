namespace Hospital;

class Staff : User
{
    public int UserStaffID {get; set;}
    public Staff(string userName, int userAge, int userMobile, string userEmail, string userPassword, int userStaffID)
        :base(userName, userAge, userMobile, userEmail, userPassword)
    {
        UserStaffID = userStaffID;
    }
}