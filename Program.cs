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
                        Console.WriteLine("Case 1");
                        break;

                        case "2":
                        Console.WriteLine("Case 2");
                        break;

                    case "3":
                        Console.WriteLine("Program avslutas");
                        choice = false;
                        break;

                        default:
                        Console.WriteLine("Ogiltig inmatning\n");
                        break;

                }
            
            }

            

        }

    
    }
}