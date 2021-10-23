public class Solution {
    Dictionary<int,bool> dp;
    public bool CanJump(int[] nums) 
    {
        dp = new Dictionary<int,bool>();
        return BackTrack(nums,0);
    }
    private bool BackTrack(int[] nums,int index)
    {
       if(index == nums.Length-1) return true;
        
       if(index >= nums.Length) return false;
        
       if(dp.ContainsKey(index))
       {
           return dp[index];
       }
        
       int i = index+1;
      
       while(i <= Math.Min(index+nums[index],nums.Length-1))
       {
           if(BackTrack(nums,i))
           {
               dp.Add(index,true);
               return dp[index];
           }
           i++;
       }   
       dp.Add(index,false); 
       return dp[index];         
    }
}