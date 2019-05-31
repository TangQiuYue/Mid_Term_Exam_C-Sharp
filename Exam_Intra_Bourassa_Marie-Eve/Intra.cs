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
            Console.ForegroundColor = ConsoleColor.White;
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
                        ajouterEtudiant();
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
            if (etudiant[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < etudiant.Length; i++)
            {
                if (etudiant[i].Id != null)
                {
                    Console.WriteLine("\nIdentifiants: " + etudiant[i].Id + "\nNom: " + etudiant[i].Nom + "\nPrenom: : " + etudiant[i].Prenom);

                    for (int j = 0; j < cours.Length; j++)
                    {
                        if (cours[j].IdEtud != null)
                            if (cours[j].IdEtud.Equals(etudiant[i].Id))
                            {
                                if (cours[j].Notes != 0)
                                    average += cours[j].Notes;
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
            for (int i = 0; i < etudiant.Length; i++)
            {
                if (supp.Equals(etudiant[i].Id))
                {
                    etudiant[i].Id = null;
                    etudiant[i].Nom = null;
                    etudiant[i].Prenom = null;
                    etudiant[i].NomCours = null;
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
            if(cours[0].IdEtud == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < cours.Length; i++)
            {
                Console.WriteLine("ID etud: " + cours[i].IdEtud);
            }
        }

        private static void afficherEtudiantDet()
        {
            if (etudiant[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < etudiant.Length; i++)
            {
                if (etudiant[i].Id != null)
                    Console.WriteLine("\nIdentifiants: " + etudiant[i].Id + "\nNom: " + etudiant[i].Nom + "\nPrenom: : " + etudiant[i].Prenom + "\nNom des cours: ");

                for (int j = 0; j < cours.Length; j++)
                {
                    if (cours[j].IdEtud != null)
                    if (cours[j].IdEtud.Equals(etudiant[i].Id))
                    {
                        if(cours[j].Nom != null)
                        Console.WriteLine(cours[j].Nom);
                    }

                    
                }
            }
        }

        private static void afficherEtudiantsAbb()
        {
            if (etudiant[0].Id == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n****************************La liste est vide ****************************\n");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            for (int i = 0; i < etudiant.Length; i++)
            {
                if(etudiant[i].Id != null) 
                Console.WriteLine("\nIdentifiants: " + etudiant[i].Id + "\nNom: " + etudiant[i].Nom + "\nPrenom: : " + etudiant[i].Prenom);
            }
        }

        private static void ajouterEtudiant()
        {
            bool goOn = true, keepGoing = true;
            string choice, choice2;
            string temp;
            int coursCount = 0;
            do
            {
            etudId:
                coursCount = 0;
                Console.WriteLine("Entrez l'identifiant de l'Étudiant");
                temp = Console.ReadLine();
                for (int i = 0; i < etudiant.Length; i++)
                {
                    if (temp.Equals(etudiant[i].Id))
                    {
                        Console.WriteLine("Cette identifiant est déja utilisé.");
                        goto etudId;
                    }
                }
                etudiant[nbrEtudiant].Id = temp;
                

            nomEtud:
                Console.WriteLine("Entrez le nom de l'étudiant");
                temp = Console.ReadLine();
                if (temp.Length <= 1)
                {
                    Console.WriteLine("Vouz devez entrez le nom de l'étudiant");
                    goto nomEtud;
                }
                etudiant[nbrEtudiant].Nom = temp;

            prenomEtud:
                Console.WriteLine("Entrez le prenom de l'étudiant");
                temp = Console.ReadLine();
                if (temp.Length <= 1)
                {
                    Console.WriteLine("Vouz devez entrez le prenom de l'étudiant");
                    goto prenomEtud;
                }
                etudiant[nbrEtudiant].Prenom = temp;

                do {
                cours[nbrCours].IdEtud = etudiant[nbrEtudiant].Id;
                nomCours:
                    Console.WriteLine("Entrez le nom du cours");
                    temp = Console.ReadLine();
                    if (temp.Length <= 1)
                    {
                        Console.WriteLine("Vous devez entrez le nom du cours");
                        goto nomCours;
                    }
                    cours[nbrCours].Nom = temp;

                    Console.WriteLine("Entrez la note du cours");
                    try
                    {
                        cours[nbrCours].Notes = Double.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto nomCours;
                    }
                    coursCount++;
                    if (coursCount == 4)
                    {
                        goto leave;
                    }
                    nbrCours++;

                autreCours:
                Console.WriteLine("Voulez-vous entrez un autre Cours O / N");
                choice2 = Console.ReadLine();
                choice2.ToUpper();
                if (choice2.Equals("N") || choice2.Equals("n"))
                    {
                    keepGoing = false;
                }
                else if (choice2.Equals("O") || choice2.Equals("o"))
                {
                    keepGoing = true;
                }
                else
                {
                    Console.WriteLine("Ce choix est invalide.");
                    goto autreCours;
                }
            } while (keepGoing == true);

                nbrEtudiant++;
                

            leave:
                Console.WriteLine("Voulez-vous entrez un autre Étudiant? O / N");
                choice = Console.ReadLine();
                choice.ToUpper();
                if (choice.Equals("N") || choice.Equals("n"))
                {
                    goOn = false;
                }
              else  if (choice.Equals("O") || choice.Equals("o"))
                {
                    goOn = true;
                }
                else
                {
                    Console.WriteLine("Ce choix est invalide.");
                    goto leave;
                }
            } while (goOn == true);
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

            public string Nom
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

            public string Prenom
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

                public string IdEtud
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

                public string Nom
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
        
        static Etudiant[] etudiant = new Etudiant[20];
        static int nbrEtudiant = 0;

        static Cours[] cours = new Cours[20];
        static int nbrCours = 0;
        static int count = 0;
    }

}







