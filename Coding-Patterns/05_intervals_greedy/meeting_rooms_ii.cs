// LeetCode 253 - Meeting Rooms II
// Difficulty: Medium
// Pattern: Min-heap of end times
//
// Time: O(n log n)  Space: O(n)

public class MeetingRoomsII
{
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;
        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        // Min-heap: smallest end time at top
        var heap = new SortedDictionary<int, int>(); // endTime -> count
        void Push(int t) { heap[t] = heap.GetValueOrDefault(t, 0) + 1; }
        void Pop() {
            var first = heap.First();
            if (first.Value == 1) heap.Remove(first.Key);
            else heap[first.Key]--;
        }
        int PeekMin() => heap.First().Key;

        foreach (var interval in intervals)
        {
            if (heap.Count > 0 && PeekMin() <= interval[0])
                Pop(); // reuse room
            Push(interval[1]);
        }
        return heap.Values.Sum();
    }
}
