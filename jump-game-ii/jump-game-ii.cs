public class Solution {
    public int Jump(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;        
           
        int[] maxJumps = new int[nums.Length];
        
        Array.Fill(maxJumps,Int32.MaxValue-1);
        
        maxJumps[nums.Length-1] = 0;
        
        for(int i = nums.Length-2 ; i>=0 ; i--)
        {
            int farthestJump = Math.Min(i + nums[i],nums.Length-1);
            if(farthestJump == nums.Length-1)
            {
              maxJumps[i] = 1;
              continue;
            }
            for(int j = i+1 ; j <= farthestJump ; j++)
            {
              maxJumps[i] = Math.Min(maxJumps[j] + 1,maxJumps[i]);
            }   
        }
        return maxJumps[0];
    }
}
