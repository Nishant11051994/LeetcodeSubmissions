public class Solution {
    public bool IsSubsequence(string s, string t) 
    {                
        if(string.IsNullOrEmpty(s)) return true;
        
        if(string.IsNullOrEmpty(t)) return false;
        
        int i = 0;
        int j = 0;
        
        while(i < s.Length && j < t.Length)
        {
            if(s[i] == t[j])
            {
                i++;
            }
            j++;
        }
        
        return i == s.Length;
        
        
    }
}