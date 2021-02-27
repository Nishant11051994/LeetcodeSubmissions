public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
       if(string.IsNullOrEmpty(s)) return 0;
        
       HashSet<char> set = new HashSet<char>();
        
       int start = 0;
       int maxLength = 0;
       int end = 0;
       while(end < s.Length)
       {
           if(!set.Contains(s[end]))
           {
               Console.WriteLine($"start is {start}, end is {end}");
               set.Add(s[end]);
               maxLength = Math.Max(maxLength,end-start+1);
               end++;
           }
           else
           {
               set.Remove(s[start]);
               start++;
           }
       }       
       return maxLength;
        
    }
}