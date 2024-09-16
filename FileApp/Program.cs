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

        static void Main()
        {
            
        }
    }
}
