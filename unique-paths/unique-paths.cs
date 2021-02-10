public class Solution {
    public int UniquePaths(int m, int n) 
    {
       int[,] dp = new int[m,n];
       return Recurse(m,n,0,0,dp);
    }
    private int Recurse(int m,int n,int i,int j,int[,] dp)
    {
        if(i == m-1 && j == n-1)
        {
            return 1;
        }
        if(dp[i,j] != 0) return dp[i,j];
        int path1 = 0;
        int path2 = 0;
        if(i+1 < m)
        {
            path1 = Recurse(m,n,i+1,j,dp);
        }
        if(j+1 < n)
        {
            path2 = Recurse(m,n,i,j+1,dp);
        }
        dp[i,j] = path1 + path2;
        return dp[i,j];
    }
}