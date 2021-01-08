public class WordDistance {
​
    string[] words;
    Dictionary<string,List<int>> map;
    public WordDistance(string[] words) 
    {
        this.words = words;
        map = new Dictionary<string,List<int>>();
        for(int i = 0 ; i < words.Length ; i++)
        {
          if(!map.ContainsKey(words[i]))
          {
              map.Add(words[i],new List<int>());
          }
          map[words[i]].Add(i);
        } 
    }
    
    public int Shortest(string word1, string word2) 
    {
      if(string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2)) return 0;    
      int p = 0;
      int q = 0;
      int minDiff = Int32.MaxValue;
      List<int> list1 = map[word1];
      List<int> list2 = map[word2];
      while(p < list1.Count && q < list2.Count)
      {
          minDiff = Math.Min(minDiff,Math.Abs(list1[p] - list2[q]));
          if(minDiff == 1) break;
          if(list1[p] > list2[q])
          {
              q++;
          }
          else
          {
              p++;
          }
      }        
      return minDiff;    
    }
}
​
/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(words);
 * int param_1 = obj.Shortest(word1,word2);
 */
