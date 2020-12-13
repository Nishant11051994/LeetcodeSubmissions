public class Solution {
    public int Change(int amount, int[] coins) 
    {        
        int[,] dp = new int[coins.Length,amount+1];
        for(int i = 0 ; i < dp.GetLength(0) ; i++)
        {
            for(int j = 0 ; j < dp.GetLength(1) ; j++)
            {
                dp[i,j] = -1;
            }
        }
        
        return BackTrack(amount,coins,0,dp);
    }
    private int BackTrack(int amount,int[] coins,int currIndex,int[,] dp)
    {
        if(amount == 0) return 1;
        
        if(currIndex >= coins.Length) return 0;
        
        if(dp[currIndex,amount] != -1) return dp[currIndex,amount];
        
        int count1 = 0;
        if(coins[currIndex] <= amount)
        {
            count1 = BackTrack(amount-coins[currIndex],coins,currIndex,dp);
        }
        int count2 = BackTrack(amount,coins,currIndex+1,dp);
        dp[currIndex,amount] =  count1 + count2;
        return dp[currIndex,amount];
    }
}
