public class Solution {
    public int ClimbStairs(int n) 
    {
       int[] dp = new int[n+1]; 
       return Recurse(n,dp);
    }
    private int Recurse(int n,int[] dp)
    {
        if(n == 0) return 1;
        
        if(n == 1) return 1;
        
        if(dp[n]!=0) return dp[n];
        
        int step1 = Recurse(n-1,dp);
        int step2 = Recurse(n-2,dp);
        dp[n] = step1 + step2;
        return dp[n];
    }
}
