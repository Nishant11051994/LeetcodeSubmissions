public class Solution {
    public int MissingElement(int[] nums, int k) 
    {
        int left = 0;
        int right = nums.Length - 1;
        while(left <= right)
        {
            int mid = left + (right - left)/2;
            int missing = nums[mid] - nums[0] - mid;
            if(missing >= k)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return k + nums[0] + right;
    }
}