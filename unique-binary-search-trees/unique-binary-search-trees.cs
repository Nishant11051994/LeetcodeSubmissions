public class Solution {
    public int NumTrees(int n) 
    {
        return Recurse(n);
    }
    private int Recurse(int n)
    {
        if(n == 0 || n == 1) return 1;
        
        int sum = 0;
        for(int i = 1 ; i <= n ; i++)
        {
            sum += Recurse(i-1) * Recurse(n - i);
        }
        return sum;
    }
}