public class Solution {
    HashSet<int>[] graph;
    public int MaximalNetworkRank(int n, int[][] roads) 
    {
        if(n == 0 || roads == null || roads.Length == 0);
        
        graph = new HashSet<int>[n];
        
        for(int i = 0 ; i < n ; i++)
        {
            graph[i] = new HashSet<int>();
        } 
        InitialiseGraph(roads);
        
        int maxPairsRank = 0;
        
        for(int i = 0 ; i < n ; i++)
        {
            for(int j = i + 1 ; j < n ; j++)
            {
                int currRank  = graph[i].Count + graph[j].Count;
                if(graph[i].Contains(j))
                {
                    currRank--;
                }
                maxPairsRank = Math.Max(maxPairsRank,currRank);
            }
        }
        
        return maxPairsRank;
    }
    private void InitialiseGraph(int[][] roads)
    {
        for(int i = 0 ; i < roads.Length ; i++)
        {
            graph[roads[i][0]].Add(roads[i][1]);
            graph[roads[i][1]].Add(roads[i][0]);            
        }
    }
}