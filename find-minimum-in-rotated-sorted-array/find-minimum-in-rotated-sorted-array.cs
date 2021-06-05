public class Solution {
    public int FindMin(int[] nums) 
    {
        return Math.Min(nums[0],nums[pivot(nums)]);
    }
    private int pivot(int[] nums)
    {
        if(nums[0] < nums[nums.Length-1]) return 0;
        
        int left = 0,right = nums.Length-1;
        
        while(left <= right)
        {
            int mid = left + (right - left)/2;
            if(mid < nums.Length-1 && nums[mid] > nums[mid+1])
            {
                return mid+1;
            }
            else if(nums[mid] < nums[0])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return 0;
    }
}