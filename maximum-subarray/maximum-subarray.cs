public class Solution {
    public int MaxSubArray(int[] nums) 
    {
       if(nums == null || nums.Length == 0) return 0;
       
        
       int currSum = nums[0];
       int maxSum = nums[0];
        
       for(int i = 1 ; i < nums.Length ; i++)
       {
           currSum = Math.Max(nums[i],currSum + nums[i]);
           maxSum = Math.Max(currSum,maxSum);
       }       
        
       return maxSum;
    }
   
}