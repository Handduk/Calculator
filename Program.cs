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
                                int plus = tal.IndexOf("+");         //Hitta plus
                                string plus1Text = tal[..plus];          //hitta tal innan plus
                                string plus2Text = tal[(plus + 1)..];    //Hitta tal efter plus
                                float tal1 = float.Parse(plus1Text);
                                float tal2 = float.Parse(plus2Text);

                                //Uträkning
                                float plusSumNum = tal1 + tal2;

                                string plusSum = plusSumNum.ToString(); //Konvertera int till string

                                results.Add($"{plus1Text} + {plus2Text} = {plusSum}"); //Lägger till i listan
                                                                                       //Utskrift
                                Console.WriteLine($"{tal1} + {tal2} = {plusSum}");
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
                                int minus = tal.IndexOf("-");         //Hitta minus
                                string minus1Text = tal[..minus];          //hitta tal innan minus
                                string minus2Text = tal[(minus + 1)..];    //Hitta tal efter minus
                                float tal1 = float.Parse(minus1Text);
                                float tal2 = float.Parse(minus2Text);

                                //Uträkning
                                float minusSumNum = tal1 - tal2;

                                string minusSum = minusSumNum.ToString(); //Konvertera int till string

                                results.Add($"{minus1Text} - {minus2Text} = {minusSum}"); //Lägger till i listan
                                                                                          //Utskrift
                                Console.WriteLine($"{tal1} - {tal2} = {minusSum}");
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
                                int multiply = tal.IndexOf("*");         //Hitta asterix
                                string mult1Text = tal[..multiply];          //hitta tal innan asterix
                                string mult2Text = tal[(multiply + 1)..];    //Hitta tal efter asterix
                                float tal1 = float.Parse(mult1Text);
                                float tal2 = float.Parse(mult2Text);

                                //Uträkning
                                float multSumNum = tal1 * tal2;

                                string multSum = multSumNum.ToString(); //Konvertera int till string

                                results.Add($"{mult1Text} * {mult2Text} = {multSum}"); //Lägger till i listan
                                                                                       //Utskrift
                                Console.WriteLine($"{tal1} * {tal2} = {multSum}");
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
                                int divide = tal.IndexOf("/");         //Hitta snedsträck
                                string div1Text = tal[..divide];          //hitta tal innan snedsträck
                                string div2Text = tal[(divide + 1)..];    //Hitta tal efter snedsträck
                                float tal1 = float.Parse(div1Text);
                                float tal2 = float.Parse(div2Text);

                                //Uträkning
                                float divSumNum = tal1 / tal2;

                                string divSum = divSumNum.ToString(); //Konvertera int till string

                                results.Add($"{div1Text} / {div2Text} = {divSum}"); //Lägger till i listan
                                                                                    //Utskrift
                                Console.WriteLine($"{tal1} / {tal2} = {divSum}");
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
                        Console.WriteLine("Program avslutas");
                        choice = false;
                        break;

                        default:
                        Console.WriteLine("Ogiltig inmatning. Press enter to continue: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            
            }


            

        }

    
    }
}