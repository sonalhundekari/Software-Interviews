// LeetCode 155 - Min Stack
// Difficulty: Medium
// Pattern: Stack storing (value, currentMin) pairs
//
// Time: O(1) all ops  Space: O(n)

public class MinStack
{
    private Stack<(int val, int min)> _stack = new();

    public void Push(int val)
    {
        int currentMin = _stack.Count > 0 ? Math.Min(val, _stack.Peek().min) : val;
        _stack.Push((val, currentMin));
    }

    public void Pop() => _stack.Pop();

    public int Top() => _stack.Peek().val;

    public int GetMin() => _stack.Peek().min;

    public static void Main()
    {
        var ms = new MinStack();
        ms.Push(-2); ms.Push(0); ms.Push(-3);
        Console.WriteLine(ms.GetMin()); // -3
        ms.Pop();
        Console.WriteLine(ms.Top());    // 0
        Console.WriteLine(ms.GetMin()); // -2
    }
}
