public class Solution {
    public int MinPairSum(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        Array.Sort(nums);
        
        int maxSum = 0;
        
        int i = 0;
        int j = nums.Length-1;
        
        while(i < j)
        {
            int sum = nums[i++] + nums[j--];
            maxSum = Math.Max(sum,maxSum);
        }
        
        return maxSum;
    }
}