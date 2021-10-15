public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        HashSet<int> set = new HashSet<int>();
        
        int start = 0;
        int maxLength = 0;
        
        for(int end = 0 ; end < s.Length ; end++)
        {
            if(set.Contains(s[end]))
            {
                 while(set.Contains(s[end]))
                {
                    set.Remove(s[start]);
                    start++;
                }
            }
            set.Add(s[end]);
            maxLength = Math.Max(maxLength,end-start+1);
        }
        
        return maxLength;
    }
}