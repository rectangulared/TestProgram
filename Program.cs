using System;
using System.Linq;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Greetings! \nPlease, enter numbers from your lucky ticket and hope Lady Luck is on your side");

                string ticketNumbers = String.Empty;
                ticketNumbers = userInputCheck(ticketNumbers);

                //Checking if zero is needed
                ticketNumbers = checkForZero(ticketNumbers);

                luckyNumbers(ticketNumbers);
            }
        }

        private static String userInputCheck(String ticketNumbers)
        {
            do
            {
                ticketNumbers = Console.ReadLine();
                Console.Clear();
                //Check if all numbers are actually numbers and if 4<=Length<=8
            } while (!checkLength(ticketNumbers) || !checkNumbers(ticketNumbers));

            return ticketNumbers;
        }

        private static void luckyNumbers(String ticketNumbers)
        {
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
                Console.WriteLine("Wow, you win, congratulations.\nDo you want to test your luck again?\nPress any key");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Hmm, not so lucky, I guess.\nDo you want to try again?\nPress any key");
                Console.ReadKey();
            }
        }

        private static bool checkNumbers(String ticketNumbers)
        {
            //Using ASCII to validate numbers
            foreach (var tempChar in ticketNumbers)
            {
                int ascii = (int)tempChar;
                if (!((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46))
                {
                    Console.WriteLine("Sorry, but our tickets only have numbers, try again please");
                    return false;
                }
            }
            return true;
        }

        private static bool checkLength(String ticketNumbers)
        {
            if (ticketNumbers.Length < 4 || ticketNumbers.Length > 8)
            {
                Console.WriteLine("Oops... Your ticket contains wrong amount of numbers, try again");
                return false;
            }
            return true;
        }

        private static String checkForZero(String ticketNumbers)
        {
            if (ticketNumbers.Length % 2 != 0)
            {
                ticketNumbers = "0" + ticketNumbers;

            }
            return ticketNumbers;
        }
    }
}
