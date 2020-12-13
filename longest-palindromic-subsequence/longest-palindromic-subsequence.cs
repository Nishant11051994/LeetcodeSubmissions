public class Solution {
    public int LongestPalindromeSubseq(string s) 
    {
      if(string.IsNullOrEmpty(s)) return 0;
      
      int[,] dp = new int[s.Length,s.Length];
        
      return BackTrack(s,0,s.Length-1,dp);
    }
    private int BackTrack(string s, int startIndex,int endIndex,int[,] dp)
    {
        if(startIndex > endIndex)
        {
            return 0;
        }
        if(startIndex == endIndex)
        {
            return 1;
        }
        
        if(dp[startIndex,endIndex] != 0) return dp[startIndex,endIndex];
        
        if(s[startIndex] == s[endIndex])
        {
            dp[startIndex,endIndex] =  2 + BackTrack(s,startIndex+1,endIndex-1,dp);
            return dp[startIndex,endIndex];
        }
        int c1 = BackTrack(s,startIndex+1,endIndex,dp);
        int c2 = BackTrack(s,startIndex,endIndex-1,dp);
        dp[startIndex,endIndex] = Math.Max(c1,c2);
        return dp[startIndex,endIndex];
    }
}
