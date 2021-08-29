public class Solution {
    public int PartitionDisjoint(int[] A) 
    {
        if(A == null || A.Length == 0) return 0;
        
        int leftMax = A[0];
        int solution = 1;
        int currMax = A[0];
        
        for(int i = 1 ; i < A.Length ; i++)
        {
            if(A[i] < leftMax)
            {
                /*
                    If nums[i] is less than maximum to left, it must go to left partition
                    so, increase the length of partition
                */
                solution = i + 1;
                leftMax = currMax;
            }
            else
            {
                 /*
                    why this ? Just read lines below like a story, you will definitely get the intution
                    Exampel : {5, 0, 3, 8, 6, 0, 10}
                    Until i = 2, leftMax is 5
                    Now, when we reach i = 3, we see that it's not less than leftMax (i.e. 8 > 5)
                    So, we don't need to update partition length BUT we update our currMax = 8
                    Now, we go to i = 4, our leftMax is still 5 and currMax = 8
                    Now, we reach to i = 5, leftMax is still 5 and nums[i] is less than leftMax i.e. (0 < 5)
                    so, we need to update our partition length to (i+1)
                    BUT, here's the catch, After i  = 5, we need to have the leftMax as 8 and not 5 anymore.
                    That's why we update leftMax to currMax
                    i.e. leftMax = currMax;
                */
                currMax = Math.Max(currMax,A[i]);
            }
        }
        
        return solution;
    }
}