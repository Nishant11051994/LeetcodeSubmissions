public class Solution {
    public bool BackspaceCompare(string s, string t) 
    {
        if(String.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return true;
        
        return GetFinal(s) == GetFinal(t);
        
    }
    private string GetFinal(string s)
    {
        Stack<char> stack = new Stack<char>();
        
        foreach(char c in s)
        {
            if(c == '#')
            {
                if(stack.Count != 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(c);
            }
        }
        
        StringBuilder sb = new StringBuilder();
        while(stack.Count != 0)
        {
            sb.Append(stack.Pop());
        }
        
        return sb.ToString();
    }
}