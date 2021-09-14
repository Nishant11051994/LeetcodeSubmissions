public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) 
    {
        IList<IList<string>> result = new List<IList<string>>();
        
        if(paths == null || paths.Length == 0) return result;
        
        Dictionary<string,IList<string>> map = new Dictionary<string,IList<string>>();
        
        foreach(string s in paths)
        {
            string[] parts = s.Split(' ');
            
            string currDirectory = parts[0];
            
            for(int i = 1 ; i < parts.Length ; i++)
            {
               int indexOfOpenBrace = parts[i].IndexOf('(');
               string fileName = parts[i].Substring(0,indexOfOpenBrace);
               string content = parts[i].Substring(indexOfOpenBrace+1,parts[i].Length-indexOfOpenBrace-1);
             
               if(!map.ContainsKey(content))
               {
                   map.Add(content,new List<string>());
               }
               map[content].Add(currDirectory + "/" + fileName);                
            }            
        }
        
        map = map.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key,x => x.Value);
        
        return map.Values.ToList();
    }
}