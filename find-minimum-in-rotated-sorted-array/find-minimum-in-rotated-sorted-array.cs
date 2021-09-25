public class Solution {
    public int FindMin(int[] nums) 
    {
         int left = 0;
         int right = nums.Length-1;
        
         if(nums[left] <= nums[right]) return nums[left];
        
         while(left <= right)
         {
             int mid = left + (right-left)/2;
             if(mid < nums.Length-1 && nums[mid] > nums[mid+1])
             {
                 return nums[mid+1];
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
        return left;
         
    }
}