using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Checker checker = new Checker();
            InputHandler inputHandler = new InputHandler();
            PrintHandler printHandler = new PrintHandler();

            while (true)
            {
                printHandler.PrintIntro();
                string ticketNumbers = inputHandler.GetInput();
                if (checker.IsUserInputCorrect(ticketNumbers))
                    LuckyNumbers(ticketNumbers);

            }
        }

        static void LuckyNumbers(string ticketNumbers)
        {
            PrintHandler printHandler = new PrintHandler();

            //Using collections to simplify the validation process
            var tempNum = ticketNumbers.Select(digit => int.Parse(digit.ToString()));

            int check = 0;
            for (int i = 0; i < tempNum.Count() / 2; i++)
            {
                //if half of the ticket numbers are equal, then their subtraction will be equal to zero
                check = check + tempNum.ElementAt(i) - tempNum.ElementAt(i + (tempNum.Count() / 2));
            }
            if (check == 0)
            {
                printHandler.PrintWin();
            }
            else
            {
                printHandler.PrintLose();
            }
        }

    }

    class Checker
    {
        PrintHandler printHandler = new PrintHandler();

        public bool IsUserInputCorrect(string ticketNumbers)
        {
            return (IsAllNumbers(ticketNumbers) && IsCorrectLength(ticketNumbers));
        }

        private bool IsCorrectLength(string ticketNumbers)
        {
            if (ticketNumbers.Length < 4 || ticketNumbers.Length > 8)
            {
                printHandler.PrintLengthError();
                return false;
            }
            return true;
        }

        private bool IsAllNumbers(string ticketNumbers)
        {
            if (Regex.IsMatch(ticketNumbers, "^[0-9]*$"))
                return true;
            printHandler.PrintInputError();
            return false;
        }
    }

    class InputHandler
    {
        //Getting input, removing whitespaces and adding zero, if needed
        public string GetInput()
        {
            return IsZeroNeeded(Console.ReadLine().Replace(" ", ""));
        }

        private string IsZeroNeeded(string ticketNumbers)
        {
            if (ticketNumbers.Length % 2 != 0)
                ticketNumbers = "0" + ticketNumbers;
            return ticketNumbers;
        }
    }

    class PrintHandler
    {
        public void PrintIntro()
        {
            Console.Clear();
            Console.WriteLine("Greetings! \nPlease, enter numbers from your lucky ticket and hope Lady Luck is on your side");
            Console.WriteLine("Tickets are 4 to 8 numbers long and do not contain any other symbols or letters.");
        }

        public void PrintWin()
        {
            Console.WriteLine("Wow, you win, congratulations.\nDo you want to test your luck again?\nPress any key");
            Console.ReadKey();
        }

        public void PrintLose()
        {
            Console.WriteLine("Hmm, not so lucky, I guess.\nDo you want to try again?\nPress any key");
            Console.ReadKey();
        }

        public void PrintLengthError()
        {
            Console.WriteLine("Oops... Your ticket contains wrong amount of numbers, try again\nPress any key");
            Console.ReadKey();
        }

        public void PrintInputError()
        {
            Console.WriteLine("Sorry, but our tickets only have numbers, try again please\nPress any key");
            Console.ReadKey();
        }
    }
}
