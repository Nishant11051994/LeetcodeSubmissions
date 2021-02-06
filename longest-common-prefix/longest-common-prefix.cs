public class Solution {
    public string LongestCommonPrefix(string[] strs) 
    {
       if(strs == null || strs.Length == 0) return string.Empty;
       
       string comparisonString = strs[0];
       StringBuilder sb = new StringBuilder();
       int comparisonIndex = 0;
        
       for(int i = 0 ; i < comparisonString.Length ; i++)
       {
           for(int j = 1 ; j < strs.Length ; j++)
           {
               string currentWord = strs[j];
               if(comparisonIndex >= currentWord.Length)
               {
                   return sb.ToString();
               }
               char currLetter = currentWord[comparisonIndex];
               if(currLetter != comparisonString[i])
               {
                   return sb.ToString();
               }
           }
           comparisonIndex++;
           sb.Append(comparisonString[i]);
       }
       
       return sb.ToString();        
    }
}