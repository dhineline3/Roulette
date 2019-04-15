using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
            Console.WriteLine();
        }
        public static int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 19,
                                20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 00 };
        public static string[] colors = { "red", "black" };
        public static int money = 500;
        public static int attempts = 0;
        public static int input;
        public static int newMoney;
        public static string[] EvenOdd = { "even", "odd" };
        public static string[] columns = { "first", "second", "third" };
        public static Random ran = new Random();

        public static void Game()
        {
            while (money != 0)
            {
                Console.WriteLine("Welcome to the game of blackjack! Wish to try your luck? Read the options below.\n");
                Console.WriteLine("Money: $" + money + "                                                                     Attempts: " + attempts + "\n");
                Console.WriteLine("Options                                                                                   Odds\n");
                Console.WriteLine(
                "a. Individual Number: 0, 00, 1-36                                                         35:1\n" +
                "b. Evens/Odds                                                                             1:1\n" +
                "c. Reds/Blacks                                                                            1:1\n" +
                "d. Lows(1-18)/Highs(19-36)                                                                1:1\n" +
                "e. Dozens: Row thirds 1-12, 13-24, 25-36                                                  2:1\n" +
                "f. Columns: First, Second, or Third Columns                                               2:1\n" +
                "g. Street: Rows, e.g. 1/2/3 or 22,23,24                                                   11:1\n" +
                "h. 6 Numbers: Double Rows, e.g. 1/2/3/4/5/6 or 22/23/24/25/26                             5:1\n" +
                "i. Split: At the edge of any two contiguous numbers, e.g. 1/2, 11/14, and 35/36           17:1\n" +
                "j. Corner: At the intersection of any four contiguous numbers e.g. 1/2/4/5 or 23/24/26/27 8:1\n");
                Console.WriteLine("Where would you like to place your money?");


                string choice = Console.ReadLine();
                choice.ToLower();
                Console.Write("You chose option " + choice + ". ");
                bool check =
                choice == "a" ||
                choice == "b" ||
                choice == "c" ||
                choice == "d" ||
                choice == "e" ||
                choice == "f" ||
                choice == "g" ||
                choice == "h" ||
                choice == "i" ||
                choice == "j";

                if (check == false)
                {
                    Console.WriteLine("You did not enter the correct input value.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                input:
                    Console.WriteLine("Enter an amount to bet");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input > money)
                    {
                        Console.WriteLine("You dont have enough money!");
                        Console.WriteLine("Press enter to try again.");
                        Console.ReadKey();
                        goto input;
                    }
                    else
                    {
                        money -= input;
                        int roll = ran.Next(0, 37);
                        string ranColor = colors[ran.Next(colors.Length)];
                        bool even = roll % 2 == 0;

                        if (choice == "a")
                        {

                            Console.WriteLine("You have chosen to bet on a single number.");
                            Console.Write("Choose any number between 1 and 36. You may also select 0 or 00 : ");
                            int option = Convert.ToInt32(Console.ReadLine());

                            int option2 = numbers[ran.Next(numbers.Length)];


                            Console.WriteLine("You landed on " + option2 + " " + colors[ran.Next(colors.Length)]);
                            if (option2 == option)
                            {
                                Console.WriteLine("Great job you now have " + money + " money ");
                                money += input * 38;
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                money = money - input;
                                Console.WriteLine("House wins. You lose $" + money);
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "b")
                        {
                            Console.WriteLine("You have chosen Evens/Odds.");
                            Console.ReadKey();
                            Console.Write("You currently have $" + money + ". What would you like to gamble: ");
                            Console.ReadKey();
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount:");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            newMoney = money - input;
                            Console.Write("Please choose even or odd: ");
                            Random ran = new Random();

                            string option = Console.ReadLine();

                            string option1 = EvenOdd[ran.Next(EvenOdd.Length)];

                            Console.WriteLine("the ball fell on " + option1);
                            Console.ReadKey();
                            if (option1 == option)
                            {
                                input = input * 2;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "c")
                        {
                            Console.WriteLine(" You choose  Reds/Blacks:  payout will be amount gambled * 2");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            Console.ReadKey();
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                                Console.ReadKey();
                            }
                            money = money - input;
                            Console.Write("choose Red or Black: ");
                            string option = Console.ReadLine();


                            string option1 = colors[ran.Next(colors.Length)];

                            Console.WriteLine("your ball fell on " + numbers[ran.Next(numbers.Length)] + " " + option1);
                            Console.ReadKey();
                            if (option == option1)
                            {
                                input = input * 2;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.Clear();
                            }

                        }
                        else if (choice == "d")
                        {
                            Console.WriteLine("You chosen between 1-18 or 19-36");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                                Console.ReadKey();
                            }
                            money = money - input;
                            Console.Write(" Choose '1' for 1-18(low) or choose '2' for 19-36(high): ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball fell on " + option1 + " " + colors[ran.Next(colors.Length)]);

                            if ((option1 >= 1 && option1 <= 18 && option == "1")
                            || (option1 >= 19 && option1 <= 36 && option == "2"))
                            {

                                input = input * 2;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "e")
                        {
                            Console.WriteLine(" You choose : Dozens: payout will be amount gambled * 3 ");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            Console.ReadKey();
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                                Console.ReadKey();
                            }
                            money = money - input;
                            Console.Write(" Choose  a row first, second or third: ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball fell on " + option1 + " " + colors[ran.Next(colors.Length)]);
                            if (option1 >= 1 && option1 <= 12 && option == "first" ||
                                option1 >= 13 && option1 <= 24 && option == "second" ||
                                option1 >= 25 && option1 <= 36 && option == "third")
                            {

                                input = input * 3;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "f")
                        {
                            Console.WriteLine("You choose Columns: payout will be amount gambled *3 ");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                            }
                            money = money - input;
                            Console.Write(" Choose  a column first, second or third: ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            string option1 = columns[ran.Next(columns.Length)];
                            Console.WriteLine("The ball fell on " + option1);

                            if (option == option1)
                            {

                                input = input * 3;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "g")
                        {
                            Console.WriteLine("You choose Street: payout will be amount gambled * 12");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            int input;
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                            }
                            money = money - input;
                            Console.Write("Choose a row a. 1, 2, 3 or b. 22, 23, 24 type a or b : ");
                            string option = Console.ReadLine();

                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball fell on " + option1 + " " + colors[ran.Next(colors.Length)]);

                            if ((option == "a" && option1 <= 3) || (option == "b" && option1 >= 22 && option1 <= 24))
                            {
                                input = input * 12;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.WriteLine("Press Enter to continue");
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "h")
                        {
                            Console.WriteLine("You choose 6 Numbers: payout will be amount gambled * 6");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            int input;
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                            }
                            money = money - input;
                            Console.Write("Choose a row a. 1, 2, 3, 4, 5, 6 or b. 22, 23, 24, 25, 26, 27 : ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball fell on " + option1 + " " + colors[ran.Next(colors.Length)]);

                            if ((option == "a" && option1 <= 6) || (option == "b" &&
                               option1 >= 22 && option1 <= 26))
                            {
                                input = input * 6;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "i")
                        {
                            Console.WriteLine("You choose Split: payout will be amount gambled * 18 ");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            int input;
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                            }
                            money = money - input;
                            Console.Write("Choose a edge  a. 1, 2 or b. 11, 14 or c. 35, 36 type a or b or c : ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball landed on " + option1 + " " + colors[ran.Next(colors.Length)]);

                            if ((option == "a" && option1 <= 2) || (option == "b" &&
                                option1 == 11 || option1 == 14) || (option == "c"
                                && option1 == 35 || option1 == 36))
                            {
                                input = input * 18;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Lady luck wasnt on your side today you have " + money + " money left");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        else if (choice == "j")
                        {
                            Console.WriteLine("You choose Corner: payout will be amount gambled * 8");
                            Console.ReadKey();
                            Console.Write("You currently have " + money + " money, what would yo like to gamble : ");
                            int input;
                            while (!Int32.TryParse(Console.ReadLine(), out input))
                            {
                                Console.Write("Enter amount :");
                            }
                            money = money - input;
                            Console.WriteLine("");
                            Console.Write("Choose an intersection  a. 1,2,4,5 or b. 23,24,26,27 : ");
                            string option = Console.ReadLine();
                            Random ran = new Random();
                            int option1 = numbers[ran.Next(numbers.Length)];
                            Console.WriteLine("The ball fell on " + option1 + " " + colors[ran.Next(colors.Length)]);

                            if ((option == "a" && option1 <= 5) || (option == "b" &&
                                option1 == 23 || option1 == 24 || option1 == 26
                                || option1 == 27))
                            {
                                input = input * 8;
                                money = input + money;
                                Console.WriteLine("Great job you now have " + money + " money ");
                                Console.ReadKey();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("The roulette rolled: ");
                                Console.WriteLine("You lost! -$" + input + "!");
                                Console.WriteLine("<Press enter to continue>");
                                Console.ReadKey();
                                if (money == 0)
                                {
                                    Console.WriteLine("You are out of money.");
                                    Console.WriteLine("<Press enter to continue>");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
















