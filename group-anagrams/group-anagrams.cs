public class Solution {
    IList<IList<string>> list = new List<IList<string>>();
    
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {   
        Dictionary<string,List<string>> dict = new Dictionary<string,List<string>>();
        if(strs == null || strs.Count()==0) return list;
        for(int  i = 0 ; i  < strs.Count() ; i++)
        {
          char[] arr = strs[i].ToCharArray();
          Array.Sort(arr);
          string newStr = new string(arr);
          if(!dict.ContainsKey(newStr))
          {
              dict.Add(newStr,new List<string>());
          }
         dict[newStr].Add(strs[i]);
        } 
        list = new List<IList<string>>(dict.Values);
        return list;
    }
 }