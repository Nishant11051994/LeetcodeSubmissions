/*
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
*/
public class Solution {
    public int[] DailyTemperatures(int[] T) 
    {
        if(T == null || T.Length == 0) return T;
        
        int n = T.Length;
        
        int[] result = new int[n];
        Stack<int> stack = new Stack<int>();
        
        for(int i = n-1 ; i >= 0 ; i--)
        {
            while(stack.Count > 0 && T[i] >= T[stack.Peek()])
            {
                stack.Pop();
            }
            result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
            stack.Push(i);
        }
        return result;
    }
}


















