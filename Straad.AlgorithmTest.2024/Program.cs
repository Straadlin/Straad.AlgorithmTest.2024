﻿using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Straad.AlgorithmTest._2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DosSum(); // 1
            //RevertString(); // 2
            //BalanceParentheses(); // 3
            BinarySearch(); // 4
        }

        #region DosSum

        private static void DosSum()
        {
            while (true)
            {
                Console.Clear();

                int targetNumber = 0;
                int[] array = new int[1000];

                InitializeArray(ref array, ref targetNumber);

                Console.WriteLine($"Target number is: {targetNumber}");
                Console.WriteLine("");

                DateTime initialTime = DateTime.Now;
                var numbersFounded = SearchNumbershWayOne(array, targetNumber);
                DateTime finalTime = DateTime.Now;
                TimeSpan lapse = finalTime - initialTime;

                Console.WriteLine("***First way***");
                Console.WriteLine($"Number 1 founded is: {numbersFounded[0]}");
                Console.WriteLine($"Number 2 dounded is: {numbersFounded[1]}");
                Console.WriteLine($"Lapse time is: {lapse}");

                Console.WriteLine("");

                initialTime = DateTime.Now;
                numbersFounded = SearchNumbershWayTwo(array, targetNumber);
                finalTime = DateTime.Now;
                lapse = finalTime - initialTime;

                Console.WriteLine("***Second way***");
                Console.WriteLine($"Number 1 founded is: {numbersFounded[0]}");
                Console.WriteLine($"Number 2 dounded is: {numbersFounded[1]}");
                Console.WriteLine($"Lapse time is: {lapse}");

                Console.WriteLine("");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Press any key to retry, or press Q to exit.");
                var key = Console.ReadKey();

                if (key.KeyChar.ToString().ToUpper() == "Q")
                {
                    Console.Clear();
                    break;
                }
            }
        }

        private static void InitializeArray(ref int[] array, ref int targetNumber)
        {
            Console.Write("Write a target number: ");
            targetNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Array numbers contains: [");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(1, targetNumber);
                Console.Write($" {array[i]} ");
            }

            Console.WriteLine("]");
            Console.WriteLine("");
        }

        /// <summary>
        /// Complex O(n)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetNumber"></param>
        /// <returns></returns>
        private static int[] SearchNumbershWayOne(int[] array, int targetNumber)
        {
            int[] numbersFounded = { 0, 0 };

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if ((array[i] + array[j]) == targetNumber)
                    {
                        numbersFounded[0] = array[i];
                        numbersFounded[1] = array[j];
                        break;
                    }
                }

                if (numbersFounded[0] > 0)
                    break;
            }

            return numbersFounded;
        }

        /// <summary>
        /// Complex O(n²)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetNumber"></param>
        /// <returns></returns>
        private static int[] SearchNumbershWayTwo(int[] array, int targetNumber)
        {
            Dictionary<int, int> candidates = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                var differenceToSearch = targetNumber - array[i];

                if (candidates.ContainsKey(differenceToSearch))
                {
                    return new int[] { array[candidates[differenceToSearch]], array[i] };
                }

                if (!candidates.ContainsKey(array[i]))
                {
                    candidates.Add(array[i], i);
                }
            }

            return new int[] { 0, 0 };
        }

        private static int[] SearchNumbershWayIA(int[] array, int targetNumber)
        {
            Dictionary<int, int> seenNumbers = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                int requiredNumber = targetNumber - array[i];

                if (seenNumbers.ContainsKey(requiredNumber))
                {
                    return new int[] { array[seenNumbers[requiredNumber]], array[i] };
                }

                if (!seenNumbers.ContainsKey(array[i]))
                {
                    seenNumbers[array[i]] = i;
                }
            }
            return new int[] { 0, 0 };
        }

        #endregion DosSum

        #region RevertString

        private static void RevertString()
        {
            Console.Write("Write a string and press enter: ");
            var stringToRevert = Console.ReadLine();

            var stringSplited = stringToRevert.ToArray();

            int x = 0;
            int y = stringSplited.Length - 1;
            while (x < y)
            {
                char aux;

                aux = stringSplited[x];
                stringSplited[x] = stringSplited[y];
                stringSplited[y] = aux;

                x++;
                y--;
                Console.WriteLine(x);
            }

            Console.WriteLine(string.Concat(stringSplited));
            Console.ReadKey();
        }

        #endregion RevertString

        #region BalanceParentheses

        private static void BalanceParentheses()
        {
            while (true)
            {
                Console.Write("Write an instruction: ");
                var expressionToCheck = Console.ReadLine();

                IsBalanced(expressionToCheck);

                Console.WriteLine("");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Press any key to retry, or press Q to exit.");
                var key = Console.ReadKey();

                if (key.KeyChar.ToString().ToUpper() == "Q")
                {
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("");
                    Console.Clear();
                    break;
                }
            }
        }

        private static void IsBalanced(object expression)
        {
            throw new NotImplementedException();
        }

        private static void IsBalanced(string expression)
        {
            var stack = new Stack();
            string characteresOpen = "([{";
            string charactereClose = "}])";
            bool isBalanced = true;

            foreach (var item in expression)
            {
                if (characteresOpen.Contains(item))
                {
                    stack.Push(item);
                }
                else if (charactereClose.Contains(item))
                {
                    if (!stack.ContainsItems())
                    {
                        isBalanced = false;
                        break;
                    }

                    var last = stack.Pop();

                    if (
                            (item == ')' && last != '(') ||
                            (item == ']' && last != '[') ||
                            (item == '}' && last != '{')
                        )
                    {
                        isBalanced = false;
                    }
                }
            }

            Console.WriteLine("");

            if (isBalanced)
                Console.WriteLine("La cadena sí está balanceada.");
            else
                Console.WriteLine("La cadena no está balanceada.");
        }

        #endregion BalanceParentheses

        #region BinarySearch

        private static void BinarySearch()
        {
            // Target number: 15
            // We'll start at middle, using 12 number.
            // Ordered List: [3, 6, 9, 12, 15, 18, 21]
        }

        #endregion BinarySearch
    }

    #region BalanceParentheses

    public class Stack
    {
        private List<char> charList = new List<char>();

        public void Push(char character)
        {
            charList.Add(character);
        }

        public char Pop()
        {
            int position = charList.Count - 1;

            if (position > -1)
            {
                var charToReturn = charList[position];
                charList.RemoveAt(position);
                return charToReturn;
            }

            return ' ';
        }

        public bool ContainsItems()
        {
            return charList.Count > 0;
        }
    }

    #endregion BalanceParentheses

}