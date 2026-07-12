// LeetCode 435 - Non-overlapping Intervals
// Difficulty: Medium
// Pattern: Greedy (sort by end time)
//
// Time: O(n log n)  Space: O(1)

public class NonOverlappingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1] - b[1]);
        int removed = 0, prevEnd = int.MinValue;

        foreach (var interval in intervals)
        {
            if (interval[0] >= prevEnd) prevEnd = interval[1];
            else removed++;
        }
        return removed;
    }
}
