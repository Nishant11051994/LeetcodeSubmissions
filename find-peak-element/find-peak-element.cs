public class Solution {
    public int FindPeakElement(int[] nums) 
    {
         if(nums == null || nums.Length == 0)
          {
            return -1;
          }  
          return BinarySearch(nums);
    }
    private int BinarySearch(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        while(start <= end)
        {
            int mid = start + (end - start)/2;
            if(GreaterThanNeighbours(mid,nums))
            {
                return mid;
            }
            if(mid >0 && nums[mid] < nums[mid-1])
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        return 0;
    }
    private bool GreaterThanNeighbours(int index,int[] nums)
    {
        int n = nums.Length - 1;
        if(index > 0 && index < n)
        {
            if(nums[index] > nums[index-1] && nums[index] > nums[index+1])                       return true;
            
            return false;
        }
        if(index > 0)
        {
            if(nums[index] > nums[index-1]) return true;
            
            return false;            
        }
        if(index < n)
        {
            if(nums[index] > nums[index+1]) return true;
            
            return false;
        }
        return false;
    }
}