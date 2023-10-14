namespace DiceRolling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usersDie = "";
            int dieNumber = 0;
            bool askForNumberAgain = false;
            bool playAgain = false;

            do
            {
                do
                {
                    askForNumberAgain = false;
                    Console.Write("Number of sides for a pair of dice?: ");
                    usersDie = Console.ReadLine();
                    if (!int.TryParse(usersDie, out dieNumber))
                    {
                        askForNumberAgain = true;
                        Console.WriteLine("Please try again.");
                    }

                } while (askForNumberAgain);


                int randomNumberOne = GetRandomNumbers(dieNumber);
                int randomNumberTwo = GetRandomNumbers(dieNumber);

                Console.WriteLine(GetSpecialDieValue(randomNumberOne, randomNumberTwo));
                Console.WriteLine(GetWinorLoss(randomNumberOne, randomNumberTwo));

                playAgain = false;
                Console.WriteLine("Would you like to roll again? Y/N: ");
                string userPlayAgain = Console.ReadLine();
                if (userPlayAgain == "y" || userPlayAgain == "Y")
                {
                    playAgain = true;
                }

            } while (playAgain);
            
        }
        static int GetRandomNumbers (int number)
        {
            Random randomNumberGenerator = new Random();
            return randomNumberGenerator.Next(1, number);
        }

        static string GetSpecialDieValue(int dieValueOne, int dieValueTwo)
        {
            if (dieValueOne == 1 && dieValueTwo == 1)
            {
                return "Snake Eyes";
            }
            if (dieValueOne == 1 && dieValueTwo == 2 || dieValueOne == 2 && dieValueTwo == 1)
            {
                return "Ace Deuce";
            }
            if (dieValueOne == 6 && dieValueTwo == 6)
            {
                return "Box Cars";
            }
            else
                return "No Match";
        }

        static string GetWinorLoss(int NumberOne, int NumberTwo)
        {
            if (NumberOne + NumberTwo == 7 || NumberOne + NumberTwo == 11)
            {
                return "Win";
            }
            if (NumberOne + NumberTwo == 2 || NumberOne + NumberTwo == 3 || NumberOne + NumberTwo == 12)
            {
                return "Craps";
            }
            else
                return "No Match";
        }
    }
    

}