public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        if(graph == null || graph.Length == 0) return result;
        DFS(graph,result,new List<int>(){0},0);
        return result;        
    }
    private void DFS(int[][] graph, IList<IList<int>> result,List<int> current,int currIndex)
    {
        if(currIndex == graph.Length-1)
        {
            result.Add(new List<int>(current));
            return;
        }
            
        int[] childs = graph[currIndex];
        for(int i = 0 ; i < childs.Length ; i++)
        {
            current.Add(childs[i]);
            DFS(graph,result,current,childs[i]);
            current.RemoveAt(current.Count-1);
        }           
    }
}
