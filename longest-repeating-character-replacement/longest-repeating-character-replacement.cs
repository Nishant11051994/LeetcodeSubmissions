//https://leetcode.com/problems/longest-repeating-character-replacement/discuss/487300/C-Sliding-Window-Solution
public class Solution {
    public int CharacterReplacement(string s, int k) 
    {
        if(string.IsNullOrEmpty(s))
        {
            return 0;
        }
        int[] count = new int[26];
        
        int maxLength = 0;
        
        int maxCount = 0;
        
        int start = 0;
        
        for(int end = 0 ; end < s.Length ; end++)
        {
            count[s[end]-'A']++;
            
            maxCount = Math.Max(maxCount,count[s[end]-'A']);
            
            while(end-start+1-maxCount > k)
            {
                count[s[start] - 'A']--;
                start++;
            }
            
            maxLength = Math.Max(maxLength,end-start+1);
            
        }
        
        return maxLength;
    }
}