using System.Text.RegularExpressions;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool choice = true;
            //Initierar lista 'results'
            List<string> results = new List<string>();

            //Välkomstmeddelande
            WelcomeMessage();
            while (choice)
            {
                //Meny
                MenuScreen();

                string? menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Type a calculation without any spaces, for example (25,7+74,3) type 0 for menu: ");
                        string? input = Console.ReadLine();
                        if (input == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        //Kontrollerar om input innehåller några fel, tex specialtecken, mellanslag eller bokstäver)
                        if (Errors(input) == "error")
                        {
                            goto case "1";
                        }
                        //Kontrollerar om input innehåller '+' tecken
                        if (input.Contains("+"))
                        {
                                //Kallar på uträkningsmetoden för addition
                                string plusRes = PlusCalc(input);
                                //Lägger till i listan
                                results.Add($"{input} = {plusRes}");
                                //Utskrift                                                       
                                Console.WriteLine($"{input} = {plusRes}");
                        }

                        else if (input.Contains("-"))
                        {
                                string subRes = SubCalc(input);

                                results.Add($"{input} = {subRes}");

                                Console.WriteLine($"{input} = {subRes}");

                        }
                        else if (input.Contains("*"))
                        {
                                string multiRes = MultiCalc(input);

                                results.Add($"{input} = {multiRes}");

                                Console.WriteLine($"{input} = {multiRes}");
                        }
                        else if (input.Contains("/"))
                        {

                            if (input.Contains("0/"))
                            {
                                Console.WriteLine("invalid input.");
                                Console.WriteLine("Press any key to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string divRes = DivCalc(input);

                                results.Add($"{input} = {divRes}");

                                Console.WriteLine($"{input} = {divRes}");
                            }
                        }

                        Console.Write("Would you like to see previous results? 'y', continue? 'n' or any key for menu: ");

                        //Konverterar input till små bokstäver
                        string? resultAnswer = Console.ReadLine().ToLower();

                        if (resultAnswer == "y")
                        {
                            //Går till case 2, tidigare resultat
                            goto case "2";
                        }
                        else if (resultAnswer == "n")
                        {
                            //Går till case 1, uträkning
                            goto case "1";

                        }

                        Console.Clear();
                        break;

                    case "2":
                        //Rensar konsolfältet
                        Console.Clear();
                        Console.WriteLine("Previous results\n");
                        //Om inga tidigare uträkningar har gjorts så visas meddelandet "No results yet"
                        if (results.Count == 0)
                        {
                            Console.WriteLine("No results yet.\n");
                            Console.WriteLine("Press any key to go back to menu: ");
                            Console.ReadKey();
                        }

                        else
                        {
                            foreach (string t in results)
                            {
                                //Skriver ut listan med uträkningar
                                Console.WriteLine(t);
                            }
                            Console.WriteLine("\nDo you want to continue or exit the program?");
                            Console.Write("'y' for continue, 'n' for exit or any other key for menu: ");
                            string? case2Result = Console.ReadLine().ToLower();

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
                        //Kallar på metoden ExitMessage
                        ExitMessage();

                        choice = false;
                        break;

                    //Om input är annat än 1,2 eller 3
                    default:
                        Console.WriteLine("Invalid input. Press any key to return: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

            //METODER

            //rader som inte är kommenterade är förklarat på tidigare metoder

            //räkna ut addition
            string PlusCalc(string tal)
            {
                //Hitta plus från användarens input
                int plus = tal.IndexOf("+");
                //hitta tal innan plus
                string plus1Text = tal[..plus];

                //Hitta tal efter plus
                string plus2Text = tal[(plus + 1)..];
                //Konvertera första talet från string till float
                float tal1 = float.Parse(plus1Text);
                //Konvertera andra talet från string till float
                float tal2 = float.Parse(plus2Text);
                //Uträkning
                float plusSumNum = tal1 + tal2;
                //Konvertera float till string
                string plusSum = plusSumNum.ToString();
                //Returnera string variabeln plusSum som innehåller summan av uträkningen
                return plusSum;
            }
            //Räkna ut subtration
            string SubCalc(string tal)
            {
                int minus = tal.IndexOf("-");
                string minus1Text = tal[..minus];
                string minus2Text = tal[(minus + 1)..];
                float tal1 = float.Parse(minus1Text);
                float tal2 = float.Parse(minus2Text);

                float minusSumNum = tal1 - tal2;

                string subSum = minusSumNum.ToString();

                return subSum;
            }
            //Räkna ut multiplikation
            string MultiCalc(string tal)
            {
                int multiply = tal.IndexOf("*");
                string mult1Text = tal[..multiply];
                string mult2Text = tal[(multiply + 1)..];
                float tal1 = float.Parse(mult1Text);
                float tal2 = float.Parse(mult2Text);

                float multSumNum = tal1 * tal2;

                string multiSum = multSumNum.ToString();

                return multiSum;
            }
            //Räkna ut division
            string DivCalc(string tal)
            {
                int divide = tal.IndexOf("/");
                string div1Text = tal[..divide];
                string div2Text = tal[(divide + 1)..];
                float tal1 = float.Parse(div1Text);
                float tal2 = float.Parse(div2Text);

                float divSumNum = tal1 / tal2;

                string divSum = divSumNum.ToString();

                return divSum;
            }
            //Välkomstmeddelande
            void WelcomeMessage()
            {
                string welcome = "\t ***Martins Calculator***\n\t      Make an option\n\n";

                //initierar en loop som loopar så många tecken stringen welcome innehåller
                for (int i = 0; i < welcome.Length; i++)
                {
                    //Skriver ut en bokstav var 50 millisekund
                    Thread.Sleep(20);
                    Console.Write(welcome[i]);
                }
            }
            //SKriver ut meny
            void MenuScreen()
            {
                string menu = "Calculator: 1\nPrevious results: 2\nExit: 3\n";

                for (var i = 0; i < menu.Length; i++)
                {
                    Thread.Sleep(20);
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
            //Felmeddelanden
            string Errors(string input)
            {
                //Kontrollerar om input innehåller bokstäver
                if (Regex.IsMatch(input, @"[a-zA-Z]"))
                {
                    Console.WriteLine("Calculation must not contain any letters. Press any key to try again");
                    Console.ReadKey();
                    return "error";
                }
                //Kontrollerar om input innehåller mellanslag
                if (input.Contains(" "))
                {
                    Console.WriteLine("No spaces allowed. Press any key to try again");
                    Console.ReadKey();
                    return "error";
                }
                //Kontrollerar om input är tomt
                if (input == "")
                {
                    Console.WriteLine("No input. Press any key to try again");
                    Console.ReadKey();
                    return "error";
                }
                //Kontrollerar om input innehåller specialtecken
                string symbols = "!\"#¤%&()=?`^'@£$€{[]}\\<>|_^~§½";
                //För varje tecken i stringen symbols kollar loopen om input innehåller någon av alla tecken
                foreach (var item in symbols)
                {
                    if (input.Contains(item))
                    {
                        
                        Console.WriteLine("Input cannot contain special characters. Press any key to try again");
                        Console.ReadKey();
                        return "error";
                    }

                }
                
                //Returnerar felmeddelande
                return "null";
            }
        }
    }
}