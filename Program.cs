// Välkomnande meddelande
// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat
//Fråga användaren om den vill avsluta eller fortsätta.
namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool choice = true;
            List<string> results = new List<string>();


            Console.WriteLine("\t ***VÄLKOMSTMEDDELANDE**\n");
            Console.WriteLine("VAD VILL DU GÖRA?\n");
      
            while (choice)
            {
                Console.WriteLine("Miniräknare: 1");
                Console.WriteLine("Tidigare resultat: 2");
                Console.WriteLine("Avsluta: 3");

                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Ange ett tal: ");
                        string tal = Console.ReadLine();
                        
                        if (tal.Contains("+"))
                        {
                            if (tal.Contains("0+0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0+0");
                                Console.WriteLine("Press enter to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string plusRes = PlusCalc(tal);

                                results.Add($"{tal} = {plusRes}");            //Lägger till i listan
                                                                                       
                                Console.WriteLine($"{tal} = {plusRes}");      //Utskrift
                            }
                           
                            
                        }
                        else if (tal.Contains("-"))
                        {
                            if (tal.Contains("0-0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0-0");
                                Console.WriteLine("Press enter to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string subRes = SubCalc(tal);

                                results.Add($"{tal} = {subRes}");             //Lägger till i listan
                                                                                          
                                Console.WriteLine($"{tal} = {subRes}");       //Utskrift
                            }
                            
                            
                        }
                        else if (tal.Contains("*"))
                        {
                            if (tal.Contains("0*0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0*0");
                                Console.WriteLine("Press enter to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string multiRes = MultiCalc(tal);

                                results.Add($"{tal} = {multiRes}");             //Lägger till i listan
                                                                                       
                                Console.WriteLine($"{tal} = {multiRes}");       //Utskrift
                            }
                                
                           
                        }
                        else if (tal.Contains("/"))
                        {
                            if (tal.Contains("0/0"))
                            {
                                Console.WriteLine("invalid input. Calculation must not contain 0/0");
                                Console.WriteLine("Press enter to try again");
                                Console.ReadKey();
                                goto case "1";
                            }
                            else
                            {
                                string divRes = DivCalc(tal);

                                results.Add($"{tal} = {divRes}");               //Lägger till i listan
                                                                                    
                                Console.WriteLine($"{tal} = {divRes}");         //Utskrift
                            }    
                        }

                        Console.Write("Would you like to see previous results? 'y', continue? 'n', or go back to the menu 'enter': ");

                        string resultAnswer = Console.ReadLine().ToLower();

                        if (resultAnswer == "y")
                        {
                            goto case "2";
                        }
                        else if (resultAnswer == "n")
                        {
                            goto case "1";
                            
                        }
                        Console.Clear();
                        break;

                        case "2":
                        Console.Clear();
                        Console.WriteLine("Previous results\n");
                        if (results.Count == 0)
                        {
                            Console.WriteLine("No results yet.\n");
                            Console.WriteLine("Press enter to go back to menu: ");
                            Console.ReadKey();
                        }
                            
                        else
                        {
                            foreach (string t in results) 
                            {
                                Console.WriteLine(t);
                            }
                            Console.WriteLine("\nDo you want to continue or exit the program?");
                            Console.Write("'y' for continue or 'n' for exit, 'enter' for menu: ");
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
                        Console.WriteLine("Program exit");
                        choice = false;
                        break;

                        default:
                        Console.WriteLine("Invalid input. Press enter to continue: ");
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


        }

    
    }
}