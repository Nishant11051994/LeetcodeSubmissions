public class Solution {
    public bool CanReach(int[] arr, int start) 
    {
        if(arr == null || arr.Length == 0) return false;
        
        bool[] visited = new bool[arr.Length];
        
        return Recurse(arr,start,visited);
    }
    private bool Recurse(int[] arr,int currIndex,bool[] visited)
    {
        if(arr[currIndex] == 0) return true;
        
        visited[currIndex] = true;
         
        int leftSideJump = currIndex - arr[currIndex];
        if(leftSideJump >= 0 && !visited[leftSideJump] && Recurse(arr,leftSideJump,visited))
        {
            return true;
        }
        int rightSideJump = currIndex + arr[currIndex];
        if(rightSideJump < arr.Length && !visited[rightSideJump] && Recurse(arr,rightSideJump,visited))
        {
            return true;
        }
        return false;
    }
}
