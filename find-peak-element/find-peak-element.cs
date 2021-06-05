public class Solution {
    public int FindPeakElement(int[] arr) 
    {
        if(arr == null || arr.Length == 0) return 0;
        
        int left = 0,right = arr.Length-1,boundaryIndex = -1;
        
        while(left <= right)
        {
            int mid = left + (right - left)/2;
            if(mid == arr.Length-1 || arr[mid] >= arr[mid+1])
            {
                boundaryIndex = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        
        return boundaryIndex;
    }
}