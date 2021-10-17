public class Solution {
    public string[] GetFolderNames(string[] names) 
    {
        string[] result = new string[names.Length];
        
        if(names == null || names.Length == 0) return result;
        
        Dictionary<string,int> suffixMap = new Dictionary<string,int>();
                
        for(int i = 0 ;  i < names.Length ; i++)
        {   
           if(suffixMap.ContainsKey(names[i]))
           {
               int newIndex = ++suffixMap[names[i]];
               string temp = names[i] + "(" + newIndex + ")";  
               while(suffixMap.ContainsKey(temp))
               {
                   newIndex = newIndex + 1;
                   temp = names[i] + "(" + newIndex + ")"; 
               }
               suffixMap.Add(temp,0);
               suffixMap[names[i]] = newIndex;
           }
           else
           {
               suffixMap.Add(names[i],0);
           }
        }
        
        return suffixMap.Keys.ToArray();
    }
}