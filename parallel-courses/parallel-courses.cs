public class Solution {
    List<int>[] graph;
    private void AddEdge(int src,int dest)
    {
        graph[src].Add(dest);
    }
    public int MinimumSemesters(int n, int[][] relations) 
    {
        graph = new List<int>[n+1];
        int step = 0;
        for(int i = 0 ; i < n+1 ; i++)
        {
            graph[i] = new List<int>();            
        }        
        for(int i = 0 ; i < relations.Length ; i++)
        {
            AddEdge(relations[i][0],relations[i][1]);
        }
        
        Queue<int> indegreeEmpty = new Queue<int>();
        
        int[] indegree  = new int[n+1];
        
        for(int i = 1 ; i < n+1 ; i++)
        {
            foreach(int item in graph[i])
            {
                indegree[item]++;
            }
        }
        
        for(int i = 1 ; i < n+1 ; i++)
        {
            if(indegree[i] == 0)
            {
                indegreeEmpty.Enqueue(i);
            }
        }
        int count = 0;
        while(indegreeEmpty.Count != 0)
        {        
            step++;
            Queue<int> tempQueue = new Queue<int>();            
            while(indegreeEmpty.Count != 0)
            {
                int curr = indegreeEmpty.Dequeue();
                count++;
                foreach(var currItem in graph[curr])
                {
                    if(--indegree[currItem] == 0)
                    {
                     tempQueue.Enqueue(currItem);
                    }
                 }
            }            
            indegreeEmpty = tempQueue;            
        }        
        if(count != n) return -1;        
        return step;        
    }
}