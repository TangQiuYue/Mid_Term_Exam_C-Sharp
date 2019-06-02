using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Intra_Bourassa_Marie_Eve
{
    class Intra
    {
        static void Main(string[] args)

        {
         
            login();

        }

        private static void menu()
        {
            int choix;
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n***** STUDENT AND GRADE MANAGEMENT TOOL *****");
                Console.WriteLine("What would you like to do today? " +
                    "\n \n 1 - Add a new Student" +
                    "\n 2 - Show students in short format" +
                    "\n 3 - Show students in long format" +
                    "\n 4 - List students with their average" +
                    "\n 5 - Remove a student" +
                    "\n 6 - Leave this management tool");
                choix = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        addStudent();
                        returnToMenu("");
                        break;
                    case 2:
                        listStudentsShortFormat();
                        returnToMenu("");
                        break;
                    case 3:
                        listStudentsDetailedFormat();
                        returnToMenu("");
                        break;
                    case 4:
                        listStudentsAndAverage();
                        returnToMenu("");
                        break;
                    case 5:
                        removeStudent();
                        returnToMenu("");
                        break;
                    case 6:
                        leaveApp();
                        returnToMenu("");
                        break;
                    default:
                        Console.WriteLine("Your choice is invalide. Please select options 1 through 6");
                        returnToMenu("");
                        break;
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                returnToMenu("");
            }
        }

        private static void listStudentsAndAverage()
        {
            double average = 0;
            int count = 1;
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************The list is empty ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].Id != null)
                {
                    Console.WriteLine("\nID: " + student[i].Id + "\nLast Name: " + student[i].FamilyName + "\nFirst Name : " + student[i].FirstName);

                    for (int j = 0; j < course.Length; j++)
                    {
                        if (course[j].studentId != null && course[j].studentId.Equals(student[i].Id) && course[j].Grades != 0)
                                    average += course[j].Grades;
                                count++;
                            
                    }
                    Console.WriteLine("Average : " + average / count);
                }
            }
           
        }

        private static void login()
        {
            string username, nomUtil = "examen", password, mtp = "1234";

           
            if (count == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please contact the administration. \n\n\nGoodBye!.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("**********STUDENT AND GRADE MANAGEMENT TOOL***************");
            Console.WriteLine("\nEnter your username ");
            username = Console.ReadLine();

            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();

            if (!username.Equals(nomUtil) || !password.Equals(mtp))
            {
                Console.WriteLine("I don't recognise this information.");
                count++;
                login();
            }

            returnToMenu("");
        }
        private static void returnToMenu(string message)
        {

            if (message.Length > 0)
            {
                Console.WriteLine(message);
                menu();
            }
            else
            {
                Console.Clear();
                menu();
            }

        }


        private static void removeStudent()
        {
            string supp;
            Console.WriteLine("Here is the list of students \nPlease enter the ID of the student you would like to remove.");
            listStudentsShortFormat();
            supp = Console.ReadLine();
            for (int i = 0; i < student.Length; i++)
            {
                if (supp.Equals(student[i].Id))
                {
                    student[i].Id = null;
                    student[i].FamilyName = null;
                    student[i].FirstName = null;
                    student[i].CourseName = null;
                }
                else
                {
                    returnToMenu("Invalide ID");
                }
            }
        }

        private static void leaveApp()
        {
            string read;

            Console.WriteLine("Do you really want to leave? Y/N");
            read = Console.ReadLine();
            read.ToUpper();
            if (read.Equals("Y") || read.Equals("y"))
            {
                Environment.Exit(0);
            }
        }

        private static void listStudentsDetailedFormat()
        {
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************The list is empty ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].Id != null)
                    Console.WriteLine("\nID: " + student[i].Id + "\nLast Name : " + student[i].FamilyName + "\nFirst Name: : " + student[i].FirstName + "\nCourses : ");

                for (int j = 0; j < course.Length; j++)
                {
                    if (course[j].studentId != null)
                    if (course[j].studentId.Equals(student[i].Id))
                    {
                        if(course[j].courseName != null)
                        Console.WriteLine(course[j].courseName);
                    }

                    
                }
            }
        }

        private static void listStudentsShortFormat()
        {
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************The list is empty ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if(student[i].Id != null) 
                Console.WriteLine("\nID: " + student[i].Id + "\nLast Name: " + student[i].FamilyName + "\nFirst Name: : " + student[i].FirstName);
            }
        }

        private static void addStudent()
        {
            string temp;

                coursCount = 0;
                Console.WriteLine("Enter the student ID");
                temp = Console.ReadLine();
                for (int i = 0; i < student.Length; i++)
                {
                    if (temp.Equals(student[i].Id))
                    {
                        Console.WriteLine("This ID is already in use.");
                        addStudent();
                    }
                }
                student[studentCount].Id = temp;

                studentName();

                studentFirstName();
               
                    course[courseCount].studentId = student[studentCount].Id;

                    addClasses();

                    courseCount++;

                    studentCount++;

                    exitStudent();
                    
                }
 

        private static void studentFirstName()
        {
            string temp;
            Console.WriteLine("Please enter the students first name");
            temp = Console.ReadLine();
            if (temp.Length <= 1)
            {
                Console.WriteLine("You must enter a name");
                studentFirstName();
            }
            student[studentCount].FirstName = temp;
        }

        private static void studentName()
        {
            string temp;
            Console.WriteLine("Please enter the students family name");
            temp = Console.ReadLine();
            if (temp.Length <= 1)
            {
                Console.WriteLine("You must enter a name");
                studentName();
            }
            student[studentCount].FamilyName = temp;
        }

        private static void addClasses()
        {

            string temp;
            Console.WriteLine("Please enter the course name");
            temp = Console.ReadLine();
            if (temp.Length <= 1)
            {
                Console.WriteLine("You must enter the course name");
                addClasses();
            }
            course[courseCount].courseName = temp;

            Console.WriteLine("Please enter the students grade");
            try
            {
                course[courseCount].Grades = Double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                addClasses();
            }
            coursCount++;

            if (coursCount == 4)
            {
                exitStudent();
            }
            addMoreClasses();
        }

        private static void exitStudent()
        {
            string choice;
            Console.WriteLine("Would you like to add another student? Y / N");
            choice = Console.ReadLine();
            choice.ToUpper();
            if (choice.Equals("N") || choice.Equals("n"))
            {
                menu();
            }
            else if (choice.Equals("Y") || choice.Equals("y"))
            {
                addStudent();
            }
            else
            {
                Console.WriteLine("This is an invalide choice");
                exitStudent();
            }
          
        }

        private static void addMoreClasses()
        {
            
            string  choice;
            Console.WriteLine("Do you want to add a course? Y / N");
            choice = Console.ReadLine();
            if (choice.Equals("N") || choice.Equals("n"))
            {
                exitStudent();
            }
            else if (choice.Equals("Y") || choice.Equals("y"))
            {
                addClasses();
            }
            else
            {
                Console.WriteLine("This is an invalide choice.");
                addMoreClasses();
            }
        } 

                
        

        struct Etudiant
        {
            private string id;
            private string nom;
            private string prenom;
            private string nomCours;

            public Etudiant(string id, string nom, string prenom, string nomCours)
            {
                this.id = id;
                this.nom = nom;
                this.prenom = prenom;
                this.nomCours = nomCours;
            }

            public string Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }

            public string FamilyName
            {
                get
                {
                    return nom;
                }

                set
                {
                    nom = value;
                }
            }

            public string CourseName
            {
                get
                {
                    return nomCours;
                }

                set
                {
                    nomCours = value;
                }
            }

            public string FirstName
            {
                get
                {
                    return prenom;
                }

                set
                {
                    prenom = value;
                }
            }
        }
            struct Cours
            {
               private string idEtud;
               private String nom;
               private double notes;

                public Cours(string idEtud, string nom, double notes)
                {
                    this.idEtud = idEtud;
                    this.nom = nom;
                    this.notes = notes;
                }

                public string studentId
                {
                    get
                    {
                        return idEtud;
                    }

                    set
                    {
                        idEtud = value;
                    }
                }

                public string courseName
                {
                    get
                    {
                        return nom;
                    }

                    set
                    {
                        nom = value;
                    }
                }

                public double Grades
                {
                    get
                    {
                        return notes;
                    }

                    set
                    {
                        notes = value;
                    }
                }
            }
        
        static Etudiant[] student = new Etudiant[20];
        static int studentCount = 0;

        static Cours[] course = new Cours[20];
        static int courseCount = 0;
        static int count = 0;
        static int coursCount = 0;
    }

}







