public class Solution {
    int maxGold = 0;
    public int GetMaximumGold(int[][] grid) 
    {
      if(grid == null) return 0;
        
      for(int i = 0 ; i < grid.Length ; i++)
      {
          for(int j = 0 ; j < grid[i].Length ; j++)
          {
              if(grid[i][j] != 0)
              {
                  DFS(grid,i,j,0);
              }
          }
      }
        return maxGold;
    }
    private bool IsSafe(int x,int y, int[][] grid)
    {
        if(x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y]!= 0)
        {
            return true;
        }
        return false;
    }
    private void DFS(int[][] grid,int x,int y,int currentSum)
    {
        if(IsSafe(x,y,grid))
        {
            currentSum += grid[x][y];
            int val = grid[x][y];
            grid[x][y] = 0;
            DFS(grid,x+1,y,currentSum);
            DFS(grid,x-1,y,currentSum);
            DFS(grid,x,y+1,currentSum);
            DFS(grid,x,y-1,currentSum); 
            grid[x][y] = val;
        }
        else
        {
            maxGold = Math.Max(currentSum,maxGold);
            return;
        }
    }
}
