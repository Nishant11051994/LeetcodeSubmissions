public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) 
    {
        List<string> result = new List<string>();
        
        if(string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2)) return result.ToArray();
        
        string s = s1  + " " + s2;
        string[] arr = s.Split(" ");
        
        Dictionary<string,int> freqMap = new Dictionary<string,int>();
        
        foreach(string str in arr)
        {
            if(!freqMap.ContainsKey(str))
            {
                freqMap.Add(str,0);
            }
            freqMap[str]++;
        }
        
        foreach(var item in freqMap)
        {
            if(item.Value == 1)
            {
                result.Add(item.Key);
            }
        }
        
        return result.ToArray();
    }
    
}