public class Solution {
    public int Rob(int[] nums) 
    {
        int[] dp = new int[nums.Length];
        // Initilising dp array with -1 as the nums value may contain 0 amount of money
        for(int i = 0 ; i < nums.Length ; i++)
        {
            dp[i] = -1;
        }      
        if(nums.Length == 1 && nums[0] != 0) return nums[0];
            
        int a = Recurse(nums,0,nums.Length-1,dp);
        for(int i = 0 ; i < nums.Length ; i++)
        {
            dp[i] = -1;
        }       
        int b = Recurse(nums,1,nums.Length,dp);
        return Math.Max(a,b);
    }
    private int Recurse(int[] nums,int index,int end,int[] dp)
    {
        if(index >= end) return 0;
        
        if(dp[index] != -1) return dp[index];
        
        return dp[index] = Math.Max(nums[index] + Recurse(nums,index+2,end,dp),Recurse(nums,index+1,end,dp));
    }
}