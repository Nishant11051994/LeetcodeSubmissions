public class Solution {
    public string RemoveDuplicates(string s, int k) 
    {
       if(string.IsNullOrEmpty(s)) return s;
        
       Stack<(char,int)> stack = new Stack<(char,int)>();
        
       foreach(char c in s)
       {
           if(stack.Count == 0)
           {
               stack.Push((c,1));
               continue;
           }
           
           (char,int) peek = stack.Peek();
           if(peek.Item1 != c)
           {
               stack.Push((c,1));
               continue;
           }          
           stack.Pop();
           if(peek.Item2 < k-1)
           {
               stack.Push((peek.Item1,peek.Item2+1));
           }
       }        
        var str = new StringBuilder();
	   while (stack.Count > 0) {
		var (c, f) = stack.Pop();
		for (var i = 0; i < f; i++) {
			str.Append(c);
		}
	}

	return new string(str.ToString().Reverse().ToArray());
    }
}