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
                Console.WriteLine("\n***** GESTION DU COLLEGE DE ROSE *****");
                Console.WriteLine("Que voulez vous faire aujourdhi? " +
                    "\n \n 1 - Ajouter un nouvel étudiant" +
                    "\n 2 - Lister les étudiants format abrégé" +
                    "\n 3 - Lister les étudiants format détaillé" +
                    "\n 4 - Lister les étudiants avec leurs moyennes" +
                    "\n 5 - Supprimer un étudiant" +
                    "\n 6 - Quitter l'application");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Console.Clear();
                        addStudent();
                        menu();
                        break;
                    case 2:
                        Console.Clear();
                        afficherEtudiantsAbb();
                        menu();
                        break;
                    case 3:
                        Console.Clear();
                        afficherEtudiantDet();
                        menu();
                        break;
                    case 4:
                        Console.Clear();
                        afficherEtudiantMoyenne();
                        menu();
                        break;
                    case 5:
                        Console.Clear();
                        supprimerEtudiant();
                        menu();
                        break;
                    case 6:
                        Console.Clear();
                        quitterAppli();
                        menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Votre choix est invalide, Séléctioner un option de 1-6");
                        menu();
                        break;
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
                menu();
            }
        }

        private static void afficherEtudiantMoyenne()
        {
            double average = 0;
            int count = 1;
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].Id != null)
                {
                    Console.WriteLine("\nIdentifiants: " + student[i].Id + "\nNom: " + student[i].familyName + "\nPrenom: : " + student[i].firstName);

                    for (int j = 0; j < course.Length; j++)
                    {
                        if (course[j].studentId != null)
                            if (course[j].studentId.Equals(student[i].Id))
                            {
                                if (course[j].Notes != 0)
                                    average += course[j].Notes;
                                count++;
                            }
                    }
                    Console.WriteLine("Moyenne: " + average / count);
                }
            }
           
        }

        private static void login()
        {
            string username, nomUtil = "examen", password, mtp = "1234";

           
            if (count == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veuillez contacter la direction. \n\n\nAurevoir.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("Bienvenue au System de Gestion du College de Rose");
            Console.WriteLine("\nEntrez votre nom d'utilisateur: ");
            username = Console.ReadLine();

            Console.WriteLine("Entrez votre mot de passe: ");
            password = Console.ReadLine();

            if (!username.Equals(nomUtil) || !password.Equals(mtp))
            {
                Console.WriteLine("Je ne reconnais pas cette informations.");
                count++;
                login();
            }

            Console.Clear();
            menu();
        }

        private static void supprimerEtudiant()
        {
            string supp;
            Console.WriteLine("Voici la liste des étudiants. \nEntrez l'Identifiant de l'étudiant que vous voulez supprimer.");
            afficherEtudiantsAbb();
            supp = Console.ReadLine();
            for (int i = 0; i < student.Length; i++)
            {
                if (supp.Equals(student[i].Id))
                {
                    student[i].Id = null;
                    student[i].familyName = null;
                    student[i].firstName = null;
                    student[i].NomCours = null;
                }
            }
        }

        private static void quitterAppli()
        {
            string read;

            Console.WriteLine("Voulez-vous vraimenet quitter? O/N");
            read = Console.ReadLine();
            read.ToUpper();
            if (read.Equals("O") || read.Equals("o"))
            {
                Environment.Exit(0);
            }
        }

        private static void afficherCours()
        {
            if(course[0].studentId == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < course.Length; i++)
            {
                Console.WriteLine("ID etud: " + course[i].studentId);
            }
        }

        private static void afficherEtudiantDet()
        {
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].Id != null)
                    Console.WriteLine("\nIdentifiants: " + student[i].Id + "\nNom: " + student[i].familyName + "\nPrenom: : " + student[i].firstName + "\nNom des cours: ");

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

        private static void afficherEtudiantsAbb()
        {
            if (student[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < student.Length; i++)
            {
                if(student[i].Id != null) 
                Console.WriteLine("\nIdentifiants: " + student[i].Id + "\nNom: " + student[i].familyName + "\nPrenom: : " + student[i].firstName);
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
            student[studentCount].firstName = temp;
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
            student[studentCount].familyName = temp;
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
                course[courseCount].Notes = Double.Parse(Console.ReadLine());
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

            public string familyName
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

            public string NomCours
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

            public string firstName
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

                public double Notes
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







