public class Solution {
    public int NumMatchingSubseq(string S, string[] words) 
    {
        if(string.IsNullOrEmpty(S)) return 0;
        
        int count = 0;
        Dictionary<string,bool> map = new Dictionary<string,bool>();
        
        for(int i = 0 ; i < words.Length ; i++)
        {
            bool result = map.ContainsKey(words[i]) ? map[words[i]] : IsSubsequence(words[i],S);
            if(result)
               {
                   count++;
               }
            map[words[i]] = result;
        }        
        return count;
    }
    private  bool IsSubsequence(string s, string t) 
    {
        if(string.IsNullOrEmpty(s)) return true;
        
        int sIndex = 0;
        int tIndex = 0;
        
        int count = s.Length;
        while((tIndex < t.Length && sIndex < s.Length) && count!=0)
        {
            if(s[sIndex] == t[tIndex])
            {
                sIndex++;
                count--;
            }
            tIndex++;
        }
        return count == 0 ? true : false;
    }
}
