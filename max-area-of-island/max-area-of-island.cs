public class Solution {
    int maxArea = 0;
    public int MaxAreaOfIsland(int[][] grid) 
    {
      if(grid == null || grid.Length == 0) return 0;  
      for(int i = 0 ; i < grid.Length ; i++)
      {
          for(int j = 0 ; j < grid[i].Length ; j++)
          {
              if(grid[i][j] == 1)
              {
                  int area = 0;
                  DFS(grid,i,j,ref area);
              }
          }
      }
      return maxArea;
    }
    private bool IsSafe(int[][] grid,int x,int y)
    {
        if(x >=0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == 1)
        {
            return true;
        }
        return false;
    }
    private void DFS(int[][] grid,int x,int y,ref int area)
    {
        if(IsSafe(grid,x,y))
        {
            grid[x][y] = 0;
            //Console.WriteLine($"x : {x}, y : {y}, areaBefore is {area}");
            area++;
            Console.WriteLine($"x : {x}, y : {y}, areaAfter is {area}");
            maxArea = Math.Max(maxArea,area);
            DFS(grid,x+1,y,ref area);
            DFS(grid,x,y+1,ref area);
            DFS(grid,x,y-1,ref area);
            DFS(grid,x-1,y,ref area);
        }
        else
        {
            return;
        }
    }
}
​
