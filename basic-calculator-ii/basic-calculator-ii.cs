public class Solution {
    public int Calculate(string s) 
    {
        if(String.IsNullOrEmpty(s)) return 0;  
        int len = s.Length;
        Stack<int> stack = new Stack<int>();  
        int currNumber = 0;
        char operation = '+';
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(Char.IsDigit(s[i]))
            {
               currNumber = (currNumber * 10) + (s[i] - '0');
            }
            if(!Char.IsDigit(s[i]) && !Char.IsWhiteSpace(s[i]) || i == len-1)
            {
                if(operation == '-')
                stack.Push(-currNumber);
                
                else if(operation == '+')
                stack.Push(currNumber);
                
                else if(operation == '*')
                stack.Push(stack.Pop() * currNumber);
                
                else if(operation == '/')
                stack.Push(stack.Pop() / currNumber);
                
                operation = s[i];
                currNumber = 0;
            }      
        } 
        int result = 0;
        while(stack.Count > 0)
        {
            result += stack.Pop();
        }
        return result;
    }
}
