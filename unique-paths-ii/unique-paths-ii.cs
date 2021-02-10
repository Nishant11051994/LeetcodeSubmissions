public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {
        if(obstacleGrid == null || obstacleGrid.Length == 0) return 0;
        
        int[,] dp = new int[obstacleGrid.Length,obstacleGrid[0].Length];
        
        
        return obstacleGrid[0][0] == 1 ? 0 : Recurse(obstacleGrid,0,0,dp);
    }
    private int Recurse(int[][] grid,int i,int j,int[,] dp)
    {
        if(i == grid.Length-1 && j == grid[i].Length-1 && 
           grid[grid.Length-1][grid[i].Length-1] == 0)
        {
            return 1;
        }
        if(dp[i,j] != 0) return dp[i,j];
        int path1 = 0;
        int path2 = 0;
        if(i < grid.Length-1 && grid[i+1][j] != 1)
        {
            path1 = Recurse(grid,i+1,j,dp);
        }
        if(j < grid[0].Length-1 && grid[i][j+1] != 1)
        {
            path2 = Recurse(grid,i,j+1,dp);
        }
        dp[i,j] = path1 + path2;
        return dp[i,j];
    }
}