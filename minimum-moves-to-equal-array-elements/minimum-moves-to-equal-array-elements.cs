public class Solution {
    public int MinMoves(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        int moves = 0;
        int min = nums.Min();
        for(int i = 0 ; i < nums.Length ; i++)
        {
            moves += nums[i] - min;
        }
          
        return moves;
    }
}
