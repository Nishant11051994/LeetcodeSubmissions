public class Solution {
    public int StrStr(string haystack, string needle) 
    {
       if(haystack == needle || needle == string.Empty) return 0;
       int resultIndex = -1;
       int count = 0;
       int i = 0,j = 0;
       while(i < haystack.Length)
       {
           if(j < needle.Length && haystack[i] == needle[j])
           {
             resultIndex = i;
             while(i < haystack.Length && j < needle.Length && haystack[i] == needle[j])
             {
               i++;
               j++;
               count++;
             }
             if(count != needle.Length)
             {
               i = resultIndex + 1;
               resultIndex = -1;
               count = 0;
               j = 0;
               continue;
             }
             break;
           }          
           i++;
       }
    
       return resultIndex;
    }
}