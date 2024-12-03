using static System.Console;

namespace Advent03;

internal static class Program
{
    static void Main()
    {
        string lines = ReadData();

        int firstSolve = Solve1(lines);
        int secondSolve = Solve2(lines);

        WriteLine(firstSolve);
        WriteLine(secondSolve);

        ReadKey();
    }
    static string ReadData()
    => string.Concat(File.ReadLines("data.txt"));

    static int Solve1(string data)
        => data.Split("mul(")
               .Where(x => x.Contains(')'))
               .Select(x => x.Split(')')[0])
               .Where(x => x.Contains(',') && x.Split(',').All(t => int.TryParse(t, out _)))
               .Select(x => x.Split(',').Select(int.Parse).ToArray())
               .Sum(x => x[0] * x[1]);

    static int Solve2(string data)
    {
        string[] temp = data.Split("don't()");
        IEnumerable<string> temp2 = temp
            .Skip(1)
            .Where(x => x.Contains("do()"))
            .Select(x => string.Concat(x.Split("do()")[1..]));
        string filteredData = string.Concat(temp[0], string.Concat(temp2));
        return Solve1(filteredData);
    }
}
