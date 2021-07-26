public class Solution {
    public int FindLengthOfLCIS(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        int maxLength = 1;
        int currLength = 1;
        int diff = -1;
        for(int i = 1 ; i < nums.Length ; i++)
        {
            if(nums[i] > nums[i-1])
            {
                diff = nums[i] - nums[i-1];
                currLength++;
            }
            else
            {
                diff = nums[i] - nums[i-1];
                currLength = 1;                
            }
            maxLength = Math.Max(currLength,maxLength);
        }
        return maxLength;
    }
}