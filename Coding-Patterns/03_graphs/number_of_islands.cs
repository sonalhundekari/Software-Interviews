// LeetCode 200 - Number of Islands
// Difficulty: Medium
// Pattern: DFS flood fill
//
// Time: O(m * n)  Space: O(m * n)

public class NumberOfIslands
{
    public int NumIslands(char[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length, count = 0;
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (grid[r][c] == '1') { Dfs(grid, r, c, rows, cols); count++; }
        return count;
    }

    private void Dfs(char[][] grid, int r, int c, int rows, int cols)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] != '1') return;
        grid[r][c] = '0';
        Dfs(grid, r + 1, c, rows, cols);
        Dfs(grid, r - 1, c, rows, cols);
        Dfs(grid, r, c + 1, rows, cols);
        Dfs(grid, r, c - 1, rows, cols);
    }
}
