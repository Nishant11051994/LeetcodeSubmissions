public class Solution {
    public int MySqrt(int x)
    {
        if(x == 0) return 0;
        
        int left = 1,right = x,res = -1;
        
        while(left <= right)
        {
            int mid = left + (right - left)/2;
            if(mid <= x / mid)
            {
                res = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return res;
    }
}