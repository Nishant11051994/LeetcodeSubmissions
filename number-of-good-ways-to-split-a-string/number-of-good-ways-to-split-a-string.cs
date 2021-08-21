public class Solution {
    public int NumSplits(string s) 
    {
        if(string.IsNullOrEmpty(s)) return 0;
        
        char s1 = s[0];
        string s2 = s.Substring(1);
        
        Dictionary<char,int> map1 = new Dictionary<char,int>();
        Dictionary<char,int> map2 = new Dictionary<char,int>();
        
        map1.Add(s1,1);
        
        for(int i = 0 ; i < s2.Length ; i++)
        {
            if(!map2.ContainsKey(s2[i]))
            {
                map2.Add(s2[i],0);
            }
            map2[s2[i]]++;
        }
        
        int goodWays = 0;
        
        if(map1.Count == map2.Count) goodWays++;
        
        for(int i = 1 ; i < s.Length ; i++)
        {
            // Adding to first string
            if(!map1.ContainsKey(s[i]))
            {
                map1.Add(s[i],0);
            }
            map1[s[i]]++;
            
            // Removing from second string
            if(map2.ContainsKey(s[i]))
            {
                map2[s[i]]--;
                if(map2[s[i]] == 0)
                {
                    map2.Remove(s[i]);
                }
            }
            
             if(map1.Count == map2.Count) goodWays++;
        }
        
        return goodWays;
    }
}