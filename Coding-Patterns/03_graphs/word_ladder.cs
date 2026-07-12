// LeetCode 127 - Word Ladder
// Difficulty: Hard
// Pattern: BFS shortest path with wildcard pattern map
//
// Time: O(M^2 * N)  Space: O(M^2 * N)

public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        // Build pattern -> words map
        var patternMap = new Dictionary<string, List<string>>();
        foreach (var word in wordList)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var pattern = word.Substring(0, i) + "*" + word.Substring(i + 1);
                if (!patternMap.ContainsKey(pattern)) patternMap[pattern] = new List<string>();
                patternMap[pattern].Add(word);
            }
        }

        var queue = new Queue<(string word, int len)>();
        queue.Enqueue((beginWord, 1));
        var visited = new HashSet<string> { beginWord };

        while (queue.Count > 0)
        {
            var (word, length) = queue.Dequeue();
            for (int i = 0; i < word.Length; i++)
            {
                var pattern = word.Substring(0, i) + "*" + word.Substring(i + 1);
                if (!patternMap.ContainsKey(pattern)) continue;
                foreach (var neighbor in patternMap[pattern])
                {
                    if (neighbor == endWord) return length + 1;
                    if (!visited.Contains(neighbor))
                    { visited.Add(neighbor); queue.Enqueue((neighbor, length + 1)); }
                }
            }
        }
        return 0;
    }
}
