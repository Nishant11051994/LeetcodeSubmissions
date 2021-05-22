public class Solution {
    public int MinDeletions(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        int[] freq = new int[26];
        
        for(int i = 0 ; i < s.Length ; i++)
        {
            freq[s[i] - 'a']++;
        }
        
        HashSet<int> freqSet = new HashSet<int>();
        
        int minDeletions = 0;
        
        for(int i = 0 ; i < 26 ; i++)
        {
            while(freqSet.Contains(freq[i]) && freq[i] > 0)
            {
                freq[i]--;
                minDeletions++;
            }
            freqSet.Add(freq[i]);
        }
        
        return minDeletions;
    }
}