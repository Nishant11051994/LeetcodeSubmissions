public class Solution {
    public int FindMin(int[] nums) 
    {
        if(nums == null || nums.Length == 0)
        {
            return -1;
        }
        
        if(nums.Length == 1) return nums[0];
        
        if(nums[0] < nums[nums.Length-1]) return nums[0];
        
        int index = BinarySearch(nums,0,nums.Length-1);
        
        return index != -1 ? nums[index] : -1; 
    }
    private int BinarySearch(int[] nums,int start,int end)
    {
        int n = nums.Length;        
        while(start <= end)
        {
            if(nums[start] <= nums[end]) return start;
            int mid = start + (end-start)/2;
            if(nums[mid] <= nums[(mid-1+n)%n] && nums[mid] <= nums[(mid+1)%n])
            {
                return mid;
            }
            else if(nums[mid] >= nums[start])
            {
                start = mid + 1;
            }
            else if(nums[mid] <= nums[end])
            {
                end = mid - 1;
            }
        }
        return -1;
    }
    
}
