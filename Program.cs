using System.Text.RegularExpressions;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool choice = true;
            List<string> results = new List<string>();              //Initierar lista 'results'

            //Välkomst meddelande
            WelcomeMessage();
            while (choice)
            {
                //Meny
                MenuScreen();

                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Type a calculation, for example (25,7+74,3): ");
                        string tal = Console.ReadLine();

                        if (Regex.IsMatch(tal, @"[a-zA-Z]"))
                        {
                            Console.WriteLine("Calculation must not contain any letters. Press any key to try again");
                            Console.ReadKey();
                            goto case "1";
                        }

                        if (tal.Contains("+"))                                 //Kontrollerar om input innehåller '+' tecken
                        {
                            //Ger felmeddelande om talet är '0+0'
                            if (tal.Contains("0+0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0+0");
                                Console.WriteLine("Press any key to try again");
                                Console.ReadKey();
                                goto case "1";                              //Går tillbaka till case 1
                            }
                            else
                            {
                                string plusRes = PlusCalc(tal);               //Kallar på uträkningsmetoden för addition

                                results.Add($"{tal} = {plusRes}");            //Lägger till i listan
                                                                                       
                                Console.WriteLine($"{tal} = {plusRes}");      //Utskrift
                            }
                           
                            
                        }
                        else if (tal.Contains("-"))                         //Kontrollerar om input innehåller '-' tecken
                        {
                            //Ger felmeddelande om talet är '0-0'
                            if (tal.Contains("0-0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0-0");
                                Console.WriteLine("Press any key to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string subRes = SubCalc(tal);                 //Kallar på uträkningsmetoden för subtraktion

                                results.Add($"{tal} = {subRes}");             //Lägger till i listan
                                                                                          
                                Console.WriteLine($"{tal} = {subRes}");       //Utskrift
                            }
                            
                            
                        }
                        else if (tal.Contains("*"))
                        {
                            //Ger felmeddelande om talet är '0*0'
                            if (tal.Contains("0*0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0*0");
                                Console.WriteLine("Press any key to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string multiRes = MultiCalc(tal);               //Kallar på uträkningsmetoden för multiplikation

                                results.Add($"{tal} = {multiRes}");             //Lägger till i listan
                                                                                       
                                Console.WriteLine($"{tal} = {multiRes}");       //Utskrift
                            }
                                
                           
                        }
                        else if (tal.Contains("/"))
                        {
                            //Ger felmeddelande om talet är '0/0'
                            if (tal.Contains("0/0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0/0");
                                Console.WriteLine("Press any key to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string divRes = DivCalc(tal);                   //Kallar på uträkningsmetoden för division

                                results.Add($"{tal} = {divRes}");               //Lägger till i listan
                                                                                    
                                Console.WriteLine($"{tal} = {divRes}");         //Utskrift
                            }    
                        }

                        Console.Write("Would you like to see previous results? 'y', continue? 'n' or any key for menu: ");

                        string resultAnswer = Console.ReadLine().ToLower();     //Konverterar input till små bokstäver

                        if (resultAnswer == "y")
                        {
                            goto case "2";                                      //Går till case 2, tidigare resultat
                        }
                        else if (resultAnswer == "n")
                        {
                            goto case "1";                                      //Går till case 1, uträkning
                            
                        }
                        
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();                                        //Rensar konsolfältet
                        Console.WriteLine("Previous results\n");
                        if (results.Count == 0)                                 //Om inga tidigare uträkningar har gjorts så visas meddelandet "No results yet"
                        {
                            Console.WriteLine("No results yet.\n");
                            Console.WriteLine("Press any key to go back to menu: ");
                            Console.ReadKey();
                        }
                            
                        else
                        {
                            foreach (string t in results) 
                            {
                                Console.WriteLine(t);                           //Skriver ut listan med uträkningar
                            }
                            Console.WriteLine("\nDo you want to continue or exit the program?");
                            Console.Write("'y' for continue, 'n' for exit or any other key for menu: ");
                            string case2Result = Console.ReadLine().ToLower();

                            if (case2Result == "y")
                            {
                                goto case "1";
                            }
                            else if (case2Result == "n")
                            {
                                goto case "3";
                            }
                            
                        }
                        
                        Console.Clear();

                        break;

                    case "3":
                        ExitMessage();                                        //Kallar på metoden ExitMessage
                        
                        choice = false;
                        break;

                        default:                                              //Om input är annat än 1,2 eller 3
                        Console.WriteLine("Invalid input. Press any key to return: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            
            }

            //METODER

            //räkna ut addition
            string PlusCalc(string tal)
            {
                int plus = tal.IndexOf("+");             //Hitta plus från användarens input
                string plus1Text = tal[..plus];          //hitta tal innan plus
                
                string plus2Text = tal[(plus + 1)..];    //Hitta tal efter plus
                float tal1 = float.Parse(plus1Text);     //Konvertera första talet från string till float
                float tal2 = float.Parse(plus2Text);     //Konvertera andra talet från string till float

                float plusSumNum = tal1 + tal2;         //Uträkning

                string plusSum = plusSumNum.ToString(); //Konvertera float till string

                return plusSum;                         //Returnera string variabeln plusSum som innehåller summan av uträkningen
            }
            //Räkna ut subtration
            string SubCalc(string tal)
            {
                int minus = tal.IndexOf("-");              //Hitta minus från användarens input
                string minus1Text = tal[..minus];          //hitta tal innan minus
                string minus2Text = tal[(minus + 1)..];    //Hitta tal efter minus
                float tal1 = float.Parse(minus1Text);      //konvertera första talet från string till float
                float tal2 = float.Parse(minus2Text);      //konvertera andra talet från string till float

                float minusSumNum = tal1 - tal2;           //Uträkning

                string subSum = minusSumNum.ToString();    //Konvertera float till string

                return subSum;                             //Returnera string variabeln subSum som innehåller summan av uträkningen
            }
            //Räkna ut multiplikation
            string MultiCalc(string tal)
            {
                int multiply = tal.IndexOf("*");            //Hitta asterix från användarens input
                string mult1Text = tal[..multiply];         //hitta tal innan asterix
                string mult2Text = tal[(multiply + 1)..];   //Hitta tal efter asterix
                float tal1 = float.Parse(mult1Text);        //Konvertera första talet från string till float
                float tal2 = float.Parse(mult2Text);        //Konvertera andra talet från string till float

                float multSumNum = tal1 * tal2;             //Uträkning

                string multiSum = multSumNum.ToString();    //Konvertera float till string

                return multiSum;                            //Returnera string vartiabeln subSum som innehåller summan av uträkningen
            }
            //Räkna ut division
            string DivCalc(string tal)
            {
                int divide = tal.IndexOf("/");              //Hitta snedsträck från användarens input
                string div1Text = tal[..divide];            //hitta tal innan snedsträck
                string div2Text = tal[(divide + 1)..];      //Hitta tal efter snedsträck
                float tal1 = float.Parse(div1Text);         //Konvertera första talet från string till float
                float tal2 = float.Parse(div2Text);         //Konvertera andra talet från string till float

                float divSumNum = tal1 / tal2;              //Uträkning

                string divSum = divSumNum.ToString();       //Konvertera float till string

                return divSum;                              //Returnera string variabeln divSum som innehåller summan av uträkningen
            }
            //Välkomstmeddelande
            void WelcomeMessage()
            {
                string welcome = "\t ***Martins Calculator***\n\t      Make an option\n\n";

                for (int i = 0; i < welcome.Length; i++)                      //initierar en loop som loopar så många tecken stringen welcome innehåller
                {
                    Thread.Sleep(50);                                         //Skriver ut en bokstav var 50 millisekund
                    Console.Write(welcome[i]);                              
                }
            }
            //SKriver ut meny
            void MenuScreen()
            {
                string menu = "Calculator: 1\nPrevious results: 2\nExit: 3\n";
                for (var i = 0; i < menu.Length; i++)
                {
                    Thread.Sleep(30);
                    Console.Write(menu[i]);
                }
            }
            //Meddelande när program avslutas
            void ExitMessage()
            {
                Console.Clear();
                string exitMessage = "Program exit";
                for (int i = 0; i < exitMessage.Length; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(exitMessage[i]);
                }
                string dots = ". . .  ";
                for (int i = 0; i < dots.Length; i++)
                {
                    Thread.Sleep(200);
                    Console.Write(dots[i]);
                }
            }

        }

    
    }
}