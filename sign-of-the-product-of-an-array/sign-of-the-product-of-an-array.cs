public class Solution {
    public int ArraySign(int[] nums) 
    {
        if(nums == null) return 0;
        
        int prod = 1;
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(nums[i] < 0)
            {
                prod *= -1;
            }
            else if(nums[i] > 0)
            {
                prod *= 1;
            }
            else
            {
                prod = 0;
                break;
            }
        }
        return prod;
    }
}