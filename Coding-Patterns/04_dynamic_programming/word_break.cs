// LeetCode 139 - Word Break
// Difficulty: Medium
// Pattern: 1D DP + HashSet lookup
//
// Time: O(n^2)  Space: O(n)

public class WordBreak
{
    public bool CanBreak(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        int n = s.Length;
        var dp = new bool[n + 1];
        dp[0] = true;

        for (int i = 1; i <= n; i++)
            for (int j = 0; j < i; j++)
                if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                { dp[i] = true; break; }

        return dp[n];
    }
}
