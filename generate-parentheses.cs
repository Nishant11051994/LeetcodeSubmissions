public class Solution {
    public IList<string> GenerateParenthesis(int n) 
    {
        IList<string> result = new List<string>();
        if(n == 0) return result;
        BackTrack(n,result,new StringBuilder(),0,0);
        return result;
    }
    private void BackTrack(int n,IList<string> result,StringBuilder currentString,int open,int close)
    {
        if(currentString.Length == 2 * n)
        { 
          if(!result.Contains(currentString.ToString()))
          result.Add(currentString.ToString());
        }
        else
        {
           if(open < n)
           {
               currentString.Append("(");
               BackTrack(n,result,currentString,open+1,close);
               currentString.Remove(currentString.Length-1,1);
           }
           if(close < open)
           {
               currentString.Append(")");
               BackTrack(n,result,currentString,open,close+1);
               currentString.Remove(currentString.Length-1,1);
           }
        }      
    }
}
