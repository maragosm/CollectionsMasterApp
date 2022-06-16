using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrays

            //Array Creation
            var myArray01 = new int[50];

            //Populates array with 50 random integers < 50
            Populater(myArray01);

            //Announces first and last array entries
            Console.WriteLine($"The first entry in the array is {myArray01[0]}");
            Console.WriteLine($"The first entry in the array is {myArray01[myArray01.Length - 1]}");
            Console.WriteLine();

            //Prints array entries in order
            Console.WriteLine("All Numbers Original");
            NumberPrinter(myArray01);
            Console.WriteLine("-------------------");

            //Prints array entries in reverse order
            Console.WriteLine("All Numbers Reversed:");
            ReverseArray(myArray01);
            Console.WriteLine("-------------------");

            //Changes all nubers evenly divisible by three to zero, prints results
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(myArray01);
            Console.WriteLine("-------------------");

            //Sorts values in ascending order and prints the results
            Console.WriteLine("Sorted numbers:");
            Sorter(myArray01);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");
            Console.WriteLine();

            //List creation
            var numbers = new List<int>();

            //Initial list length
            Console.WriteLine($"Initial list length is {numbers.Count} values long.");

            //Population of list with random numbers less than 50          
            Populater(numbers);

            //New list length
            Console.WriteLine($"New list length is {numbers.Count} values long.");

            Console.WriteLine("---------------------");

            //User input value - checks if value is present in list
            Console.WriteLine("What number will you search for in the number list?");
            Console.Write("Your number: ");
            string userGuessRaw = Console.ReadLine();
            NumberChecker(numbers, userGuessRaw);

            Console.WriteLine("-------------------");

            //Prints all list values
            Console.WriteLine("All Numbers:");
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //Removes odd values and prints the resulting list
            Console.WriteLine("Evens Only!!");
            OddKiller(numbers);
            
            Console.WriteLine("------------------");

            //Sorts list values and prints the results
            Console.WriteLine("Sorted Evens!!");
            Sorter(numbers);
            
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] numbersArray = numbers.ToArray();

            //TODO: Clear the list
            GarbageCan(numbers);

            #endregion
        }

        private static void ThreeKiller(int[] myArray01)
        {
            for (int i = 0; i < myArray01.Length; i++)
            {
                if (myArray01[i] % 3 == 0)
                {
                    myArray01[i] = 0;
                }
                Console.WriteLine(myArray01[i]);
            }
        }

        private static void OddKiller(List<int> numbers)
        {
            numbers.RemoveAll(i => i % 2 != 0);
            NumberPrinter(numbers);
        }

        private static void Sorter(int[] myArray01)
        {
            Array.Sort(myArray01);
            NumberPrinter(myArray01);
        }

        private static void Sorter(List<int> numbers)
        {
            numbers.Sort();
            NumberPrinter(numbers);
        }

        private static void NumberChecker(List<int> numbers, string userGuessRaw)
        {
            int userGuess;
            bool isNumerical = int.TryParse(userGuessRaw, out userGuess);
            if (isNumerical == true)
            {
                if (numbers.Contains(userGuess) == true)
                {
                    Console.WriteLine($"Congradulations! {userGuess} is within the random list");
                }
                else
                { 
                Console.WriteLine($"Sorry, {userGuessRaw} was not in the random list");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, {userGuessRaw} is not a valid integer. Please try entering another value.");
                Console.Write("Your number: ");
                userGuessRaw = Console.ReadLine();
                NumberChecker(numbers, userGuessRaw);
            }
        }

        private static void Populater(List<int> numbers)
        {
            for (int i = 0; i < 50; i++)
            {
                Random rnd1 = new Random();
                numbers.Add(rnd1.Next(50));
            }
        }

        private static void Populater(int[] myArray01)
        {
            for (int i = 0; i < myArray01.Length; i++)
            {
                Random rnd1 = new Random();
                myArray01[i] = rnd1.Next(50);
            }
        }        

        private static void GarbageCan(List<int> numbers)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                numbers.Remove(numbers[i]);
            }
        }

        private static void ReverseArray(int[] myArray01)
        {
            Array.Reverse(myArray01);
            NumberPrinter(myArray01);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
