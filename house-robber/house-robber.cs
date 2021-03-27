public class Solution {
    public int Rob(int[] nums) 
    {
        int[] dp = new int[nums.Length];
        for(int i = 0 ; i < nums.Length ; i++)
        {
            dp[i] = -1;
        }
        return Recurse(nums,0,dp);
    }
    private int Recurse(int[] nums, int index,int[] dp)
    {
        if(index >= nums.Length) return 0;
        
        if(dp[index] != -1) return dp[index];
        
        int choice1 = 0;
        int choice2 = 0;
        choice1 = nums[index] + Recurse(nums,index+2,dp);
        if(index < nums.Length)
        {
            choice2 = Recurse(nums,index+1,dp);
        }
        dp[index] = Math.Max(choice1,choice2);
        return dp[index];
    }
}