public enum State
{
    UNKNOWN,
    GOOD,
    BAD
}
​
public class Solution {
    public bool CanPartition(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return false; 
        
        int sum = nums.Sum();
        
        if(sum % 2 != 0) return false;
        
        bool[,] dp = new bool[nums.Length,(sum/2)+1];
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
           dp[i,0] = true;
        }
        
        for(int i = 1 ; i < (sum/2+1) ; i++)
        {
           if(nums[0] == i)
           {
              dp[0,i] = true;
           }
        }
        
        for(int i = 1 ; i < nums.Length ; i++)
        {
          for(int s = 1 ; s <= sum/2 ; s++)
          {
              if(dp[i-1,s])
              {
                 dp[i,s] = dp[i-1,s];
              }
              else if(s >= nums[i])
              {
                 dp[i,s] = dp[i-1,s-nums[i]];
              }
          }
          
        }
​
        return dp[nums.Length-1,sum/2];
    }
}
