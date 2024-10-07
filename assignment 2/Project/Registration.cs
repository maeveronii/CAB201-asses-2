namespace Hospital;

public partial class Menu
//handles all registration functions
{
    /// <summary>
    /// Works the same as all other bool creation methods.
    /// </summary>
    /// <returns></returns>
    private bool registerMenu()
    {
        bool keepRunningRegisterMenu = true;

        while(keepRunningRegisterMenu)
        {
            keepRunningRegisterMenu = displayRegisterMenu();
        }

        return keepRunningRegisterMenu;
    }

    /// <summary>
    /// Creates a menu asking the user to register as a certain type of user. Works the same as all other menus.
    /// </summary>
    /// <returns></returns>
    private bool displayRegisterMenu() 
    {

        CMDLine.displayMessage();

        const string CHOOSEUSERTYPESTR = "Register as which type of user:";
        const string CHOOSEPATIENTSTR = "Patient";
        const string CHOOSESTAFFSTR = "Staff";
        const string RETURNTOMAINMENUSTR = "Return to the first menu";

        const int  CHOOSEPATIENTINT = 0, CHOOSESTAFFINT = 1, RETURNTOMAINMENUINT = 2;

        int option = CMDLine.GetOption(CHOOSEUSERTYPESTR, CHOOSEPATIENTSTR, CHOOSESTAFFSTR, RETURNTOMAINMENUSTR);

        switch(option)
        {
            case CHOOSEPATIENTINT:
            registerPatientMenu();
            return false;
            break;

            case CHOOSESTAFFINT:
            registerStaffMenu();
            return false;
            break;

            case RETURNTOMAINMENUINT:
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option, please try again.");
            return false;
            break;
        }
        return true;
    }

    /// <summary>
    /// Method used to register as a patient. At the end of method, gathers all information used and creates a new "Patient" object with the data as constructors.
    /// </summary>
    private void registerPatientMenu()
    {
        CMDLine.displayMessage("Registering as a patient.");
        CMDLine.displayMessage("Please enter in your name:");
        name = CMDLine.getString();
            

        while(age < 1 || age > 100) 
        {
            CMDLine.displayMessage("Please enter in your age:");
            age = CMDLine.getInt();
            if (age < 0 || age > 100)
            {
                CMDLine.displayError("#Error - Supplied age is invalid, please try again.");
            }
            /*correctInt = int.TryParse(Console.ReadLine(), out age); straight up doesnt work

            switch (correctInt)
            {
                case false:
                CMDLine.displayError("#Error - Supplied value is not an integer, please try again.");
                break;

                case true:
                age = CMDLine.getInt();
                if (age < 0 || age > 100)
                {
                    CMDLine.displayError("#Error - Supplied age is invalid, please try again.");
                }
                break;
            }*/
        }

        CMDLine.displayMessage("Please enter in your mobile number:");
        int mobile = CMDLine.getInt();
        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();
        CMDLine.displayMessage("Please enter in your password:");
        string password = CMDLine.getString();

        Users.Add(new Patient(name, age, mobile, email, password));
        Patients.Add(new Patient(name, age, mobile, email, password));
        
        CMDLine.displayMessage($"{name} is registered as a patient.");

    }

    /// <summary>
    /// Method that sets up the workings of the staff registration menu. Works the same as other "setup" methods.
    /// </summary>
    /// <returns></returns>
    private bool registerStaffMenu()
    {
        bool keepRunningRegisterStaffMenu = true;

        while(keepRunningRegisterStaffMenu)
        {
            keepRunningRegisterStaffMenu = displayRegisterStaffMenu();
        }

        return keepRunningRegisterStaffMenu;
    }

    /// <summary>
    /// A method that displays the menu to register as a certain type of staff. Works the same as all other menus.
    /// </summary>
    /// <returns></returns>
    private bool displayRegisterStaffMenu() 
    {

        CMDLine.displayMessage();

        const string CHOOSESTAFFTYPESTR = "Register as which type of staff:";
        const string CHOOSEFLOORMANAGERSTR = "Floor manager";
        const string CHOOSESURGEONSTR = "Surgeon";
        const string RETURNTOMAINMENUSTR = "Return to the first menu";

        const int  CHOOSEFLOORMANAGERINT = 0, CHOOSESURGEONINT = 1, RETURNTOMAINMENUINT = 2;

        int option = CMDLine.GetOption(CHOOSESTAFFTYPESTR, CHOOSEFLOORMANAGERSTR, CHOOSESURGEONSTR, RETURNTOMAINMENUSTR);

        switch(option)
        {
            case CHOOSEFLOORMANAGERINT:
            registerFloorManagerMenu();
            return false;
            break;

            case CHOOSESURGEONINT:
            registerSurgeonMenu();
            return false;
            break;

            case RETURNTOMAINMENUINT:
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Invalid Menu Option. Please try again.");
            break;
        }
        return true;
    }

    /// <summary>
    /// Method used to register as a Floor Manager. At the end of method, gathers all information used and creates a new "FloorManager" object with the data as constructors.
    /// </summary>
    private void registerFloorManagerMenu()
    {
        CMDLine.displayMessage("Registering as a floor manager.");
        CMDLine.displayMessage("Please enter in your name:");
        name = CMDLine.getString();
            

        while(age < 21 || age > 70) 
        {
            CMDLine.displayMessage("Please enter in your age:");
            age = CMDLine.getInt();
            if (age < 21 || age > 70)
            {
                CMDLine.displayError("#Error - Supplied age is invalid, please try again.");
            }
        }

        CMDLine.displayMessage("Please enter in your mobile number:");
        int mobile = CMDLine.getInt();
        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();
        CMDLine.displayMessage("Please enter in your password:");
        string password = CMDLine.getString();

        while(staffID < 100 || staffID > 999) 
        {
            CMDLine.displayMessage("Please enter in your staff ID:");
            staffID = CMDLine.getInt();
            if (staffID < 100 || staffID > 999)
            {
                CMDLine.displayError("#Error - Supplied staff identification number is invalid, please try again.");
            }
        }

        while(floorNumber < 1 || floorNumber > 6) 
        {
            CMDLine.displayMessage("Please enter in your floor number:");
            floorNumber = CMDLine.getInt();
            if (floorNumber < 1 || floorNumber > 6)
            {
                CMDLine.displayError("#Error - Supplied floor is invalid, please try again.");
            }
        }
        
        


        Users.Add(new FloorManager(name, age, mobile, email, password, staffID, floorNumber));
        FloorManagers.Add(new FloorManager(name, age, mobile, email, password, staffID, floorNumber));
        
        CMDLine.displayMessage($"{name} is registered as a floor manager.");

    }

    /// <summary>
    /// Method used to register as a Surgeon. At the end of method, gathers all information used and creates a new "Surgeon" object with the data as constructors.
    /// </summary>
    private void registerSurgeonMenu()
    {
        CMDLine.displayMessage("Registering as a surgeon.");
        CMDLine.displayMessage("Please enter in your name:");
        name = CMDLine.getString();
            

        while(age < 30 || age > 75) 
        {
            CMDLine.displayMessage("Please enter in your age:");
            age = CMDLine.getInt();
            if (age < 30 || age > 75)
            {
                CMDLine.displayError("#Error - Supplied age is invalid, please try again.");
            }
        }

        CMDLine.displayMessage("Please enter in your mobile number:");
        int mobile = CMDLine.getInt();
        CMDLine.displayMessage("Please enter in your email:");
        string email = CMDLine.getString();
        CMDLine.displayMessage("Please enter in your password:");
        string password = CMDLine.getString();
        
        while(staffID < 100 || staffID > 999) 
        {
            CMDLine.displayMessage("Please enter in your staff ID:");
            staffID = CMDLine.getInt();
            if (staffID < 100 || staffID > 999)
            {
                CMDLine.displayError("#Error - Supplied staff identification number is invalid, please try again.");
            }
        }

        registerSurgeonSpecialty();
        
        Users.Add(new Surgeon(name, age, mobile, email, password, staffID, specialty));
        Surgeons.Add(new Surgeon(name, age, mobile, email, password, staffID, specialty));
        
        CMDLine.displayMessage($"{name} is registered as a surgeon.");

    }

    /// <summary>
    /// Works the same as all other bool creation menu methods.
    /// </summary>
    /// <returns></returns>
    private bool registerSurgeonSpecialty()
    {
        bool keepRunningSurgeonSpecialtyMenu = true;

        while(keepRunningSurgeonSpecialtyMenu)
        {
            keepRunningSurgeonSpecialtyMenu = registerSurgeonSpecialtyMenu();
        }

        return keepRunningSurgeonSpecialtyMenu;
    }

    /// <summary>
    /// Used for the user to decide upon a speciality for the Surgeon object they are creating. 
    /// Technically returns false when achieved, as all other menus do, however this also provides a string, "specialty", used in the creation of the Surgeon object.
    /// </summary>
    /// <returns></returns>
    private bool registerSurgeonSpecialtyMenu()
    {
        CMDLine.displayMessage();

        const string CHOOSESPECIALTYSTR = "Please choose your speciality:";
        const string CHOOSEGENERALSTR = "General Surgeon";
        const string CHOOSEORTHOPAEDICSTR = "Orthopaedic Surgeon";
        const string CHOOSECARDIOTHORACICSTR = "Cardiothoracic Surgeon";
        const string CHOOSENEUROSTR = "Neurosurgeon";
        

        const int  CHOOSEGENERALINT = 0, CHOOSEORTHOPAEDICINT = 1, CHOOSECARDIOTHORACICINT = 2, CHOOSENEUROINT = 3;

        int option = CMDLine.GetOption(CHOOSESPECIALTYSTR, CHOOSEGENERALSTR, CHOOSEORTHOPAEDICSTR, CHOOSECARDIOTHORACICSTR, CHOOSENEUROSTR);

        switch(option)
        {
            case CHOOSEGENERALINT:
            specialty = "General Surgeon";
            return false;
            break;

            case CHOOSEORTHOPAEDICINT:
            specialty = "Orthopaedic Surgeon";
            return false;
            break;

            case CHOOSECARDIOTHORACICINT:
            specialty = "Cardiothoracic Surgeon";
            return false;
            break;

            case CHOOSENEUROINT:
            specialty = "Neurosurgeon";
            return false;
            break;

            default:
            CMDLine.displayError("#Error - Non-valid speciality type, please try again.");
            break;
        }
        return true;
    }
}