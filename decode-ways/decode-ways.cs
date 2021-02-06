public class Solution {
    public int NumDecodings(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        int[] dp = new int[s.Length];
        return Recurse(s,0,dp);
        
    }
    private int Recurse(string s,int index,int[] dp)
    {
        if(index == s.Length)
        {
            return 1;
        } 
        if(dp[index]!=0) return dp[index];
        if(s[index] == '0')
        {
            return 0;
        }        
        int firstWay = Recurse(s,index+1,dp);
        int secondWay = 0;
        if(index+2 <= s.Length && Convert.ToInt32(s.Substring(index,2)) <= 26)
        {
            secondWay = Recurse(s,index+2,dp); 
        }       
        dp[index] = firstWay + secondWay;      
        return dp[index];
    }
}