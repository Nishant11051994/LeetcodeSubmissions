public class Solution {
    public bool IsOneEditDistance(string s, string t) 
    {
        if(string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return false;
        
        int lengthS = s.Length;
        int lengthT = t.Length;
        
        if(Math.Abs(lengthS - lengthT) > 1)
        {
            return false;
        }
        
        int i = 0,j = 0;
        int count = 0;
        while(i < s.Length && j < t.Length)
        {
            if(s[i] != t[j])
            {
                if(++count > 1) return false;
                
                if(lengthS < lengthT)
                {
                    j++;
                    continue;
                }
                if(lengthS > lengthT)
                {
                    i++;
                    continue;
                }
            }
            i++;
            j++;
        }
        if(count == 0 && (i < lengthS || j < lengthT)) return true;
        return count == 1;
    }
}