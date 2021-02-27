public class Solution {
    public string MinWindow(string s, string t) 
    {
       if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return string.Empty;
        
       Dictionary<char,int> freqMap = new Dictionary<char,int>();
    
       for(int i = 0 ; i < t.Length ; i++)
       {
           if(!freqMap.ContainsKey(t[i]))
           {
               freqMap.Add(t[i],0);
           }
           freqMap[t[i]]++;
       }
        
        
       int counter = freqMap.Count;
        
       int start = 0;
       int end = 0;        
       int minLength = Int32.MaxValue;
       int finalStart = 0;
        
       while(end < s.Length)
       {
           if(freqMap.ContainsKey(s[end]))
           {
               freqMap[s[end]]--;
               if(freqMap[s[end]] == 0)
               {
                   counter--;
               }
           }
           end++;
           while(counter == 0)
           {
               if(end - start < minLength)
               {
                   minLength = end - start;
                   finalStart = start;                   
               }               
               if(freqMap.ContainsKey(s[start]))
               {
                   freqMap[s[start]]++;
                   if(freqMap[s[start]] > 0)
                   {
                       counter++;
                   }
               }
               start++;
           }           
       }        
       return minLength == Int32.MaxValue ? "" : s.Substring(finalStart,minLength);
       
       
    }
}