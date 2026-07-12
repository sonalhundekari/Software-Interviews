// LeetCode 3 - Longest Substring Without Repeating Characters
// Difficulty: Medium
// Pattern: Sliding window + HashSet
//
// Problem: Find the length of the longest substring without repeating characters.
//
// Approach: Sliding window [left, right]. Expand right, shrink left on duplicates.
//
// Time: O(n)  Space: O(min(n, alphabet_size))

public class LongestSubstringWithoutRepeating
{
    public int LengthOfLongestSubstring(string s)
    {
        var charSet = new HashSet<char>();
        int left = 0, maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left]);
                left++;
            }
            charSet.Add(s[right]);
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
    }

    public static void Main()
    {
        var sol = new LongestSubstringWithoutRepeating();
        Console.WriteLine(sol.LengthOfLongestSubstring("abcabcbb")); // 3
        Console.WriteLine(sol.LengthOfLongestSubstring("bbbbb"));    // 1
        Console.WriteLine(sol.LengthOfLongestSubstring("pwwkew"));   // 3
    }
}
