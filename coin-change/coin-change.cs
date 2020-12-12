public class Solution {
    public int CoinChange(int[] coins, int amount) 
    {
        if(coins == null || coins.Length == 0 || amount == 0) return 0;
        
        int[,] dp = new int[coins.Length,amount+1];
        
        int result = BackTrack(coins,amount,0,dp);
              
        return result == Int32.MaxValue ? -1 : result;
    }
    private int BackTrack(int[] coins,int amount,int currIndex,int[,] dp)
    {
        if(amount == 0)
        {
            return 0;
        }
        if(currIndex >= coins.Length)
        {
            return Int32.MaxValue;
        }
        
        if(dp[currIndex,amount] != 0)
        {
            return dp[currIndex,amount];
        }
        
        int count1 = Int32.MaxValue;
        if(coins[currIndex] <= amount)
        {
            int res = BackTrack(coins,amount-coins[currIndex],currIndex,dp);
            if(res != Int32.MaxValue)
            {
                count1 = res + 1;
            }
        }
        int count2 = BackTrack(coins,amount,currIndex+1,dp);
        dp[currIndex,amount] = Math.Min(count1,count2);
        return dp[currIndex,amount];
    }
    
}
