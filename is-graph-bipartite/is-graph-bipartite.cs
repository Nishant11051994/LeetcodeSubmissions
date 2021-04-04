public class Solution {
    List<int>[] adjencyList;
    HashSet<int> RedList;
    HashSet<int> BlueList;
    private void AddEdge(int src,int dest)
    {
        adjencyList[src].Add(dest);
    }
     public bool IsBipartite(int[][] graph) 
    {
        int n = graph.Length;
        bool[] visited = new bool[n];
        adjencyList = new List<int>[n];
        for(int i = 0; i < n ; i++)
        {
            adjencyList[i] = new List<int>();
        }
        for(int i = 0 ; i < n ; i++)
        {
            for(int j = 0 ; j < graph[i].Length ; j++)
            {
                AddEdge(i,graph[i][j]);
            }
        }
        for(int i = 0 ; i < n ; i++)
        {
            if(!IsBipartiteUtil(graph,i,visited))
            {
                return false;
            }
        }
        return true;        
    }
    private bool IsBipartiteUtil(int[][] graph,int index,bool[] visited)
    {      
        Queue<int> queue = new Queue<int>();
        RedList = new HashSet<int>();
        BlueList = new HashSet<int>();
        queue.Enqueue(index);
        visited[index] = true;
        RedList.Add(index);
        while(queue.Count != 0)
        {
            int curr = queue.Dequeue();
            foreach(int item in adjencyList[curr])
            {
                  if(!visited[item])
                  {
                    queue.Enqueue(item);
                    visited[item] = true;  
                  }
                  if(RedList.Contains(curr))
                  {
                    if(RedList.Contains(item))
                     {
                        Console.WriteLine($"curr is {curr} and item is {item}");
                        return false;
                     }
                     BlueList.Add(item);
                   }
                  else
                  {
                   if(BlueList.Contains(item))
                     {
                         Console.WriteLine($"curr is {curr} and item is {item}");
                         return false;
                     }
                     RedList.Add(item);
                  }                        
            }                             
        }  
        return true;
    }   
}