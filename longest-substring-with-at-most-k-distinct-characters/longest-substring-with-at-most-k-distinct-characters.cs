public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        Dictionary<char,int> map = new Dictionary<char,int>();
        int maxLength = 0;
        int start = 0;
        for(int end = 0; end < s.Length ; end++)
        {
            if(!map.ContainsKey(s[end]))
            {
                map.Add(s[end],0);
                k--;
            }
            map[s[end]]++;
            while(k < 0)
            {
                map[s[start]]--;
                if(map[s[start]] == 0)
                {
                    map.Remove(s[start]);
                    k++;
                }
                start++;
            }
            maxLength = Math.Max(maxLength,end-start+1);
        }
        
        return maxLength;
    }
}