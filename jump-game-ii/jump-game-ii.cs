public class Solution {
    Dictionary<int,int> dp;
    public int Jump(int[] nums) 
    {
        dp = new Dictionary<int,int>();
        return BackTrack(nums,0);
    }
    private int BackTrack(int[] nums,int index)
    {
        if(index >= nums.Length-1) return 0;
        
        if(dp.ContainsKey(index)) return dp[index];
        
        int minJumps = Int32.MaxValue;
        
        for(int i = index+1 ; i <= Math.Min(index+nums[index],nums.Length-1) ; i++)
        {
            minJumps = Math.Min(minJumps,BackTrack(nums,i));
        }      
        dp[index] = minJumps == Int32.MaxValue ? Int32.MaxValue : minJumps+1;
        return dp[index];
    }
}