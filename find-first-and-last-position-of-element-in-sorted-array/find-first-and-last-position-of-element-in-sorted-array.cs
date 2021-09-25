public class Solution {
    public int[] SearchRange(int[] nums, int target) 
    {
        int[] res = new int[2];
        res[0] = -1;
        res[1] = -1;
        if(nums == null || nums.Length == 0) return res;
        
        res[0] = FindFirst(nums,target);
        res[1] = FindLast(nums,target);
        
        return res;
    }
    private int FindFirst(int[] nums,int target)
    {
       int left = 0;
       int right = nums.Length-1;
       int leftMost = -1;
        
       while(left <= right)
       {
           int mid = left + (right-left)/2;
           if(nums[mid] == target)
           {
               leftMost = mid;
               right = mid - 1;
           }
           else if(nums[mid] > target)
           {
               right = mid - 1;
           }
           else
           {
               left = mid + 1;
           }
       }
       return leftMost;
    }
    private int FindLast(int[] nums,int target)
    {
        int left = 0;
       int right = nums.Length-1;
       int rightMost = -1;
        
       while(left <= right)
       {
           int mid = left + (right-left)/2;
           if(nums[mid] == target)
           {
               rightMost = mid;
               left = mid + 1;
           }
           else if(nums[mid] > target)
           {
               right = mid - 1;
           }
           else
           {
               left = mid + 1;
           }
       }
       return rightMost;
    }
}