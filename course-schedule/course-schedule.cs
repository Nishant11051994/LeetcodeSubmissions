public class Solution {
    List<int>[] adjencyList;
    private void AddEdge(int src,int dest)
    {
        adjencyList[src].Add(dest);
    }
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        adjencyList = new List<int>[numCourses];
        for(int i = 0 ; i < numCourses ; i++)
        {
            adjencyList[i] = new List<int>();
        }
        for(int i = 0 ; i < prerequisites.Length ; i++)
        {
            AddEdge(prerequisites[i][1],prerequisites[i][0]);
        }
        
        int[] indegree = new int[numCourses];
        foreach(var item in adjencyList)
        {
            foreach(int course in item)
            {
                indegree[course]++;
            }
        }
        Queue<int> queue = new Queue<int>();
        for(int i = 0 ; i < numCourses ; i++)
        {
            if(indegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        int count = 0;
        while(queue.Count != 0)
        {
            int curr = queue.Dequeue();
            count++;
            foreach(var item in adjencyList[curr])
            {
                if(--indegree[item] == 0)
                {
                    queue.Enqueue(item);
                }
            }
        }
        if(count == numCourses)
        {
            return true;
        }
        return false;
    }
}