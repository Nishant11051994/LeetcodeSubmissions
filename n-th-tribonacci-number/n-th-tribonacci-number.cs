public class Solution {
    Dictionary<int,int> dp;
    public int Tribonacci(int n) 
    {
        dp = new Dictionary<int,int>();        
        dp.Add(0,0);
        dp.Add(1,1);
        dp.Add(2,1);       
        return Recurse(n);
    }
    private int Recurse(int n)
    {
        if(!dp.ContainsKey(n))
        {
           dp.Add(n,Recurse(n-1) + Recurse(n-2) + Recurse(n-3));
        }
        return dp[n];      
    }
}