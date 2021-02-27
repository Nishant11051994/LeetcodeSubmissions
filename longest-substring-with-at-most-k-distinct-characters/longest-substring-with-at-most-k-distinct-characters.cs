public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        Dictionary<char,int> freqMap = new Dictionary<char,int>();
        
        int start = 0;
        int end = 0;
        int maxLength = 0;
        
        while(end < s.Length)
        {
            if(!freqMap.ContainsKey(s[end]))
            {
                freqMap.Add(s[end],0);
            }
            freqMap[s[end]]++;           
            
            if(freqMap.Count > k)
            {               
               freqMap[s[start]]--;
               if(freqMap[s[start]] == 0)
               {
                   freqMap.Remove(s[start]);
               }
               start++;
            }
            maxLength = Math.Max(maxLength,end-start+1);
            end++;
        }
        return maxLength;
    }
}