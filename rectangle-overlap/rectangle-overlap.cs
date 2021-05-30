public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) 
    {
       if(rec1 == null || rec1.Length == 0 || rec2 == null || rec2.Length == 0) return false;
        
       int x1 = rec1[0];
       int y1 = rec1[1];
        
       int x2 = rec1[2];
       int y2 = rec1[3];
        
       int m1 = rec2[0];
       int n1 = rec2[1];
        
       int m2 = rec2[2];
       int n2 = rec2[3];
        
       if(Math.Min(x2,m2) > Math.Max(x1,m1) && Math.Min(y2,n2) > Math.Max(y1,n1))
       {
           return true;
       }        
       return false;

    }
}