public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        int end = 0;
        
        int start = 0;
        
        Dictionary<char,int> dict = new Dictionary<char,int>();
        
        int maxLength = 0;
        
        while(end < s.Length)
        {
            while(dict.ContainsKey(s[end]))
            {            
                dict.Remove(s[start]);
                start++;
            }
                       
            if(!dict.ContainsKey(s[end]))
            {
                dict.Add(s[end],1);
            }            
           
            maxLength = Math.Max(maxLength,end-start+1);
            end++;
        }
        
        return maxLength;
    }
}