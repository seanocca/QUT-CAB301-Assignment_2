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
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 0, targetCount: 100)]
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
            yield return ReadCSV(test_data[3]);
            yield return ReadCSV(test_data[4]);
            yield return ReadCSV(test_data[5]);
            yield return ReadCSV(test_data[6]);
            yield return ReadCSV(test_data[7]);
            yield return ReadCSV(test_data[8]);
            yield return ReadCSV(test_data[9]);
            yield return ReadCSV(test_data[10]);
            yield return ReadCSV(test_data[11]);
            yield return ReadCSV(test_data[12]);
            yield return ReadCSV(test_data[13]);
            yield return ReadCSV(test_data[14]);
            yield return ReadCSV(test_data[15]);
            yield return ReadCSV(test_data[16]);
            yield return ReadCSV(test_data[17]);
            yield return ReadCSV(test_data[18]);
            yield return ReadCSV(test_data[19]);
            yield return ReadCSV(test_data[20]);
            yield return ReadCSV(test_data[21]);
            yield return ReadCSV(test_data[22]);
            yield return ReadCSV(test_data[23]);
            yield return ReadCSV(test_data[24]);
            yield return ReadCSV(test_data[25]);
            yield return ReadCSV(test_data[26]);
            yield return ReadCSV(test_data[27]);
            yield return ReadCSV(test_data[28]);
            yield return ReadCSV(test_data[29]);
            yield return ReadCSV(test_data[30]);
            yield return ReadCSV(test_data[31]);
            yield return ReadCSV(test_data[32]);
            yield return ReadCSV(test_data[33]);
            yield return ReadCSV(test_data[34]);
            yield return ReadCSV(test_data[35]);
            yield return ReadCSV(test_data[36]);
            yield return ReadCSV(test_data[37]);
            yield return ReadCSV(test_data[38]);
            yield return ReadCSV(test_data[39]);
            yield return ReadCSV(test_data[40]);
            yield return ReadCSV(test_data[41]);
            yield return ReadCSV(test_data[42]);
            yield return ReadCSV(test_data[43]);
            yield return ReadCSV(test_data[44]);
            yield return ReadCSV(test_data[45]);
            yield return ReadCSV(test_data[46]);
            yield return ReadCSV(test_data[47]);
            yield return ReadCSV(test_data[48]);
            yield return ReadCSV(test_data[50]);
            yield return ReadCSV(test_data[51]);
            yield return ReadCSV(test_data[52]);
            yield return ReadCSV(test_data[53]);
            yield return ReadCSV(test_data[54]);
            yield return ReadCSV(test_data[55]);
            yield return ReadCSV(test_data[56]);
            yield return ReadCSV(test_data[57]);
            yield return ReadCSV(test_data[58]);
            yield return ReadCSV(test_data[59]);
            yield return ReadCSV(test_data[60]);
            yield return ReadCSV(test_data[61]);
            yield return ReadCSV(test_data[62]);
            yield return ReadCSV(test_data[63]);
            yield return ReadCSV(test_data[64]);
            yield return ReadCSV(test_data[65]);
            yield return ReadCSV(test_data[66]);
            yield return ReadCSV(test_data[67]);
            yield return ReadCSV(test_data[68]);
            yield return ReadCSV(test_data[69]);
            yield return ReadCSV(test_data[70]);
            yield return ReadCSV(test_data[71]);
            yield return ReadCSV(test_data[72]);
            yield return ReadCSV(test_data[73]);
            yield return ReadCSV(test_data[74]);
            yield return ReadCSV(test_data[75]);
            yield return ReadCSV(test_data[76]);
            yield return ReadCSV(test_data[77]);
            yield return ReadCSV(test_data[78]);
            yield return ReadCSV(test_data[79]);
            yield return ReadCSV(test_data[80]);
            yield return ReadCSV(test_data[81]);
            yield return ReadCSV(test_data[82]);
            yield return ReadCSV(test_data[83]);
            yield return ReadCSV(test_data[84]);
            yield return ReadCSV(test_data[85]);
            yield return ReadCSV(test_data[86]);
            yield return ReadCSV(test_data[87]);
            yield return ReadCSV(test_data[88]);
            yield return ReadCSV(test_data[89]);
            yield return ReadCSV(test_data[90]);
            yield return ReadCSV(test_data[91]);
            yield return ReadCSV(test_data[92]);
            yield return ReadCSV(test_data[93]);
            yield return ReadCSV(test_data[94]);
            yield return ReadCSV(test_data[95]);
            yield return ReadCSV(test_data[96]);
            yield return ReadCSV(test_data[97]);
            yield return ReadCSV(test_data[98]);
            yield return ReadCSV(test_data[99]);
        }


        /// <summary>
        /// An array of strings that locate the integer arrays in CSV files
        /// </summary>
        public string[] test_data = new string[]
        {
            "C:\\Users\\seano\\Desktop\\Test_Data\\1k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\2k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\3k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\4k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\5k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\6k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\7k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\8k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\9k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\10k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\11k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\12k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\13k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\14k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\15k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\16k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\17k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\18k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\19k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\20k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\21k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\22k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\23k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\24k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\25k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\26k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\27k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\28k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\29k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\30k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\31k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\32k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\33k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\34k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\35k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\36k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\37k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\38k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\39k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\40k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\41k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\42k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\43k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\44k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\45k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\46k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\47k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\48k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\49k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\50k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\51k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\52k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\53k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\54k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\55k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\56k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\57k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\58k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\59k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\60k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\61k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\62k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\63k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\64k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\65k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\66k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\67k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\68k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\69k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\70k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\71k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\72k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\73k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\74k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\75k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\76k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\77k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\78k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\79k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\80k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\81k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\82k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\83k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\84k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\85k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\86k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\87k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\88k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\89k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\90k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\91k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\92k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\93k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\94k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\95k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\96k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\97k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\98k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\99k.csv",
            "C:\\Users\\seano\\Desktop\\Test_Data\\100k.csv",
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
                    if ((++basicOps < 0) && i !=j && Math.Abs(A[i] - A[j]) < dmin)
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
                    double temp = Math.Abs(A[i] - A[j]);
                    if ((++basicOps < 0) && temp < dmin)
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
