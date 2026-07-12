// LeetCode 146 - LRU Cache
// Difficulty: Medium
// Pattern: HashMap + Doubly Linked List
//
// Time: O(1) for get and put  Space: O(capacity)

public class LRUCache
{
    private class Node
    {
        public int Key, Val;
        public Node Prev, Next;
        public Node(int k = 0, int v = 0) { Key = k; Val = v; }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _cache = new();
    private readonly Node _head = new(); // LRU end (dummy)
    private readonly Node _tail = new(); // MRU end (dummy)

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    private void Remove(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    private void InsertTail(Node node)
    {
        node.Prev = _tail.Prev;
        node.Next = _tail;
        _tail.Prev.Next = node;
        _tail.Prev = node;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node)) return -1;
        Remove(node);
        InsertTail(node);
        return node.Val;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key)) Remove(_cache[key]);
        var node = new Node(key, value);
        _cache[key] = node;
        InsertTail(node);
        if (_cache.Count > _capacity)
        {
            var lru = _head.Next;
            Remove(lru);
            _cache.Remove(lru.Key);
        }
    }

    public static void Main()
    {
        var lru = new LRUCache(2);
        lru.Put(1, 1); lru.Put(2, 2);
        Console.WriteLine(lru.Get(1));  // 1
        lru.Put(3, 3);                  // evicts key 2
        Console.WriteLine(lru.Get(2));  // -1
        lru.Put(4, 4);                  // evicts key 1
        Console.WriteLine(lru.Get(1));  // -1
        Console.WriteLine(lru.Get(3));  // 3
        Console.WriteLine(lru.Get(4));  // 4
    }
}
