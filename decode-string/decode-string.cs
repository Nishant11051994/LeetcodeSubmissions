public class Solution {
    public string DecodeString(string s) 
    {
        if(string.IsNullOrEmpty(s)) return s;
        
        StringBuilder currentString = new StringBuilder();
        
        Stack<StringBuilder> stack = new Stack<StringBuilder>();
        
        Stack<int> numStack = new Stack<int>();
        
        int k = 0;
        
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(Char.IsDigit(s[i]))
            {
                k = k * 10 + (s[i] - '0');
            }
            else if(s[i] == '[')
            {
                numStack.Push(k);
                stack.Push(currentString);
                currentString = new StringBuilder();
                k = 0;
            }
            else if(s[i] == ']')
            {
                StringBuilder decodedString = stack.Pop();
                for(int currentK = numStack.Pop() ; currentK > 0 ; currentK--)
                {
                    decodedString.Append(currentString);
                }
                currentString = decodedString;
            }
            else
            {
                currentString.Append(s[i]);
            }
        }
        
        return currentString.ToString();
        
        
    }
}