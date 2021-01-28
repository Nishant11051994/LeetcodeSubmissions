public class Solution {
    public int Search(int[] nums, int target) 
    {
        if(nums == null || nums.Length == 0) return -1;
        
        if(nums.Length == 1) return nums[0] == target ? 0 : -1;
        
        int pivot = FindPivot(nums);
        
        Console.WriteLine(pivot);
        
        if(pivot == 0) return Find(nums,0,nums.Length-1,target);
        
        if(nums[0] > target) return Find(nums,pivot,nums.Length-1,target); 
        
        return Find(nums,0,pivot,target);
        
    }
    private int FindPivot(int[] nums)
    {
        int start = 0;
        int end = nums.Length-1;
        
        if(nums[start] < nums[end]) return 0;
        
        while(start <= end)
        {
            int pivot = (start + end)/2;
            if(nums[pivot] > nums[pivot+1])
            {
                return pivot + 1;
            }
            else 
            {
                if(nums[0] > nums[pivot])
                {
                    end = pivot - 1;
                }
                else
                {
                    start = pivot + 1;
                }
            }
        }
        return 0;
    }
    private int Find(int[] nums,int start,int end,int target)
    {
        while(start <= end)
        {
            int pivot = (start + end)/2;
            if(nums[pivot] == target)
            {
                return pivot;
            }
            else if(nums[pivot] < target)
            {
                start = pivot + 1;
            }
            else
            {
                end = pivot - 1;
            }
        }
        return -1;
    }
}








