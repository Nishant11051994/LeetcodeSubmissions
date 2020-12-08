public class Solution {
    public int LongestOnes(int[] A, int K) 
    {
        if(A == null || A.Length == 0) return 0;
        
        int start = 0;
        int end = 0;
        int maxLength = 0;
        int zeroCount = 0;
        
        while(end < A.Length)
        {
            if(A[end] == 0)
            {
                zeroCount++;
            }
            while(zeroCount > K)
            {
                if(A[start] == 0)
                {
                    zeroCount--;
                }
                start++;
            }
            maxLength = Math.Max(maxLength,end-start+1);
            end++;
        }
        
        return maxLength;
        
    }
}
