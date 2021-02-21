public class Solution {
    public int[] SearchRange(int[] nums, int target) 
    {
        int[] result = new int[2]{-1,-1};
        
        int leftMostIndex = BinarySearch(nums,target,true);
        
        if(leftMostIndex == nums.Length || nums[leftMostIndex] != target)
        {
            return result;
        }
       
        result[0] = leftMostIndex;
        result[1] = BinarySearch(nums,target,false) - 1;
             
        return result;
    }
    private int BinarySearch(int[] nums, int target, bool left)
    {
        int start = 0;
        int end = nums.Length;
        
        while(start < end)
        {
            int mid = start + (end - start)/2;
            if(nums[mid] > target || (left && target == nums[mid]))
            {
                end = mid;
            }
            else
            {
                start = mid + 1;
            }
        }        
        return start;
        
    }
}