public class Solution {
    public IList<int> FindAnagrams(string s, string p) 
    {
        int ns = s.Length;
        int np = p.Length;
        
        Dictionary<char,int> pCount = new Dictionary<char,int>();
        Dictionary<char,int> sCount = new Dictionary<char,int>();
        
        foreach(char c in p)
        {
            if(!pCount.ContainsKey(c))
            {
                pCount.Add(c,0);
            }
            pCount[c]++;
        }
        
        pCount = pCount.OrderBy(x => x.Key).ToDictionary(x => x.Key,x => x.Value);
        
        List<int> result = new List<int>();
        
        // sliding window on the string s
        for(int i = 0 ; i < ns ; i++)
        {
            // Adding right
            if(!sCount.ContainsKey(s[i]))
            {
               sCount.Add(s[i],0); 
            }
            sCount[s[i]]++;
            
            //Removing Left
            if(i >= np)
            {
                char ch = s[i-np];
                sCount[ch]--;
                if(sCount[ch] == 0)
                {
                    sCount.Remove(ch);
                }
            }
            sCount = sCount.OrderBy(x => x.Key).ToDictionary(x => x.Key,x => x.Value);
            // Comparing the maps
            if(sCount.SequenceEqual(pCount))
            {
                result.Add(i-np+1);
            }
        }
        
        return result;
    }
}