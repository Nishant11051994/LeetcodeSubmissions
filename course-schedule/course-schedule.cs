public class Solution {
    List<int>[] adjencyList;
    int n;
    private void AddEdge(int src,int dest)
    {
        adjencyList[src].Add(dest);
    }
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        if(numCourses == null || prerequisites == null || prerequisites.Length == 0)
        {
            return true;
        }
        
        n = numCourses;
        adjencyList = new List<int>[n];
        for(int i = 0 ; i < n ; i++)
        {
            adjencyList[i] = new List<int>();
        }
        
        for(int i = 0 ; i < prerequisites.Length ; i++)
        {
            AddEdge(prerequisites[i][1],prerequisites[i][0]);
        }
        
        int[] indegree = new int[n];
