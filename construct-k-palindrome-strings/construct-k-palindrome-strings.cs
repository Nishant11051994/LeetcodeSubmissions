public class Solution {
    public bool CanConstruct(string s, int k) 
    {
       if(string.IsNullOrEmpty(s) && k == 0) return true;
        
       if(string.IsNullOrEmpty(s) || k == 0) return false;
        
       if(k > s.Length) return false;
        
       Dictionary<char,int> map = new Dictionary<char,int>();
        
       for(int i = 0 ; i < s.Length ; i++)
       {
           if(!map.ContainsKey(s[i]))
           {
               map.Add(s[i],0);
           }
           map[s[i]]++;
       }
       int oddCount = 0;
       foreach(var item in map)
       {
           if(item.Value % 2 == 1)
           {
               oddCount++;
           }
       }  
       Console.WriteLine(oddCount);
       return oddCount <= k;
    }
}
