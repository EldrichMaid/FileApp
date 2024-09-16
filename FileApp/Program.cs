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
    internal class Program
    {
        static void Main()
        {
            
        }
    }
}
