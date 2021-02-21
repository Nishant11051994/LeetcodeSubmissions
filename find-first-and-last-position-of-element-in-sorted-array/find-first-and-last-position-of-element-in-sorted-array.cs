public class Solution {
    public int[] SearchRange(int[] nums, int target) 
    {
        int[] result = new int[2]{-1,-1};
       
        result[0] = BinarySearch(nums,target,true);
        result[1] = BinarySearch(nums,target,false);
             
        return result;
    }
    private int BinarySearch(int[] nums, int target, bool leftBias)
    {
        int start = 0;
        int end = nums.Length-1;
        int i = -1;
        
        while(start <= end)
        {
            int mid = start + (end - start)/2;
            if(target > nums[mid])
            {
                start = mid + 1;
            }
            else if(target < nums[mid])
            {
                end = mid - 1;
            }
            else
            {
                i = mid;
                if(leftBias)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
        }        
        return i;
        
    }
}