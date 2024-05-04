using task_of_the_satchel;

public static class Program
{
    public static void Main()
    {
        const uint MAX_WEIGHT = 30;

        Thing[] things =
        {
            new Thing { Name = "Предмет А", Price = 30, Weight = 5 },
            new Thing { Name = "Предмет Б", Price = 54, Weight = 30 },
            new Thing { Name = "Предмет В", Price = 25, Weight = 25 },
            new Thing { Name = "Предмет Г", Price = 25, Weight = 1 },
            new Thing { Name = "Предмет Д", Price = 99, Weight = 31 }
        };

        things = things.Where(x => x.Weight <= MAX_WEIGHT).ToArray();

        Backpack backpack = GetBackpack(things, MAX_WEIGHT);
        Console.WriteLine($"Рюкзак размером {backpack.TotalWeight} и стоимостью {backpack.TotalPrice} должен содержать следующие предметы:");
        Console.WriteLine(string.Join(", ", backpack));
    }

    private static Backpack GetBackpack(IReadOnlyList<Thing> things, uint maxWeight)
    {
        int[] indexSet = Enumerable.Range(0, things.Count).ToArray();
        var bestBackpack = new Backpack();
        do
        {
            var backpack = new Backpack();
            Func<int, bool> hasSpace = index => backpack.TotalWeight + things[index].Weight <= maxWeight;
            foreach (int index in indexSet.TakeWhile(hasSpace))
                backpack.Add(things[index]);
            if (backpack.TotalPrice > bestBackpack.TotalPrice)
                bestBackpack = backpack;
        }
        while (NextBackpack(indexSet));
        return bestBackpack;
    }

    private static bool NextBackpack(IList<int> set)
    {
        int j = set.Count - 2;
        while (j != -1 && set[j] >= set[j + 1]) j--;
        if (j == -1)
            return false;
        int k = set.Count - 1;
        while (set[j] >= set[k]) k--;
        Swap(set, j, k);
        int l = j + 1, r = set.Count - 1;
        while (l < r)
            Swap(set, l++, r--);
        return true;
    }

    private static void Swap<T>(IList<T> set, int i, int j)
    {
        T temp = set[i];
        set[i] = set[j];
        set[j] = temp;
    }
}