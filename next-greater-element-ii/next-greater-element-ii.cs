public class Solution {
    public int[] NextGreaterElements(int[] nums) 
    {
        int[] res = new int[nums.Length];
        
        for(int i = 0 ; i < res.Length ; i++)
        {
            res[i] = -1;
        }
        
        int length = nums.Length;
        
        if(nums == null || nums.Length == 0) return res;
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            int j = (i + 1) % length;
            while( j != i)
            {
                if(nums[j] > nums[i])
                {
                    res[i] = nums[j];
                    break;
                }
                else
                {
                    j = (j + 1) % length;
                }
            }
        }
        
        return res;
    }
}