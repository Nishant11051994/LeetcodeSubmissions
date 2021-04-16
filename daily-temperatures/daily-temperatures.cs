public class Solution {
    public int[] DailyTemperatures(int[] T) 
    {
        if(T == null || T.Length == 0) return T;
        
        int[] result = new int[T.Length];
        Stack<int> stack = new Stack<int>();
        
        int i = 0;
        while(i < T.Length)
        {
            int curr = i+1;
            int count = 1;
            while(curr < T.Length && T[curr] <= T[i])
            {
                curr++;
                count++;
            }
            if(curr < T.Length && T[curr] > T[i])
            {
                result[i] = count;
            }
            i++;
        }
        return result;
    }
}