public class Solution {
    private List<int>[] graph;
    private HashSet<(int,int)> connSet;
    private int[] rank;
    private void AddEdge(int src,int dest)
    {
        graph[src].Add(dest);
        graph[dest].Add(src);
    }
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) 
    {
        graph = new List<int>[n];;
        connSet = new HashSet<(int,int)>();
        rank = new int[n];
        IList<IList<int>> result = new List<IList<int>>();
        
        //Initialise graph object
        for(int i = 0 ; i < n ; i++)
        {
            graph[i] = new List<int>();
            rank[i] = -1;
        }
        
        //Populate graph and connSet
        foreach(var list in connections)
        {
            int u = list[0];
            int v = list[1];
            
            AddEdge(u,v);
            int minU = Math.Min(u,v);
            int minV = Math.Max(u,v);
            (int,int) temp = (minU,minV);
            connSet.Add(temp);            
        }
        
        DFS(0,0);
        
        foreach(var item in connSet)
        {
            result.Add(new List<int>(){item.Item1,item.Item2});
        }
        
        return result;
        
    }
    private int DFS(int node,int discoveryRank)
    {
        if(rank[node] != -1) return rank[node];
        
        
        rank[node] = discoveryRank;
        
        int minRank = discoveryRank + 1;
        
        foreach(var neighbour in graph[node])
        {
            int neighbourRank = rank[neighbour];
            
            if(neighbourRank != -1 && neighbourRank == discoveryRank - 1)
                continue;
            
            int recursiveRank = DFS(neighbour,discoveryRank + 1);
            
            if(recursiveRank <= discoveryRank)
            {
                int minU = Math.Min(node,neighbour);
                int maxV = Math.Max(node,neighbour);
                (int,int) temp = (minU,maxV);

                connSet.Remove(temp);                
            }  
            minRank = Math.Min(minRank,recursiveRank);
        }        
        return minRank;        
    }
}