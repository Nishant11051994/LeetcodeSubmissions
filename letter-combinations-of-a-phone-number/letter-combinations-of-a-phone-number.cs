public class Solution {
    private Dictionary<char,string> map = 
        new Dictionary<char,string>()
    {
        {'2',"abc"},
        {'3',"def"},
        {'4',"ghi"},
        {'5',"jkl"},
        {'6',"mno"},
        {'7',"pqrs"},
        {'8',"tuv"},
        {'9',"wxyz"}
    };
    public IList<string> LetterCombinations(string digits) 
    {       
        IList<string> result = new List<string>();
        if(string.IsNullOrEmpty(digits)) return result;
        List<string> list = new List<string>();
        for(int i = 0 ; i < digits.Length ; i++)
        {
            list.Add(map[digits[i]]);
            Console.WriteLine($"{map[digits[i]]}");
        }
        StringBuilder sb = new StringBuilder();
        Recurse(result,sb,list,0);
        return result;
    }
    private void Recurse(IList<string> result,StringBuilder sb,List<string> list,int index)
    {      
        if(sb.Length == list.Count)
        {
            result.Add(sb.ToString());
        }
        else
        {
           for(int i = 0 ; i < list[index].Length ; i++)
            {
               sb.Append(list[index][i]);
               Recurse(result,sb,list,index+1);
               sb.Remove(sb.Length-1,1);
            }
        }       
    }
}