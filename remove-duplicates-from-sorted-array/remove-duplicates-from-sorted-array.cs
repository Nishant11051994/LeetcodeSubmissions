public class Solution {
    public int RemoveDuplicates(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        Array.Sort(nums);
        int start = 1, end = 1;
        while(end < nums.Length)
        {
            if(nums[end] != nums[end-1])
            {
                nums[start++] = nums[end];
            }
            end++;
        }
        return start;
    }
}