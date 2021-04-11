public class Solution {
    public int[] TwoSum(int[] nums, int target) 
    {
        int[] result = new int[2];
        
        Dictionary<int,int> map = new Dictionary<int,int>();
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i],i);
            }
        }
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            int diff = target - nums[i];
            if(map.ContainsKey(diff) && map[diff] != i)
            {
                result[0] = i;
                result[1] = map[diff];
                Array.Sort(result);
                break;
            }
        }
        return result;
    }
}