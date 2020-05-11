using System;
using System.Linq;

namespace Bussen
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Buss som heter minbuss
            //Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
            Buss minbuss = new Buss();
            minbuss.Run();
            minbuss.add_passenger();
            minbuss.print_buss();
            minbuss.calc_average_age();
            minbuss.max_age();
            minbuss.find_age();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }

    class Buss
    {
        //public int[] passagerare;
        private int antal_passagerare = 0; //Håller reda på att inte fler än 25 platser används
        public passenger[] passagerare;
        public int totalAge = 0;

        public Buss()  //konstruktor
        {
            passagerare = new passenger[25]; //initierar vektorn
            //passagerare[5] = new passenger("Test1", 2, "male");
            
        }
        public void Run()
        {
            int tal = 0;

            do
            {

                Console.WriteLine("Welcome to the awesome Buss-simulator");
                Console.WriteLine(" ");

                //nedan är valmeny till switchen
                Console.WriteLine("1. Add passenger");
                Console.WriteLine("2. Print the current passengers and empty spaces");
                Console.WriteLine("3. Summarize the ages of all the passengers");
                Console.WriteLine("4. Calculate the average age");
                Console.WriteLine("5. Show the age of the oldest person");
                Console.WriteLine("6. Select passengers in range of age");
                Console.WriteLine("7. Sort the ages");
                Console.WriteLine("0. Exit the program");
                Console.WriteLine("  ");
                Console.WriteLine("Choose by entering the corresponding number:");

                tal = int.Parse(Console.ReadLine());
                switch (tal)
                {
                    case 1:
                        add_passenger();
                        break;
                    case 2:
                        print_buss();
                        break;
                    case 3:
                        calc_total_age();
                        Console.WriteLine("\tAll the ages summarized adds up to: {0} ages", calc_total_age());
                        break;
                    case 4:
                        calc_average_age();
                        Console.WriteLine("\tThe average age is: {0} years", calc_average_age());
                        break;
                    case 5:
                        max_age();
                        Console.WriteLine("The max age is : {0}", max_age());
                        break;
                    case 6:
                        find_age();
                        break;
                    case 7:
                        sort_buss();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Wrong input format");
                        break;
                }
            } while (tal != 0);
        }

        //Metoder för betyget E

        public void add_passenger()
        {
            int add_passenger_input = 0;
            string passengersName;
            int passengersAge;
            string passengersSex;

            do
            {
                Console.WriteLine("\nChoose command regarding passengers:");
                Console.WriteLine("1. Add passenger");
                Console.WriteLine("0. Exit to main menu\n");

                if (antal_passagerare <= 24)
                {


                    add_passenger_input = int.Parse(Console.ReadLine());
                    switch (add_passenger_input)
                    {
                        case 1:
                            Console.WriteLine($"Adding passenger '{antal_passagerare + 1}' ");
                            Console.WriteLine("Please begin with entering name of the passenger:");
                            passengersName = Console.ReadLine();
                            Console.WriteLine($"enter {passengersName}s age:");
                            passengersAge = int.Parse(Console.ReadLine());
                            Console.WriteLine($"enter {passengersName}, {passengersAge} sex: (male/female)");
                            passengersSex = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"\t{passengersName}, {passengersAge}, who is a {passengersSex} entered the buss...");
                            passagerare[antal_passagerare] = new passenger(passengersName, passengersAge, passengersSex);
                            antal_passagerare++;

                            break;
                        case 0:
                            Console.WriteLine("You choose not to add any further passengers \n");
                            break;
                        default:
                            Console.WriteLine("Wrong input format");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("The buss is completely occupied, you can't add more passengers.\n");
                    break;
                }
            } while (add_passenger_input != 0);

            Console.WriteLine("\n Returing to main menu, please press ENTER");
            Console.ReadKey();
            Console.Clear();

        }

        public void print_buss()
        {
            Console.Clear();
            //Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
            Console.WriteLine("Current passengers:\n");
            int i = 0;
            foreach (var temp in passagerare)//Loop för att skriva ut varenda objekt i vektorn
            {
                if (temp != null)
                    Console.WriteLine(temp);
                else
                    Console.WriteLine(i + ". is an empty space");
                i++;
            }

            Console.WriteLine("\nPress enter to return to the main menu . . .");
            Console.ReadKey();
            Console.Clear();
        }

        public int calc_total_age()
        {
            Console.Clear();
            totalAge = 0;

            foreach (passenger count in passagerare)
            {
                if (count != null) //Fångar upp exception som uppstår vid tom index
                {
                    totalAge += count.get_age();
                }
            }
            return totalAge;
        }

        public int calc_average_age()
        {
            calc_total_age();
            Console.Clear();
            int occupiedSeat = 0;
            int averageAge = 0;
            foreach (var temp in passagerare)//Loop för att skriva ut varenda objekt i vektorn
            {
                if (temp != null)
                {
                    occupiedSeat++;
                }

            }
            averageAge = totalAge / occupiedSeat;
            return averageAge;

            //Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
        }

        public int max_age()
        {
            Console.Clear();

            int i = 0;
            int temp;
            int[] ages = new int[25];
            foreach (passenger count in passagerare)
            {
                if (count != null) //Fångar upp exception som uppstår vid tom index
                {
                    temp = count.get_age(); i++;
                    ages[i] = temp;
                }
            }
            int maxValue = ages.Max();
            return maxValue;
        }

        public void find_age()
        {
            Console.Clear();
            int age = 0;

            Console.WriteLine("Enter lowest desired age:");
            int lowestAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter highest desired age:");
            int highestAge = int.Parse(Console.ReadLine());
            foreach (passenger count in passagerare)
            {
                if (count != null ) //Fångar upp exception som uppstår vid tom index
                {
                    age = count.get_age();
                    if (lowestAge < age && highestAge > age)
                    {
                        Console.WriteLine("{1}{0}, is inside the range ",age, count);
                    }
                }
            }
        }

        public void sort_buss()
        {

            Console.Clear();
            int k = 0;
            int temp;
            int[] ages = new int[25];
            foreach (passenger count in passagerare)
            {
                if (count != null) //Fångar upp exception som uppstår vid tom index
                {
                    temp = count.get_age(); k++;
                    ages[k] = temp;
                }
            }

            int temp2;
            for (int j = 0; j <= ages.Length - 2; j++) //bubbelsortering
            {
                for (int i = 0; i <= ages.Length - 2; i++)
                {
                    if (ages[i] > ages[i + 1])
                    {
                        temp2 = ages[i + 1];
                        ages[i + 1] = ages[i];
                        ages[i] = temp2;
                    }
                }
            }
            Console.WriteLine("Ages sorted:");
            foreach (int p in ages)
                if (p != 0)
                {
                    Console.WriteLine(p);
                }
            Console.WriteLine("\n");
        }


    
        public void poke()
        {
            //Betyg A
            //Vilken passagerare ska vi peta på?
            //Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
            //Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
            //Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
        }

        public void getting_off()
        {
            //Betyg A
            //En passagerare kan stiga av
            //Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
            //Sortering blir också klurigare
            //Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
            //.. som tillhörde den som lämnade bussen, får flytta fram en plats.
            //Då finns aldrig någon tom plats mellan passagerare.
        }
    }

    class passenger
    {
        int age;
        string name;
        string sex;

        public passenger(string _name, int _age, string _sex) //konstruktor för passenger
        {
            name = _name;
            age = _age;
            sex = _sex;
        }
        public int get_age()
        {
            return age;
        }
        public override string ToString()//standard versionen för hur ett objekt skrivs ut ändras med denna metod
        {
            return string.Format("\t{0}, is {1} y/o and of the gender: {2}", name, age, sex);
        }
    }
}
