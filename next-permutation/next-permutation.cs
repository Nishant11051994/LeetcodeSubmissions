public class Solution {
    public void NextPermutation(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return;
        
        int i = nums.Length - 2;
        while(i >= 0 && nums[i] >= nums[i+1])
        {
            i--;
        }
        
        if(i >= 0)
        {
            int j = nums.Length - 1;
            while(j >= 0 && nums[j] <= nums[i])
            {
                j--;
            }
            Swap(nums,i,j);
        }
        Reverse(nums,i+1);        
    }
    private void Swap(int[] nums,int i,int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    private void Reverse(int[] nums,int start)
    {
        int i = start;
        int j = nums.Length - 1;
        while(i < j)
        {
            Swap(nums,i,j);
            i++;
            j--;
        }
    }
}