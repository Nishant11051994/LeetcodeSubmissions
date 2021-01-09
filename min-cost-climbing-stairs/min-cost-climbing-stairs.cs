public class Solution {
    public int MinCostClimbingStairs(int[] cost) 
    {
        if(cost == null) return 0;
        int[] dp = new int[cost.Length];
        return Math.Min(Recurse(cost,0,dp),Recurse(cost,1,dp));
    }
    private int Recurse(int[] cost,int curr,int[] dp)
    {
        if(curr >= cost.Length)
        {
            return 0;
        }
        if(dp[curr] != 0) return dp[curr];
        int costOfOneStep = cost[curr] + Recurse(cost,curr+1,dp);
        int costOfTwoStep = cost[curr] + Recurse(cost,curr+2,dp);
        dp[curr] = Math.Min(costOfOneStep,costOfTwoStep);  
        return  dp[curr];     
    }
}
