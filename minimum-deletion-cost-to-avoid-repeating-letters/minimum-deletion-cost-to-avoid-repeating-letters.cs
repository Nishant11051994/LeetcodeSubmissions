public class Solution {
    public int MinCost(string s, int[] cost)
    {
        if(string.IsNullOrEmpty(s) || cost == null || cost.Length == 0) return 0;
        
        int max = cost[0];
        int result = 0;
        for(int i = 0 ; i < s.Length-1 ; i++)
        {
            if(s[i] == s[i+1])
            {
                result += Math.Min(max,cost[i+1]);
                max = Math.Max(max,cost[i+1]);
            }
            else
                max = cost[i+1];
        }
        
        return result;        
    }
}