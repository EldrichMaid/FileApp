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

    class FileWriter
    {
        public static void Main()
        {
            string tempFile = Path.GetTempFileName(); // используем генерацию имени файла.
            var fileInfo = new FileInfo(tempFile); // Создаем объект класса FileInfo.
            //Создаем файл и записываем в него.
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Name");
                sw.WriteLine("Path");
                sw.WriteLine("Element");
            }
            //Открываем файл и читаем из него.
            using (StreamReader sr = fileInfo.OpenText())
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }

            try
            {
                string tempFile2 = Path.GetTempFileName();
                var fileInfo2 = new FileInfo(tempFile2);
                // Убедимся, что файл назначения точно отсутствует
                fileInfo2.Delete();
                // Копируем информацию
                fileInfo.CopyTo(tempFile2);
                Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}.");
                //Удаляем ранее созданный файл.
                fileInfo.Delete();
                Console.WriteLine($"{tempFile} удален.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
        }
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
            try 
            {
                DirectoryInfo newDirectory = new DirectoryInfo(@"/Users/ivan.bannikov/Desktop/newDirectory");
                if (!newDirectory.Exists)
                    newDirectory.Create();
                Console.WriteLine(newDirectory.GetDirectories().Length + newDirectory.GetFiles().Length);
                Console.WriteLine($"Название каталога: {newDirectory.Name}");
                Console.WriteLine($"Полное название каталога: {newDirectory.FullName}");
                Console.WriteLine($"Время создания каталога: {newDirectory.CreationTime}");
                Console.WriteLine($"Корневой каталог: {newDirectory.Root}");
                newDirectory.Delete(true); // Удаление со всем содержимым
                Console.WriteLine("Каталог удален");
                //DirectoryInfo dirtotrash = new DirectoryInfo(@"C:\Users\ivan.bannikov\Desktop\testFolder");
                //string trashPath = "/Users/ivan.bannikov/.Trash";
                //dirtotrash.MoveTo(trashPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string filePath = @"C:\Users\ivan.bannikov\source\repos\FileApp\FileApp\Program.cs"; 
            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                Console.WriteLine(str);
            }
        }
    }
}

