public class Solution {    
    public int Rob(int[] nums) 
    {
        Dictionary<int,int> dp1 = new Dictionary<int,int>();
        Dictionary<int,int> dp2 = new Dictionary<int,int>();
        
        if(nums.Length == 1) return nums[0];
        
        return Math.Max(Recurse(nums,0,nums.Length-1,dp1),Recurse(nums,1,nums.Length,dp2));
    }
    private int Recurse(int[] nums, int index,int last,Dictionary<int,int> dp)
    {
        if(index >= last) return 0;
        
        if(!dp.ContainsKey(index))
        {
            int choice1 = nums[index] + Recurse(nums,index + 2,last,dp);
        
            int choice2 = Recurse(nums,index + 1,last,dp);
            
            dp.Add(index,Math.Max(choice1,choice2));
        }       
        return dp[index];         
    }
}