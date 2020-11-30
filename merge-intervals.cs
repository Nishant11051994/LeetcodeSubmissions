public class Solution {
    public int[][] Merge(int[][] intervals) 
    { 
       int[][] sorted = intervals.OrderBy(x => x[0]).ToArray();
        
       List<int[]> list = new List<int[]>();
        
       foreach(int[] interval in sorted)
       {
           if(list.Count() == 0 || list.Last()[1] < interval[0])
           {
               list.Add(interval);
           }
           else
           {
               list.Last()[1] = Math.Max(list.Last()[1],interval[1]);
           }
       }
        
    return list.ToArray();
        
        
    }
}
