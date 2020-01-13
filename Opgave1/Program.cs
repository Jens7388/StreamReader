using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Opgave1
{

    class Program
    {
        private static bool GetNumbersFromFile(string path, out List<int> numberList)
        {
            bool fileExists = File.Exists(path);
            if(fileExists == true)
            {
                numberList = new List<int>();
                using(StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    int sum = 0;
                    string document = "";
                    while((document = reader.ReadLine()) != null)
                    {
                        //skærer tabs ud af dokumentet, så tallene kan konverteres
                        string[] numbers = document.Split('\t');
                        for(int i = 0; i < numbers.Length; i++)
                        {
                            int.TryParse(numbers[i], out sum);
                            numberList.Add(sum);
                        }
                        Console.WriteLine(document);
                    }
                    Console.WriteLine($"Tallenes sum: {numberList.Sum()}");
                    Console.ReadLine();
                    return true;
                }
            }
            else
            {
                numberList = null;
                Console.WriteLine("Denne fil findes ikke!");
                Console.ReadLine();
                return false;
            }
        }

        private static void Main()
        {
            GetNumbersFromFile(@"C:\numbers.txt", out List<int> numberList);
        }
    }
}

