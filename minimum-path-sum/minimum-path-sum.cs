public class Solution {
    public int MinPathSum(int[][] grid) 
    {
        if(grid == null || grid.Length == 0) return 0; 
        int[,] dp = new int[grid.Length,grid[0].Length];
        return MinSum(grid,0,0,dp);
    }
    private int MinSum(int[][] grid,int x,int y,int[,] dp)
    {
        if(x == grid.Length || y == grid[0].Length)
        {
            return Int32.MaxValue;
        }
        if(x == grid.Length-1 && y == grid[0].Length-1) return grid[x][y];
        
        if(dp[x,y] != 0) return dp[x,y];
        
        dp[x,y] =  grid[x][y] + Math.Min(MinSum(grid,x+1,y,dp),MinSum(grid,x,y+1,dp));    
        return dp[x,y];
    }
}
