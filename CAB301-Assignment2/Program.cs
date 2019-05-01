using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Engines;
using System.Linq;
using System.Collections.Generic;

namespace CAB301_Assignment2
{
    class Program
    {
        /// <summary>
        /// Runs the benchmark and subsequent tests
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RunDualAlgorithm>(new Config());
            Console.ReadLine();
        }
    }

    /// <summary>
    /// This class overides the config to enable R Lang support, 
    /// graphing, and exporting of documents
    /// </summary>
    class Config : ManualConfig
    {
        public Config()
        {
            Add(CsvMeasurementsExporter.Default);
            Add(RPlotExporter.Default);
            Add(DefaultConfig.Instance.GetExporters().ToArray());
            Add(DefaultConfig.Instance.GetLoggers().ToArray());
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray());
        }
    }

    /// <summary>
    /// A class that runs the algorithm, setup and testing functions for the testing 
    /// of the Brute Force Median algorithm
    /// </summary>
    [MinColumn, MaxColumn, HtmlExporter, CsvMeasurementsExporter, RPlotExporter]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 0, targetCount: 5)]
    public class RunDualAlgorithm
    {
        #region Functional Testing


        /// <summary>
        /// Function to check the correct application and 
        /// results of the Brute Force Median Algorithm
        /// </summary>
        public void FunctionalTesting()
        {
            List<int[]> testing_array = new List<int[]>
            {
                new int[] { 9, 2, 1, 4, 10, 5 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 6, 5, 4, 3, 2, 1 },
                new int[] { 9, 9, 9, 9, 9, 9 },
                new int[] { 1, 1, 1, 1, 1, 1 },
                new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 4, 6, 8, 10 },
                new int[] { 1, 1, 1, 5, 9, 9, 9 },
                new int[] { 5, 1, 1, 1, 9, 9, 9 },
                new int[] { 1, 2, 3, 4, 6, 7, 5 },
                new int[] { 1, 24989487, 10384, 1234897, 3498, 5000, 123907, 329847, 2143097},
                new int[] { 1 },
                new int[] { 100, 90, 81, 73, 66, 60, 55, 51, 28, 46, 45 }
            };


            // Loops through each of the above arrays to test and
            // output the results of the algorithm
            foreach (int[] test in testing_array)
            {
                double result = MinDistance(test);
                double result2 = MinDistance2(test);
                var stringOutput = string.Join(", ", test);
                Console.WriteLine("Array Contents: " + stringOutput);
                Console.WriteLine("Output of First Algortithm: " + result);
                Console.WriteLine("Output of Second Algortithm: " + result);
                Console.WriteLine();
            }
        }

        //public RunDualAlgorithm()
        //{
        //    FunctionalTesting();
        //}

        #endregion

        #region Algorithm Testing


        /// <summary>
        /// This method reads a CSV of numbers into an array
        /// </summary>
        /// <param name="path"> a file path to a particular dataset </param>
        /// <returns> an array of integers </returns>
        private static int[] ReadCSV(string path)
        {
            string[] stringData = File.ReadAllLines(path);
            int[] data = Array.ConvertAll(stringData, int.Parse);
            return data;
        }


        /// <summary>
        /// The enumerable of type int array so the 
        /// application can loop through and test each of the arrays
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int[]> Data()
        {
            yield return ReadCSV(test_data[0]);
            yield return ReadCSV(test_data[1]);
            yield return ReadCSV(test_data[2]);
        }


        /// <summary>
        /// An array of strings that locate the integer arrays in CSV files
        /// </summary>
        public string[] test_data = new string[]
        {
            "C:\\Users\\seano\\Desktop\\Test_Data\\10k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\20k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\30k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\40k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\50k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\60k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\70k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\80k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\90k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\100k.csv"
        };

        /// <summary>
        /// The first algorithm that finds the smallest distance 
        /// between the closest two elements in the array
        /// </summary>
        /// <param name="A"></param>
        /// <returns> Minimum distance between two of its elements </returns>
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public double MinDistance(int[] A)
        {
            int basicOps = 0;
            double dmin = double.PositiveInfinity;
            for (int i = 0; i <= A.Length - 1; i++)
            {
                for (int j = 0; j <= A.Length - 1; j++)
                {
                    basicOps++;
                    if (i!=j && Math.Abs(A[i] - A[j]) < dmin)
                    {
                        dmin = Math.Abs(A[i] - A[j]);
                    }
                }
            }
            Console.WriteLine("Operations:  " + basicOps);
            Console.WriteLine("Output: " + dmin);
            return dmin;
        }

        /// <summary>
        /// The second algorithm that finds the smallest distance
        /// between the closest two elements in the array
        /// </summary>
        /// <param name="A"></param>
        /// <returns> The minimum distance d between two of its elements </returns>
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public double MinDistance2(int[] A)
        {
            int basicOps = 0;
            double dmin = double.PositiveInfinity;
            for (int i = 0; i <= A.Length - 1; i++)
            {
                for (int j = i + 1; j <= A.Length - 1; j++)
                {
                    basicOps++;
                    double temp = Math.Abs(A[i] - A[j]);
                    if (temp < dmin)
                    {
                        dmin = temp;
                    }
                }
            }
            Console.WriteLine("Operations:  " + basicOps);
            Console.WriteLine("Output: " + dmin);
            return dmin;
        }

        #endregion
    }
}
