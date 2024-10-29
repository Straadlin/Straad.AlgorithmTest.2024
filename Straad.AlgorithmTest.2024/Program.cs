using System.Runtime.CompilerServices;

namespace Straad.AlgorithmTest._2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RevertString();
            //DosSum();
        }

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

                initialTime = DateTime.Now;
                numbersFounded = SearchNumbershWayIA(array, targetNumber);
                finalTime = DateTime.Now;
                lapse = finalTime - initialTime;

                Console.WriteLine("***IA way***");
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

    }
}