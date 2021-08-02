public class Solution {
    public int CountNegatives(int[][] grid) 
    {
        if(grid == null) return 0;
        
        int result = 0;
        
        int colLength = grid[0].Length;
        
        for(int i = 0 ; i < grid.Length ; i++)
        {
            if(LeftMostIndex(grid[i]) != -1)
            result += colLength - LeftMostIndex(grid[i]);
        }
        return result;
    }
    private int LeftMostIndex(int[] grid)
    {
        int left = 0;
        int right = grid.Length-1;
        int leftMostNegativeIndex = -1;
        
        while(left <= right)
        {
            int mid = left + (right-left)/2;
            if(grid[mid] < 0)
            {
                right = mid - 1;
                leftMostNegativeIndex = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return leftMostNegativeIndex;
    }
}