public class Solution {
    Dictionary<int,int> dp;
    public int ClimbStairs(int n) 
    {
        dp = new Dictionary<int,int>();
        dp.Add(0,0);
        dp.Add(1,1);
        dp.Add(2,2);
        return Recurse(n);
    }
    private int Recurse(int n)
    {
        if(!dp.ContainsKey(n))
        {
            int oneStepAtATime = Recurse(n-1);
        
            int twoStepAtATime = Recurse(n-2);
            
            dp.Add(n,oneStepAtATime+twoStepAtATime);
        }        
        return dp[n];
    }
}