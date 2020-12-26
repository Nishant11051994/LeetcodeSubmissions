public class Solution {
    public int MaxLength(IList<string> arr) 
    {
        if(arr == null || arr.Count == 0) return 0;
        return BackTrack(arr,0,"");
    }
    private int BackTrack(IList<string> arr,int index,string curr)
    {
       if(index == arr.Count) return curr.Length;
    
       int maxLength = curr.Length;
       for(int i = index ; i < arr.Count ; i++)
       {
           if(IsUnique(arr[i] + curr))
           {
               int length = BackTrack(arr,i+1,curr+arr[i]);
               maxLength = length > maxLength ? length : maxLength;
           }
       }
       return maxLength;
    }
    private bool IsUnique(string s)
    {
        HashSet<char> set = new HashSet<char>();
        foreach(char c in s)
        {
            set.Add(c);
        }
        return set.Count == s.Length;
    }
}
