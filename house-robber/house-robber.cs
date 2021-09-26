public class Solution {
    Dictionary<int,int> dp;
    public int Rob(int[] nums) 
    {
        dp = new Dictionary<int,int>();
        return Recurse(nums,0);
    }
    private int Recurse(int[] nums, int index)
    {
        if(index >= nums.Length) return 0;
        
        if(!dp.ContainsKey(index))
        {
            int choice1 = nums[index] + Recurse(nums,index + 2);
        
            int choice2 = Recurse(nums,index + 1);
            
            dp.Add(index,Math.Max(choice1,choice2));
        }       
        return dp[index];         
    }
}