public class Solution {
    public int MaxNumberOfBalloons(string text) 
    {
        if(string.IsNullOrEmpty(text)) return 0;
        
        Dictionary<char,int> freq = new Dictionary<char,int>();
        
        string s = "balloon";
        int baloonCount = 0;
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(!freq.ContainsKey(s[i]))
            {
                freq.Add(s[i],0);
            }
        } 
        
        for(int i = 0 ; i < text.Length ; i++)
        {
            if(freq.ContainsKey(text[i]))
            freq[text[i]]++;
        } 
        
        while(true)
        {
            for(int i = 0 ; i < s.Length ; i++)
            {
                if(freq[s[i]] <= 0)
                {
                    return baloonCount;
                }
                else
                {
                    freq[s[i]]--;
                }
            }
            baloonCount++;
        }
        return baloonCount;
    }
    
    
}