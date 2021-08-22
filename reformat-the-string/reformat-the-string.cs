public class Solution {
    public string Reformat(string s) 
    {
        if(string.IsNullOrEmpty(s)) return s;
        
        List<int> digits = new List<int>();
        List<char> alphabets = new List<char>();
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(char.IsDigit(s[i]))
            {
                digits.Add(s[i] - '0');
            }
            else
            {
                alphabets.Add(s[i]);
            }
        } 
        
        if(Math.Abs(digits.Count - alphabets.Count) > 1) return "";
        
        int dIndex = 0;
        int aIndex = 0;
        
        bool digitCountMore = digits.Count > alphabets.Count ? true : false;
        
        Console.WriteLine(digitCountMore);
        
        if(digitCountMore)
        {
            while(dIndex < digits.Count || aIndex < alphabets.Count)
            {
                if(dIndex < digits.Count)
                sb.Append(digits[dIndex++]);  
                
               if(aIndex < alphabets.Count)
               sb.Append(alphabets[aIndex++]);                        
            }
        }
        else
        {
            while(dIndex < digits.Count || aIndex < alphabets.Count)
            {
              Console.WriteLine($"a index is {aIndex}, d index is {dIndex}");
              if(aIndex < alphabets.Count)
              sb.Append(alphabets[aIndex++]);
                
              if(dIndex < digits.Count)
              sb.Append(digits[dIndex++]);  
            }
        }
        
        string result = sb.ToString();
        
        Console.WriteLine(result);
        
        return result.Length == s.Length ? result : "";
        
    }
}