public class Solution {
    public int NumberOfSubstrings(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        int count = 0;
        
        int ans = 0;
        
        int n = s.Length;
        Dictionary<char,int> freqMap = new Dictionary<char,int>();
        freqMap.Add('a',0);
        freqMap.Add('b',0);
        freqMap.Add('c',0);
        
        int start = 0;
        int end = 0;
        while(end < n)
        {
            freqMap[s[end]]++;          
            while(start < n && ContainsAllChars(freqMap))
            {
                Console.WriteLine($"start is {start}, end is {end}");
                ans++;
                freqMap[s[start]]--;
                start++;
            }  
            end++;
            count += ans;
        }
        return count;
    }
    private bool ContainsAllChars(Dictionary<char,int> freqMap)
    {
        if(freqMap['a'] >= 1 && freqMap['b'] >= 1 && freqMap['c'] >= 1) return true;
        
        return false;
    }
}