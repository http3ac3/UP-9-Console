using System;
using System.IO;

namespace UP_9._1_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(path, "out.txt");

            FileStream file = File.Create(fullPath);
            BinaryWriter fileOut = new BinaryWriter(file);
            
            int N;

            Console.Write("Введите N -> ");
            while(!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Введено недопустимое значение!\nВведите N ->");
            }
            int count = 0;
            Console.Write("Последовательность Фиббоначи до N -> ");
            for (int i = 1, j = 1; count < N; i+=j, count++)
            {
                Console.Write(i + " ");
                fileOut.Write(i);
                j = i - j;
            }
            Console.WriteLine();
            fileOut.Close();
            file.Close();

            file = new FileStream(fullPath, FileMode.Open);
            BinaryReader fileRead = new BinaryReader(file);
            long bytes = file.Length;  
            count = 1;
            for (long i = 0; i < bytes; i+=4)
            {
                if (count % 3 == 0)
                {
                    count++;
                    continue;
                }
                file.Seek(i, SeekOrigin.Begin);
                var number = fileRead.ReadInt32();
                Console.WriteLine(number + "\n");
                count++;
            }
            fileRead.Close();
            file.Close();
        }
    }
}
