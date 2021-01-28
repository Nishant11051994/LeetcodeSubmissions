public class Solution {
    public int[][] Merge(int[][] intervals) 
    {
       if(intervals == null || intervals.Length == 0) return intervals;
        
       intervals = intervals.OrderBy(x => x[0]).ToArray();
        
       List<int[]> result = new List<int[]>();
        
       foreach(int[] item in intervals)
       {
           if(result.Count == 0 || result.Last()[1] < item[0])
           {
               result.Add(item);
           }
           else
           {
               result.Last()[1] = Math.Max(item[1],result.Last()[1]);
           }
       }
        
       return result.ToArray();
    }
}