using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Opgave2
{
    class Program
    {
        private static bool GetBoxesFromFile(string path, out List<Box> boxList)
        {
            bool fileExists = File.Exists(path);
            if(fileExists)
            {
                boxList = new List<Box>();
                List<int> volumes = new List<int>();
                List<int> surfaces = new List<int>();
                using(StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    string document = "";
                    while((document = reader.ReadLine()) != null)
                    {
                        Box box = new Box();
                        string[] measurements = document.Split(',');
                        for(int i = 0; i < measurements.Length; i += 4)
                        {
                            int.TryParse(measurements[i], out int height);
                            if(height >= 0)
                            {
                                box.Height = height;
                            }
                        }
                        for(int i = 1; i < measurements.Length; i += 4)
                        {
                            int.TryParse(measurements[i], out int length);
                            if(length >= 0)
                            {
                                box.Length = length;
                            }
                        }
                        for(int i = 2; i < measurements.Length; i += 4)
                        {
                            int.TryParse(measurements[i], out int width);
                            if(width >= 0)
                            {
                                box.Width = width;
                            }
                        }
                        boxList.Add(box);
                    }
                    for(int i = 0; i < boxList.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. kasses mål:");
                        boxList[i].CalculateSurface();
                        surfaces.Add(boxList[i].Surface);
                        boxList[i].CalculateVolume();
                        volumes.Add(boxList[i].Volume);
                        boxList[i].PrintInfo();
                    }
                    Console.WriteLine($"Højeste rumfang: {volumes.Max()} cm3");
                    Console.WriteLine($"Laveste rumfang: {volumes.Min()} cm3");
                    Console.WriteLine($"Højeste samlede overfladeareal: {surfaces.Max()} cm2");
                    Console.WriteLine($"Laveste samlede overfladeareal: {surfaces.Min()} cm2");
                    Console.ReadLine();
                }
                return true;
            }
            else
            {
                boxList = null;
                Console.WriteLine("Denne fil findes ikke!");
                return false;
            }
        }
        private static void Main()
        {
            GetBoxesFromFile("C:/boxes.txt", out List<Box> boxList);
        }
    }
}
