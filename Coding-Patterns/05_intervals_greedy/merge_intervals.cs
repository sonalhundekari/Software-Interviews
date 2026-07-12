// LeetCode 56 - Merge Intervals
// Difficulty: Medium
// Pattern: Sort + linear sweep
//
// Time: O(n log n)  Space: O(n)

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        var merged = new List<int[]> { intervals[0] };

        foreach (var interval in intervals.Skip(1))
        {
            var last = merged[^1];
            if (interval[0] <= last[1])
                last[1] = Math.Max(last[1], interval[1]);
            else
                merged.Add(interval);
        }
        return merged.ToArray();
    }
}
