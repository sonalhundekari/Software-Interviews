// LeetCode 49 - Group Anagrams
// Difficulty: Medium
// Pattern: HashMap with sort key
//
// Problem: Given an array of strings, group the anagrams together.
//
// Approach: Sort each word — anagrams produce the same sorted form.
// Use the sorted string as a dictionary key to group originals.
//
// Time: O(n * k log k)  where k = max word length
// Space: O(n * k)

public class GroupAnagrams
{
    public IList<IList<string>> Solve(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();
        foreach (var word in strs)
        {
            var chars = word.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);

            if (!groups.ContainsKey(key))
                groups[key] = new List<string>();
            groups[key].Add(word);
        }
        return groups.Values.Cast<IList<string>>().ToList();
    }

    public static void Main()
    {
        var sol = new GroupAnagrams();
        var result = sol.Solve(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        foreach (var group in result)
            Console.WriteLine(string.Join(", ", group));
        // ["eat","tea","ate"], ["tan","nat"], ["bat"]
    }
}
