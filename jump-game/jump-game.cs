public enum State
{
   GOOD,
   BAD,
   UNKNOWN
}
public class Solution {
    public bool CanJump(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return true;
        
        State[] dp = new State[nums.Length];
        for(int i=0;i<nums.Length;i++)
        {
          dp[i] = State.UNKNOWN;
        }
        dp[nums.Length-1] = State.GOOD;        
        return Jump(nums,0,dp);        
    }
    private bool Jump(int[] nums,int currIndex,State[] dp)
    {
        if(dp[currIndex] != State.UNKNOWN)
        {
           return dp[currIndex] == State.GOOD ? true : false;
        }
        int currentMaxJump = currIndex + nums[currIndex];
        int maxJump = Math.Min(currentMaxJump,nums.Length-1);
        for(int i = currIndex+1 ; i <= maxJump ; i++)
        {
            if(Jump(nums,i,dp))
            {
                dp[currIndex] = State.GOOD;
                return true;                
            }
        }
        dp[currIndex] = State.BAD;
        return false;
    }
}
