public class Solution {
    public bool IsSubsequence(string s, string t) 
    {
        if(string.IsNullOrEmpty(s)) return true;
        
        return Recurse(s,t,0,0);
    }
    private bool Recurse(string s,string t,int indexS,int indexT)
    {        
        if(s.Length == indexS)
        {
           return true;
        }
        if(indexT > t.Length-1) return false;
               
        if(s[indexS] == t[indexT])
        {
            indexS++;
        }        
        return Recurse(s,t,indexS,indexT+1);  
    }
}
