public class Solution {
    public IList<string> GenerateParenthesis(int n) 
    {
        IList<string> result = new List<string>();
        
        Recurse(result,new StringBuilder(),n,0,0);
        
        return result;
        
    }
    private void Recurse(IList<string> result,StringBuilder sb,int n,int open,int close)
    {
        if(sb.Length == 2 * n)
        {
            result.Add(sb.ToString());
        }
        else
        {
            if(open < n)
            {
                sb.Append('(');
                Recurse(result,sb,n,open+1,close);
                sb.Remove(sb.Length-1,1);
            }
            if(close < open)
            {
                sb.Append(')');
                Recurse(result,sb,n,open,close+1);
                sb.Remove(sb.Length-1,1);
            }
        }
    }
}