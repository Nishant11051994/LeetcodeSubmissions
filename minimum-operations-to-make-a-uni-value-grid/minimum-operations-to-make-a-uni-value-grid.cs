public class Solution {
    public int MinOperations(int[][] grid, int x) 
    {
        if(grid == null || grid.Length == 0) return 0;
        
        int index = 0;
        
        int[] arr = new int[grid.Length * grid[0].Length];
        
        for(int i = 0 ; i < grid.Length ; i++)
        {
            for(int j = 0 ; j < grid[0].Length ; j++)
            {
                arr[index++] = grid[i][j];
            }
        }
        
        Array.Sort(arr);
        
        int middle = (arr.Length)/2;
        
        int ops = 0;
        
        for(int i = 0 ; i < arr.Length ; i++)
        {
            int diff = Math.Abs(arr[i] - arr[middle]);
            
            if(diff % x != 0)
            {
                return -1;
            }
            
            ops += diff/x;
        }
        
        return ops;
        
    }
}