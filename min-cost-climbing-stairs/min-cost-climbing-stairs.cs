public class Solution {
    Dictionary<int,int> dp;
    public int MinCostClimbingStairs(int[] cost) 
    {
        dp = new Dictionary<int,int>();
        return Math.Min(Recurse(cost,0),Recurse(cost,1));
    }
    private int Recurse(int[] cost,int index)
    {
        if(index > cost.Length-1) return 0;
        
        if(!dp.ContainsKey(index))
        {
            if(index == cost.Length-1)
            {
                dp.Add(index,cost[index]);
            }
            else
            {
                int choice1 = Recurse(cost,index+1);
        
                int choice2 = Recurse(cost,index+2);
        
                dp.Add(index,cost[index] + Math.Min(choice1,choice2));
            }    
        }            
        return dp[index];
    }
}