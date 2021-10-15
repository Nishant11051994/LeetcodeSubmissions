public class Solution {
    public string MinWindow(string s, string t) 
    {
        if(string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return string.Empty;
        
        if(t.Length > s.Length) return string.Empty;
        
        Dictionary<char,int> tMap = new Dictionary<char,int>();
        
        for(int i = 0 ; i < t.Length ; i++)
        {
               if(!tMap.ContainsKey(t[i]))
               {
                  tMap.Add(t[i],0); 
               }
               tMap[t[i]]++;
        }
        
        int size = tMap.Count;
        
        int start = 0;
        int startIndex = 0;
        int minLength = Int32.MaxValue;
                  
        for(int end= 0 ; end < s.Length ; end++)
        {
            // Reduce the size to check the existenc of substring with all characters
            if(tMap.ContainsKey(s[end]))
            {
                tMap[s[end]]--;
                if(tMap[s[end]] == 0)
                {
                    size--;
                }
            }
            // Contracting the window to minimize till allowable limit
            while(size == 0)
            {
                if(end-start+1 < minLength)
                {
                    minLength = end-start+1;
                    startIndex = start;
                }
                if(tMap.ContainsKey(s[start]))
                {
                    tMap[s[start]]++;
                    if(tMap[s[start]] > 0)
                    {
                        size++;
                    }                   
                }
                start++;
            }
        }
        return minLength == Int32.MaxValue ? "" : s.Substring(startIndex,minLength);
    }
}