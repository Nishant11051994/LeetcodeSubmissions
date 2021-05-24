public class Solution {
    int row;
    int col;
    public int ShortestBridge(int[][] A) {
        row= A.Length;
        if(row == 0) return 0;
        col = A[0].Length;
        
        var island1 = new List<int[]>();
        var island2 = new List<int[]>();
        
        for(int i=0; i<row; i++){
            for(int j = 0; j< col; j++){
               if( A[i][j] == 1 && island1.Count==0){
                   Dfs(A, island1, i, j);
               }
                else{
                    Dfs(A,island2, i, j);
                }
            }
        }
        int min=100;
        foreach (var i1 in island1){
            foreach( var i2 in island2){
              min = Math.Min(min, Math.Abs(i1[0]-i2[0]) + Math.Abs(i1[1]-i2[1]) -1);  
            }
        }
     return min;   
    }
    
    public void Dfs(int[][] A, List<int[]> island, int i, int j){
        if(i<0||i>=row||j<0||j>=col||A[i][j]==0) return;
        A[i][j] = 0;
        island.Add(new int[] {i, j});
        Dfs(A, island, i+1, j);
        Dfs(A, island, i, j-1);
        Dfs(A, island, i-1, j);
        Dfs(A, island, i, j+1);
    }
}