public class Solution {
    public int NumRollsToTarget(int d, int f, int target) 
    {
        int[,] dp = new int[d+1,target+1];
        for(int i = 0 ; i < dp.GetLength(0) ; i++)
        {
            for(int j = 0 ; j < dp.GetLength(1) ; j++)
            {
                dp[i,j] = -1;
            }
        }
        return Recurse(d,f,target,dp) % 1000000007;
    }
    private int Recurse(int d,int f,int target,int[,] dp)
    {
        if(d == 0)
        {
            dp[d,target] = target == 0 ? 1 : 0;
            return target == 0 ? 1 : 0;
        }
        if(dp[d,target]!=-1) return dp[d,target];
        int count = 0;
        for(int i = 1 ; i <= f ; i++)
        {
            if(target >= i)
            count = (count + (Recurse(d-1,f,target-i,dp)) % (int)1000000007)%1000000007;
        }
        dp[d,target] = count;
        return count;
    }
}
