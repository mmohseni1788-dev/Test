
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int dataSize = 500_000;
        var random = new Random();

        // تولید داده int
        var intData = Enumerable.Range(1, dataSize).OrderBy(_ => random.Next()).ToArray();

        // تولید داده string
        var stringData = intData.Select(x => $"Item{x}").ToArray();

        // مقایسه روی داده int
        Console.WriteLine("===== compare search in int Type=====");
        CompareSearchAlgorithms(intData);

        // مقایسه روی داده string
        Console.WriteLine("\n===== compare search in string type=====");
        CompareSearchAlgorithms(stringData);
    }

    static void CompareSearchAlgorithms<T>(T[] data)
    {
        int dataSize = data.Length;
        var random = new Random();
        T target = data[random.Next(dataSize)];

        // ساخت Collection ها
        var array = new T[dataSize];
        data.CopyTo(array, 0);
        var list = new List<T>(data);
        var hashSet = new HashSet<T>(data);
        var dict = data.ToDictionary(x => x, x => x);
        var sortedSet = new SortedSet<T>(data);

        Console.WriteLine($"search for: {target}");

        // Linear Search
        MeasureTime("Array - Linear Search", () => Array.IndexOf(array, target));
        MeasureTime("List - Linear Search", () => list.IndexOf(target));

        // Binary Search (Array و List باید مرتب شوند)
        Array.Sort(array);
        MeasureTime("Array - Binary Search", () => Array.BinarySearch(array, target));

        list.Sort();
        MeasureTime("List - Binary Search", () => list.BinarySearch(target));

        // Hash-based Search
        MeasureTime("HashSet - Contains", () => hashSet.Contains(target));
        MeasureTime("Dictionary - ContainsKey", () => dict.ContainsKey(target));
        MeasureTime("SortedSet - Contains", () => sortedSet.Contains(target));
    }

    static void MeasureTime(string description, Func<object> action)
    {
        var sw = Stopwatch.StartNew();
        var result = action();
        sw.Stop();
        Console.WriteLine($"{description,-30} : time of run = {sw.ElapsedMilliseconds,5} ms, result = {result}");
    }
}