public class Solution {
    private Dictionary<char,List<char>> adjList = new Dictionary<char,List<char>>();
    private Dictionary<char,int> indegree = new Dictionary<char,int>();
    public string AlienOrder(string[] words) 
    {
        if(words == null || words.Length == 0) return string.Empty;
        
        foreach(string word in words)
        {
            foreach(char c in word)
            {
                if(!indegree.ContainsKey(c))
                {
                   indegree.Add(c,0); 
                   adjList.Add(c,new List<char>());
                }              
            }
        }
        
        //Find All Edges and generate a graph
        for(int i = 0 ; i < words.Length - 1 ; i++)
        {
            string word1 = words[i];
            string word2 = words[i+1];
            
            if(word1.Length > word2.Length && word1.StartsWith(word2))
            {
                return string.Empty;
            }
            
            for(int j = 0 ; j < Math.Min(word1.Length,word2.Length) ; j++)
            {
                if(word1[j] != word2[j])
                {
                    adjList[word1[j]].Add(word2[j]);
                    indegree[word2[j]] += 1;
                    break;
                }
            }
        }
        
        //BFS - Khan's Algorithm Basically
        StringBuilder sb = new StringBuilder();
        Queue<char> queue = new Queue<char>();
        foreach(char c in indegree.Keys)
        {
            if(indegree[c] == 0)
            {
                queue.Enqueue(c);
            }
        }
        
        while(queue.Count!=0)
        {
            char c = queue.Dequeue();
            sb.Append(c);
            foreach(char nxt in adjList[c])
            {
                if(--indegree[nxt] == 0)
                {
                    queue.Enqueue(nxt);
                }
            }
        }
        
        if(sb.Length < indegree.Count)
        {
            return string.Empty;
        }
        
        return sb.ToString();
    }
}



















