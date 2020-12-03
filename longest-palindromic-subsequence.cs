public class Solution {
    public int LongestPalindromeSubseq(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        int[,] memo = new int[s.Length,s.Length];
        
        return BackTrack(s,0,s.Length-1,memo);
    }
    private int BackTrack(string s, int startIndex,int endIndex,int[,] memo)
    {
        if(startIndex > endIndex)
        {
            return 0;
        }
        if(startIndex == endIndex)
        {
            return 1;
        }
        
        if(memo[startIndex,endIndex]!=0)
        {
            return memo[startIndex,endIndex];
        }       
        if(s[startIndex] == s[endIndex])
        {
            return 2 + BackTrack(s,startIndex+1,endIndex-1,memo);
        }
        int c1 = BackTrack(s,startIndex+1,endIndex,memo);
        int c2 = BackTrack(s,startIndex,endIndex-1,memo);
        memo[startIndex,endIndex] = Math.Max(c1,c2);
        return Math.Max(c1,c2);
    }
}
