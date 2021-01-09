public class Solution {
    public int MinFallingPathSum(int[][] A) 
    {
        if(A == null || A.Length == 0) return 0;
        
        int min = Int32.MaxValue;
        int[,] dp = new int[A.Length,A[0].Length];
        for(int i = 0 ; i < A[0].Length ; i++)
        {
            min = Math.Min(min,Recurse(A,0,i,dp));
        }
        return min;
    }
    private int Recurse(int[][] A,int x,int y,int[,] dp)
    {
        if(x == A.Length-1) return A[x][y];
        
        if(dp[x,y] != 0) return dp[x,y];
        
        int a = Int32.MaxValue;
        int b = Int32.MaxValue;
        int c = Int32.MaxValue;
        
        if(y - 1 >= 0 && y+1 <= A[0].Length-1)
        {
            a = Recurse(A,x+1,y,dp);
            b = Recurse(A,x+1,y-1,dp);
            c = Recurse(A,x+1,y+1,dp);
        }
        else if(y-1 >= 0)
        {
            a = Recurse(A,x+1,y,dp);
            b = Recurse(A,x+1,y-1,dp);
        }
        else
        {
            a = Recurse(A,x+1,y,dp);
            c = Recurse(A,x+1,y+1,dp);
        }
        
        dp[x,y] = A[x][y] + Math.Min(a,Math.Min(b,c));
        return dp[x,y];
    }
}
