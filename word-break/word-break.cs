public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        int[] dp = new int[s.Length];
        for(int i = 0 ;  i < dp.Length ; i++)
        {
            dp[i] = -1;
        }
        return Recurse(s,new HashSet<string>(wordDict),0,dp);
    }
    private bool Recurse(string s,HashSet<string> wordDic,int start,int[] dp)
    {
       if(start == s.Length) return true;
        
       if(dp[start] != -1) return dp[start] == 1 ? true : false;
        
       for(int end = start + 1 ; end <= s.Length ; end++)
       {
           if(wordDic.Contains(s.Substring(start,end-start))
             && Recurse(s,wordDic,end,dp))
           {
               dp[start] = 1;
               return true;
           }
       }
       dp[start] = 0;
       return false; 
    }
}