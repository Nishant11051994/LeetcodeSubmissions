public class Solution {
    public int ShortestDistance(string[] wordsDict, string word1, string word2) 
    {
       Dictionary<string,List<int>> map = new Dictionary<string,List<int>>();
        
       map.Add(word1,new List<int>());
       map.Add(word2,new List<int>());
        
       for(int i = 0 ; i < wordsDict.Length ; i++)
       {
           if(map.ContainsKey(wordsDict[i]))
           {
               map[wordsDict[i]].Add(i);
           }
       }
       int minDist = Int32.MaxValue; 
       foreach( int i in map[word1])
       {
           foreach(int j in map[word2])
           {
               minDist = Math.Min(minDist,Math.Abs(i-j));
           }
       }
       return minDist;
    }
}