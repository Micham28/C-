//this is a mark 2 version because the first time I went through it the code failed to load properly litterally I dont know if it was confusing to follow or is visual studio downloaded weird but we will find out which
////Michael McAlexander
// TInfo 200 - L6        Due 2022-03-05
/////////////////////////////////////////////////////////////////////
//the purpose of this application is an interactive student database program.
//Change History
//Date          Developer       Description
//2022-02-10    Michael         start program
//2022-02-14    Micahel         full-auto and read write (error occured moving on without testing)
//2022-02-16    Michael         Grad-undergrad (big error happend here wont opne or read/write output ot input)
//2022-02-23    Michael         CRUD
//2022-03-02    Michael         SQL
//2022-03-03    Michael         trying to fix errors that occured, restar complete process. litterally no way to progress. broke on double gpa as well on second write my code just doesnt seem to want to run. STR on undergrads popped an error despite following the video to the letter. (executes rebuild with no error response)
//2022-03-04    Michael         gave up trying to fix the ghosts in my machine, it just seems to create a new probelm that isnt one. Ive compaired with the viedo provided mine is a near perfect match. working on CRUd and possibly the modify funct.
//2022-03-04    Michael         got the program to work with chucks help modifier is displaying a similar issues with the same parameters that had already been fixed this morning. dont understand whats happening. not sure if I am able to get it fully implimented.
//2022-03-05    Michael         finally cracked it forgot to call the varriables from their individual .CS files so they werent able to ativate until that change.
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentDB
{//main program that calls the other data files.
    internal class DbApp { 
        //use constant identifier for the filename
        public const string STUDENT_DATAFILE = "STUDENT_DATAFILE.txt";
        public const string STUDENT_DATAFILE_OUTPUT = "STUDENT_DATAFILE.txt";


        //main database for the storage for runtime when the db is executing
        private List<Student> students = new List<Student>();


        //main database engine application loop

        public DbApp()
        {//seed the database if currently testing. without input file.
            //SeedDatabaseList();

            //continue testing using the input file
            ReadDataFromInputFile();
        }

        private void ReadDataFromInputFile()
        {
            //1 - construct the obj needed to read in from a file on the disk
            StreamReader inFile = new StreamReader(STUDENT_DATAFILE);
        //2 - use the reader obj to continually read data
        string studentType;
        //reading in a single student record
        while ((studentType = inFile.ReadLine()) != null)
        {
                //for each student in the file
                string firstName = inFile.ReadLine();
                string lastName = inFile.ReadLine();
                double gpa = double.Parse(inFile.ReadLine());
                string email = inFile.ReadLine();
                DateTime date = DateTime.Parse(inFile.ReadLine());

                if (studentType == "StudentDB.Undergrad")
                {
                    //read the undergrad additional props
                    YearRank year = (YearRank)Enum.Parse(typeof(YearRank),inFile.ReadLine());
                    string major = inFile.ReadLine();
                    //now that we have the undergrads, we want to make a specific type of student this example uses the 2 step procedure
                    Undergrad undergrad = new Undergrad(firstName, lastName, gpa, email, date, year, major);
                    students.Add(undergrad);
                }
                else if (studentType == "StudentDB.GradStudent")
                {
                    decimal credit = decimal.Parse(inFile.ReadLine());
                    string advisor = inFile.ReadLine();

                    //make student obj and insert into the list
                    students.Add(new GradStudent(firstName, lastName, gpa, email, date, credit, advisor));
                }

        }
            //3 - release the resources used 
            inFile.Close();
        }

        internal void Run()
        {
            while(true)
            {
                //display menue of choices to the user
                DisplayMainMenu();
                //get user selection and execute that module
                char selection = GetUserSelection();

                switch (selection)
                {
                    case 'C':
                    case 'c':
                        CreateStudentRecord();
                        break;
                    case 'D':
                    case 'd':
                        DeleteStudentRecord();
                        break;
                    case 'P':
                    case 'p':
                        PrintAllStudentRecords();
                        break;
                    case 'S':
                    case 's':
                        SaveAllStudentDataToOutputFile();
                        break;
                    case 'F':
                    case 'f':
                        string email = string.Empty;
                        FindStudentRecord(out email);
                        break;
                    case 'M':
                    case 'm':
                        ModifyStudentRecord();
                        break;
                    case 'E':
                    case 'e':
                        SaveAllStudentDataToOutputFile();
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ERROR: sorry that wasn't a choice. Select again.");
                        break;
                }
            }
        }

        private void ModifyStudentRecord()
        {
            //slelection menu that reloads when wrong break is executed
            //RECORD was not found, start gathering all the needed information for a new undergrad or grad
            while (true)//if user miss clicks and doesnt use a letter on the list the program is forgiving and will come back up.
            {//opens menu
                DisplayMainMenu2();
                //selection choice ability
                switch (Console.ReadLine())//asks for user direct input removes the need for char ...()
                {
                    case "F":
                    case "f":
                        FirstNameEdit();
                        break;
                    case "L":
                    case "l":
                        LastNameEdit();
                        break;
                    case "G":
                    case "g":
                        GpaEdit();
                        break;
                    case "M":
                    case "m":
                        EmailEdit();
                        break;
                    case "R":
                    case "r":
                        RankEdit();
                        break;
                    case "D":
                    case "d":
                        DegreeEdit();
                        break;
                    case "C":
                    case "c":
                        CreditEdit();
                        break;
                    case "S":
                    case "s":
                        StaffEdit();
                        break;
                    case "E":
                    case "e":
                        SaveAllStudentDataToOutputFile();
                        System.Environment.Exit(0);//exit and save point
                        break;
                    default://ensures user isnt lost
                        Console.WriteLine("ERROR: Function not found. Please try again.");
                        break;
                }
            }
        }

        private void EmailEdit()
        {//set so string value is ready to accept an email as question
            //tells the function to find email associated with the account
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            //create options so the student files dont get messed up and so that the user can edit the correct option and not create errors
            char letterselect = GetUserSelection();
            //setting up case instances to gather info from the right list
            if (letterselect == 'U')
            {//if student is under grad it pulls information from undergrad list that is brought and written over here.
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Last Name: ");
                    //telling the string that email will be overwritten
                    string nemail = Console.ReadLine();
                    //storing it in the contact then correct undergrad string list.
                    stuone.Info.EmailAddress = nemail;
                }
                else
                {//if user makes any other options than what is availible to them it will come up as generic error.
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else if (letterselect == 'G')
            {//same for undergrad but calls the undergrad list
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Last Name: ");
                    string nemail = Console.ReadLine();
                    stuone.Info.EmailAddress = nemail;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        //functions are set up in similar fashion 
        //function is called and I complete this by using a similar call to the Find() Create() and Read() 
        //thinking about how to put the lsit first then get the changes ability set up.
        private void StaffEdit()
        {//tells the function to find email associated with the account
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'G') {
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Faculty Advisor: ");
                    string nadvise = Console.ReadLine();
                    stuone.FacultyAdvisor = nadvise;
                }
                else
                {// since this particular function doesnt require the other set as an option to access the undergrad list of variables the user gets an error messege.
                    Console.WriteLine("ERROR: you can't put a graduate file descriptor into an undergraduate file.");
                }
                
            }
            else
            { //if the user selectionis out of bounds
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void CreditEdit()
        {
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'G')
            {
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct credit: ");
                    decimal ncredit = decimal.Parse(Console.ReadLine());
                    stuone.TuitionCredit = ncredit;
                }
                else
                {
                    Console.WriteLine("ERROR: you can't put a graduate file descriptor into an undergraduate file.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void DegreeEdit()
        {
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'U')
            {
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct major program: ");
                    string nmajor = Console.ReadLine();
                    stuone.DegreeMajor = nmajor;
                }
                else
                {
                    Console.WriteLine("ERROR: you can't put a undergraduate file descriptor into an graduate file.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void RankEdit()
        {
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'U')
            {
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Year/Rank ([1] Freshman [2] Sophomore [3] Junior [4] Senior): ");
                    YearRank nyear = (YearRank)int.Parse(Console.ReadLine());
                    stuone.Rank = nyear;
                }
                else
                {
                    Console.WriteLine("ERROR: you can't put a undergraduate file descriptor into an graduate file.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void DisplayMainMenu2()
        {//second user menu or gui
            Console.WriteLine(@"
***********************************************************
********** Student DB Modify Menu *************************
***********************************************************

Make a User selection by entering the letter in the box.

[F]irst Name Edit
[L]ast Name Edit
[G]rade Point Average Edit
E[M]ail Edit
[R]ank/Year Edit
[D]egree Edit
[C]redit Edit
[S]taff Edit
[E]xit the database (with save)
****** User Selection: ");
        }

        
        private void GpaEdit()
        {//same option as the rest except for these generical calls we gather fromseparated lists undergrad and grad so that when the string or double is added back into the list there are not unexpected varribles.
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'U')
            {
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct GPA: ");
                    double ngpa = double.Parse(Console.ReadLine());
                    stuone.GradePtAve = ngpa;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else if (letterselect == 'G')
            {
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct GPA: ");
                    double ngpa = double.Parse(Console.ReadLine());
                    stuone.GradePtAve = ngpa;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void LastNameEdit()
        {
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'U')
            {
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Last Name: ");
                    string nlast = Console.ReadLine();
                    stuone.Info.LastName = nlast;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else if (letterselect == 'G')
            {
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct Last Name: ");
                    string nlast = Console.ReadLine();
                    stuone.Info.LastName = nlast;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }

        }

        private void FirstNameEdit()
        {
            string email = string.Empty;
            Console.WriteLine("\n Is this a [G]raduate or [U]ndergraduate student? to continue please type a selection: ");
            char letterselect = GetUserSelection();
            if (letterselect == 'U')
            {
                Undergrad stuone = (Undergrad)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct First Name: ");
                    string nfirst = Console.ReadLine();
                    stuone.Info.FirstName = nfirst;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else if (letterselect == 'G')
            {
                GradStudent stuone = (GradStudent)FindStudentRecord(out email);
                if (stuone != null)
                {
                    Console.WriteLine($"{stuone}");
                    Console.Write("what is the students new/correct First Name: ");
                    string nfirst = Console.ReadLine();
                    stuone.Info.FirstName = nfirst;
                }
                else
                {
                    Console.Write("ERROR: this is not an availible option.");
                }
            }
            else
            {
                Console.Write("ERROR: this is not an availible option.");
            }
        }

        private void DeleteStudentRecord()
        {
            //call the find operation to see if the canidate email (record for deletion) is already in the list<> - it has to be in the list for the delete to take place
            string email;
            Student stu = FindStudentRecord(out email);

            if (stu != null)
            {
                //yes we can do the deletion
                students.Remove(stu);
                Console.WriteLine($"{email}***** RECORD FOUND. \nNo longer in database: {email}.\n");
            }
            else
            {
                //no we cant do the deletion
                Console.WriteLine($"{email}***** RECORD NOT FOUND. \nCan't delete record for user: {email}.\n");
            }
        }

        private void CreateStudentRecord()
        {
            //cheack for presence of a desired email address
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if(stu == null)
            {
                //sunny day scenario for add student
                //RECORD was not found, start gathering all the needed information for a new undergrad or grad
                Console.WriteLine("ENTER the fisrt name: ");
                string first = Console.ReadLine();
                Console.WriteLine("ENTER the last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("ENTER the grade pt avg: ");
                double gpa = double.Parse(Console.ReadLine());
                //don't get enroll data - generated by system | dont get email already have it
                Console.WriteLine("[U]ndergrad or [G]rad student? ");
                string studentType = Console.ReadLine().ToUpper();
                if(studentType == "U")
                {
                    //getting year in school is a bit of work
                    Console.WriteLine("[1]Fresham [2]Sophomore [3]Junior [4]Senior: ");
                    Console.Write("ENTER the Year/Rank in school: ");
                    YearRank rank = (YearRank)int.Parse(Console.ReadLine());

                    //get the major
                    Console.Write("ENTER the degree major: ");
                    string major = Console.ReadLine();

                    //make a new student of type undergrad and add to the list<>
                    Undergrad undergrad = new Undergrad(first, last, gpa, email, DateTime.Now, rank, major);
                    Console.WriteLine($"Adding new UnderGrad Student to database: \n{undergrad}");
                    students.Add(undergrad);
                }
                else if(studentType == "G")
                {//tuition
                    Console.Write("ENTER TUITION REIMBURSEMENT AMOUNT: ");
                    decimal tuition = decimal.Parse(Console.ReadLine());
                    //advisior
                    Console.Write("ENTER the faculty advisor: ");
                    string advisor = Console.ReadLine();
                    //make a new student of type undergrad and add to the list<>
                    GradStudent grad = new GradStudent(first, last, gpa, email, DateTime.Now, tuition, advisor);
                    //can add if stament incase of issue.
                    Console.WriteLine($"Adding new Grad Student to database: \n{grad}");
                    students.Add(grad);
                    
                }
                else
                {
                    Console.WriteLine($"ERROR: no student type matches {studentType}");
                }

            }
            else
            {
                //email was FOUND - rainy day for creating a new student
                Console.WriteLine($"{email} RECORD FOUND! Can't add a student with email: {email}");
            }
        }

        //searches current list <> for a student record output - returns the student if FOUND and null if NOT FOUND
        //inputs - 
        private Student FindStudentRecord(out string email)
        {
            //get search string from the user
            Console.WriteLine("\nEnter email addres (primary key) to search:");
            email = Console.ReadLine();

            foreach (var stu in students)
            {
                if(email == stu.Info.EmailAddress)
                {
                    //FOUND EMAIL IN THE LIST<>
                    Console.WriteLine($"FOUND email address: {stu.Info.EmailAddress}");
                    return stu;
                }
            }
            //did not find the passed in search string
            Console.WriteLine($"{email} NOT FOUND.");
            return null;
        }

        private void SaveAllStudentDataToOutputFile()
        {
            // 1 - create the file obj and attach it to the file on disk
            StreamWriter outFile = new StreamWriter(STUDENT_DATAFILE_OUTPUT);

            //2 - use the file - the same way you would use any stream writer
        Console.WriteLine("**** SAVING ALL RECORDS TO OUTPUT FILE ****");
            
            foreach (var stu in students)
            {
                //TODO: when testing complete remove this "console" echo to the shell
                outFile.WriteLine(stu.ToStringForOutputFile());

                Console.WriteLine(stu.ToStringForOutputFile());
            }

        Console.WriteLine("**** DONE SAVING ALL RECORDS TO OUTPUT FILE ****");

            //3 - release the resource - close the file
            outFile.Close();
        }

        //prints all the students records to the shell 
        //TODO: eventually when the db gets large this method will have to be modified so that the output is not overwhelming. we will think of a better design for when the db grows large.
        private void PrintAllStudentRecords()
        {
            Console.WriteLine("**** PRINTING ALL RECORDS ****");
            foreach(var stu in students)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine("**** DONE PRINTING ALL RECORDS ****");
        }
        //wanted to change the mechanism of getting char from the user so that s/he only has to type the actual selection, and not worry about Enter Afterwards.
        //want to change how this method does not what it does
        private char GetUserSelection()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.KeyChar;
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"
**************************************************
********** Student DB Main Menu ******************
**************************************************

Make a User selection by entering the first letter.

[C]reate a student record
[D]elete a student record
[P]rint all records
[S]ave records without exit
[F]ind a student record
[M]odify a student record
[E]xit the database (with save)
****** User Selection: ");

        }

        //public void SeedDatabaseList()
        //{
            //the first way to add student to teh list
            //Student stu1 = new Student("Alice", "Anderson", 3.9, "aanderson@uw.edu", DateTime.Now);
            //students.Add(stu1);
            //the 1 stepo method call to add to database
            //students.Add(new Student("Bob", "Bradshaw", 3.7, "bbradshaw@uw.edu", DateTime.Now));
           // students.Add(new Student("Carlos", "Cast", 3.7, "ccast@uw.edu", DateTime.Now));
           // students.Add(new Student("David", "Davis", 3.0, "ddavis@uw.edu", DateTime.Now));
       // }
    }
}