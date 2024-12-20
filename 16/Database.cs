using System.Xml.Serialization;

namespace _16
{
    internal static class Database
    {
        public static List<HashSet<(int, int)>> Data { get; set; } = new();
    }
}
