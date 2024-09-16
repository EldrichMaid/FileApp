using System;
using System.IO;
namespace FileApp
{
    public class Drive
    {
        public string Name { get; }
        public long Space { get; }
        public long FreeSpace { get; }
        public Drive(string name, long space, long freespace)
        {
            Name = name;
            Space = space;
            FreeSpace = freespace;
        }
    }

    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();
    }

    internal class Program
    {
        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }

        static void GetCatalogs()
        {
            string dirName = @"C:\\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }
        static void Main()
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }

            GetCatalogs();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"С:\\");
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                    DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                    if (!newDirectory.Exists)
                        newDirectory.Create();
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

