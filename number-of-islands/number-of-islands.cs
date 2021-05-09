public class Solution {
    public int NumIslands(char[][] grid) 
    {
        int numberOfIslands = 0;
        for(int i = 0 ; i < grid.Length ; i++)
        {
            for(int j = 0 ; j < grid[i].Length ; j++)
            {
                if(grid[i][j] == '1')
                {
                    DFS(i,j,grid);
                    numberOfIslands++;
                }
            }
        }
        return numberOfIslands;
    }
    private bool IsSafe(int x,int y,char[][] grid)
    {
        if(x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length)
        {
            return true;
        }
        return false;
    }
    private void DFS(int x,int y,char[][] grid)
    {
        if(IsSafe(x,y,grid) && grid[x][y] == '1')
        {
            grid[x][y] = '0';
            DFS(x+1,y,grid);
            DFS(x-1,y,grid);
            DFS(x,y+1,grid);
            DFS(x,y-1,grid);
        }
        else
        {
            return;
        }
    }
}