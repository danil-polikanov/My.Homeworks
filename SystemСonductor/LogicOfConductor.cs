using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemСonductor
{
    class LogicOfConductor
    {

        string command = "";
        string LastDir = "";
        string folder = "";
        string dirName = "";
        int count = 0;
        public void Conduct()
        {
            Console.WriteLine("Чтобы пройти к определенной директории,введите cd \"путь директории\"");
            Console.WriteLine("Чтобы открыть файл введите open \"путь файла\"");
            Console.WriteLine("Чтобы завершить программу введите exit");
            do
            {
                if (count > 0)
                {
                    Console.Write("Введите команду: ");
                    command = Console.ReadLine();

                }

                if (command.StartsWith("cd") || command == "")
                {
                    if (command != "cd ..")
                    {
                        folder = command.Replace("cd ", "");
                        dirName = $"C:\\{folder}";
                    }

                    if (Directory.Exists(dirName) && command != "cd ..")
                    {
                        Console.WriteLine("Подкаталоги:");
                        string[] dirs = Directory.GetDirectories(dirName);
                        foreach (string s in dirs)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Файлы:");
                        string[] files = Directory.GetFiles(dirName);
                        foreach (string s in files)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("\n");

                    }
                    if (command == "cd ..")
                    {
                        string[] previouslyDirection = dirName.Split("\\");

                        foreach (var i in previouslyDirection)
                        {
                            if (i == previouslyDirection.Last())
                            {
                                dirName = dirName.Replace(i, "");
                                dirName = dirName.Remove(dirName.Length - 1);
                            }
                        }
                        if (dirName == "C:")
                        {
                            dirName = dirName + "\\";
                        }
                        if (Directory.Exists(dirName))
                        {
                            Console.WriteLine("Подкаталоги:");
                            string[] dirs = Directory.GetDirectories(dirName);
                            foreach (string s in dirs)
                            {
                                Console.WriteLine(s);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Файлы:");
                            string[] files = Directory.GetFiles(dirName);
                            foreach (string s in files)
                            {
                                Console.WriteLine(s);
                            }
                            Console.WriteLine("\n");
                        }
                    }

                    LastDir = folder;
                    count++;
                }
                if (command.StartsWith("open"))
                {
                    folder = command.Replace("open ", "");
                    dirName = folder;
                    if (command.EndsWith(".txt") || command.EndsWith(".ini") || command.EndsWith(".json"))
                    {
                        PrintFile(dirName);
                    }
                    else HexFile(dirName);
                }
            } while (command != "exit");
        }
        static bool PrintFile(string filename)
        {
            StreamReader sr;

            try
            {
                sr = new StreamReader(filename);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }

            string s;
            Console.WriteLine("The content of file {0}:", filename);

            s = sr.ReadLine();
            while (s != null)
            {
                Console.WriteLine(s);
                s = sr.ReadLine();
            }

            sr.Close();
            return true;
        }
        static void BinaryFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            foreach (byte b in r.ReadBytes((int)r.BaseStream.Length))
            {
                Console.Write(b);
                Console.Write(' ');
            }
            Console.ReadKey();
        }
        static void HexFile(string filename)
        {
            Stream inputStream = File.OpenRead(filename);

            byte[] buffer = new byte[inputStream.Length];

            inputStream.Read(buffer, 0, (int)inputStream.Length);

            string base64 = Convert.ToBase64String(buffer);

            StringBuilder text = new StringBuilder();

            foreach (byte b in buffer)
                text.Append(b.ToString("X2") + "\t");

            string hex = text.ToString();

            Console.WriteLine(hex);
            Console.WriteLine("\n");
        }
    }
}
