public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        Dictionary<char,int> dict = new Dictionary<char,int>();
        
        int start = 0;
        
        int maxLength = 0;
        
        for(int end = 0 ; end < s.Length ; end++)
        {                     
            if(!dict.ContainsKey(s[end]))
            {
                dict.Add(s[end],0);
            } 
            dict[s[end]]++; 
            while(dict.Count > k)
            {
               dict[s[start]]--;
               if(dict[s[start]] == 0)
               {
                  dict.Remove(s[start]);
               }
               start++;
            }    
            maxLength = Math.Max(maxLength,end-start+1);
        }
        
        return maxLength;
    }
}