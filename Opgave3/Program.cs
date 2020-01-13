using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Opgave3
{
    class Program
    {
        private static bool GetFile(string path)
        {
            bool fileExists = File.Exists(path);
            if(fileExists)
            {
                List<int> ages = new List<int>();
                List<string> firstNames = new List<string>();
                List<string> lastNames = new List<string>();
                using(StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    string document = "";
                    while((document = reader.ReadLine()) != null)
                    {
                        string[] numbers = document.Split(',');
                        string names = "";
                        for(int i = 0; i < numbers.Length; i++)
                        {
                            int.TryParse(numbers[i], out int age);
                            if(age > 0)
                            {
                                ages.Add(age);
                            }
                        }
                        for(int i = 0; i < numbers.Length; i += 4)
                        {
                            names = numbers[i];
                            if(names != "")
                            {
                                firstNames.Add(names);
                            }
                        }
                        for(int i = 1; i < numbers.Length; i += 4)
                        {
                            names = numbers[i];
                            if(names != "")
                            {
                                lastNames.Add(names);
                            }
                        }
                        Console.WriteLine(document);
                    }
                    Console.WriteLine($"Laveste alder: {ages.Min()}");
                    Console.WriteLine($"Højeste alder: {ages.Max()}");
                    string longestFirstName = firstNames[0];
                    string shortestFirstName = firstNames[0];
                    foreach(string firstName in firstNames)
                    {
                        if(firstName.Length > longestFirstName.Length)
                        {
                            longestFirstName = firstName;
                        }
                        if(firstName.Length < shortestFirstName.Length && firstName != "")
                        {
                            shortestFirstName = firstName;
                        }
                    }
                    Console.WriteLine($"Længste fornavn: {longestFirstName}");
                    Console.WriteLine($"Korteste fornavn: {shortestFirstName}");

                    string[] fullNames = new string[firstNames.Count];
                    string longestFullName = "";
                    string shortestFullName = "";
                    for(int i = 0; i < (lastNames.Count + firstNames.Count) / 2; i++)
                    {
                        fullNames[i] = firstNames[i] + " " + lastNames[i];
                        longestFullName = fullNames[0];
                        shortestFullName = fullNames[0];
                        foreach(string fullName in fullNames)
                        {
                            if(fullNames[i].Length > longestFullName.Length)
                            {
                                longestFullName = fullName;
                            }
                            if(fullNames[i].Length < shortestFullName.Length)
                            {
                                shortestFullName = fullName;
                            }
                        }
                    }
                    Console.WriteLine($"Længste fulde navn: {longestFullName}");
                    Console.WriteLine($"Korteste fulde navn: {shortestFullName}");
                    Console.ReadLine();
                }
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;
            }
        }
        static void Main(string[] args)
        {
            GetFile(@"C:\persons.txt");
        }
    }
}
