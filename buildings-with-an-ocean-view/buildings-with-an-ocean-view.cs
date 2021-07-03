public class Solution {
    public int[] FindBuildings(int[] heights) 
    {
        if(heights == null || heights.Length == 0) return null;
        
        Stack<int> stack = new Stack<int>();
                
        for(int i = heights.Length-1 ; i >= 0 ; i--)
        {
            if(stack.Count == 0)
            {
                stack.Push(i);
            }
            else
            {
                if(heights[i] > heights[stack.Peek()])
                {
                    stack.Push(i);
                }
            }
        }
        
        int[] finalArray = stack.ToArray();
        
        finalArray = finalArray.OrderBy(x => x).ToArray();
       
        return finalArray;
        
        
    }
}