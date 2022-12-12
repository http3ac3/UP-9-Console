using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UP_9._2_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(path, "out.txt");

            List<string> strings = new List<string>();

            int i = 0;
            Console.WriteLine("Содержимое файла: ");
            foreach (string line in File.ReadLines(fullPath))
            {
                strings.Add(line);
                Console.WriteLine(strings[i]);
                i++;
            }

            var orderedStrings = strings.OrderBy(s => s.Length);
            
            Console.WriteLine($"Самая короткая строка -> \"{orderedStrings.ElementAt(0)}\", длина -> {orderedStrings.ElementAt(0).Length}");

        }
    }
}
