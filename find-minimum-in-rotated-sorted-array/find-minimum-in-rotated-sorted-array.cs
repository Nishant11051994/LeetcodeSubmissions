public class Solution {
    public int FindMin(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        int pivot = FindPivot(nums);
        
        return nums[pivot];
    }
    private int FindPivot(int[] nums)
    {
        int start = 0;
        int end = nums.Length-1;
        if(nums[start] < nums[end]) return start;
        while(start <= end)
        {
            int mid = start + (end - start)/2;
            Console.WriteLine($"mid is {mid} and nums.Length-1 is {nums.Length-1}");
            if(mid < nums.Length-1 && nums[mid] > nums[mid+1])
            {
                return mid + 1;
            }
            else if(nums[0] > nums[mid])
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
}