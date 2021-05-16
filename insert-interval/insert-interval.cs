public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) 
    {
        if(intervals == null) return null;
        
        List<int[]> result = new List<int[]>();
        
        bool intervalMerged = false;
        if(intervals.Length == 0 || newInterval[1] < intervals[0][0])
        {
            result.Add(newInterval);
            intervalMerged = true;
        }
        
        foreach(int[] item in intervals)
        {
          if(intervalMerged)
          {
              if(result.Last()[1] < item[0])
              {
                  result.Add(item);
              }
              else
              {
                  result.Last()[1] = Math.Max(item[1],result.Last()[1]);
              }              
          }
          else 
          {
             if(newInterval[0] > item[1])
             {
                 result.Add(item);
             }
             else if(newInterval[1] < item[0])
             {
                 result.Add(newInterval);
                 result.Add(item);
                 intervalMerged = true;
             }
             else if(item[0] < newInterval[0] && item[1] > newInterval[1])
             {
                 result.Add(item);
                 intervalMerged = true;
             }
             else
             {
                 item[0] = Math.Min(item[0],newInterval[0]);
                 item[1] = Math.Max(item[1],newInterval[1]);
                 result.Add(item);
                 intervalMerged = true;
             }
          }          
        }
        
        if(!intervalMerged)
        {
            result.Add(newInterval);
        }
        
        return result.ToArray();
    }
}