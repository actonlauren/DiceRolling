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
                    Console.Write("Welcome to Dice Roller! How many sides would you like your dice to have?: ");
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
                Console.Write("Would you like to roll again? Y/N: ");
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
                return "Your roll: Snake Eyes";
            }
            if (dieValueOne == 1 && dieValueTwo == 2 || dieValueOne == 2 && dieValueTwo == 1)
            {
                return "Your roll: Ace Deuce";
            }
            if (dieValueOne == 2 && dieValueTwo == 2)
            {
                return "Your roll: Ballerina";
            }
            if (dieValueOne == 4 && dieValueTwo == 3 || dieValueOne == 3 && dieValueTwo == 4)
            {
                return "Your roll: Big Red";
            }
            if (dieValueOne == 6 && dieValueTwo == 6)
            {
                return "Your roll: Box Cars";
            }
            else
                return ($"Your roll {dieValueOne} : {dieValueTwo} was not a match.");
        }

        static string GetWinorLoss(int numberOne, int numberTwo)
        {
            if (numberOne + numberTwo == 7 || numberOne + numberTwo == 11)
            {
                return "You Win!";
            }
            if (numberOne + numberTwo == 2 || numberOne + numberTwo == 3 || numberOne + numberTwo == 12)
            {
                return "You rolled a Craps";
            }
            else
                return ($"Your roll was {numberOne} : {numberTwo}, try again.");
        }
    }
    

}