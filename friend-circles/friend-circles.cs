public class Solution {
​
    public int FindCircleNum(int[][] M) 
    {
        int count = 0;
        int[] visited = new int[M.Length];
        for(int i =  0 ; i < M.Length ; i++)
        {
            if(visited[i] == 0)
            {
                DFS(M,visited,i);
                count++;
            }
        }        
        return count;
    }
    
    private void DFS(int[][] M,int[] visited,int i)
    {
        for(int j = 0 ; j < M[i].Length ; j++)
        {
            if(M[i][j] == 1 && visited[j] == 0)
            {
                visited[j] = 1;
                DFS(M,visited,j);
            }
        }
    }
}
