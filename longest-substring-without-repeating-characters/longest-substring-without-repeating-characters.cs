public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        Dictionary<char,int> map = new Dictionary<char,int>();
        
        int start = 0;
        int end = 0;
        int maxLength = 0;
        
        while(end < s.Length)
        {
           if(map.ContainsKey(s[end]))
           {
               start = Math.Max(start,map[s[end]] + 1);
           }
           map[s[end]] = end;
           maxLength = Math.Max(maxLength,end-start+1);
           end++;
        }
        
        return maxLength;
    }
}
