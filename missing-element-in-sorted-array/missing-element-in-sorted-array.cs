public class Solution {
    public int MissingElement(int[] nums, int k) 
    {
        int left = 0, right = nums.Length;
        while (left < right) {
        int mid = left + (right - left) / 2;
        if (nums[mid] - nums[0] < mid + k)
            left = mid + 1;
        else
            right = mid;
         }
        return nums[0] + left + k - 1;
    }
}