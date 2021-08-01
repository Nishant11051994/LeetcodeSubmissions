/**
 * // This is ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *     public int Get(int index) {}
 * }
 */

class Solution {
    public int Search(ArrayReader reader, int target) 
    {
        return BinarySearch(reader,target);
    }
    private int BinarySearch(ArrayReader reader,int target)
    {
        int left = 0;        
        int right = 10000;
        int max = int.MaxValue;
        
        while(left <= right)
        {
            int mid = left + (right-left)/2;   
            int back = reader.Get(mid);
            if(back == target)
            {
                return mid;
            }
            else if(back == max || back > target)
            {
                right = mid - 1;
            }
            else if(back != max && back < target)
            {
                left = mid + 1;
            }
        }
        return -1;
    }
}