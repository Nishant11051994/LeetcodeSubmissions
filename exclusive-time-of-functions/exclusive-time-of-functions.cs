//https://leetcode.com/problems/exclusive-time-of-functions/discuss/847391/c-stack
public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) 
    {
        if(logs == null || n == 0) return null;
        
        Stack<int[]> stack = new Stack<int[]>();
        
        int[] res = new int[n];
        
        foreach(string log in logs)
        {
            int firstColonIndex = log.IndexOf(":");
            int secondColonIndex = log.IndexOf(":",firstColonIndex+1);
            
            int id = Int32.Parse(log.Substring(0,firstColonIndex));
            int timestamp = Int32.Parse(log.Substring(secondColonIndex+1));            
            if(log[firstColonIndex+1] == 's')
            {
                if(stack.Count > 0)
                {
                    int[] f = stack.Peek();
                    res[f[0]] += timestamp - f[1];
                }
                stack.Push(new int[2]{id,timestamp});                
            }
            else
            {
                res[id] += timestamp - stack.Pop()[1] + 1;
                if(stack.Count > 0)
                {
                    int[] f = stack.Peek();
                    f[1] = timestamp + 1;
                }             
            }         
        }
        
        return res;       
    }
}