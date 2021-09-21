public class Solution {
    public int SingleNonDuplicate(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return 0;
        
        Dictionary<int,int> freqMap = new Dictionary<int,int>();
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(!freqMap.ContainsKey(nums[i]))
            {
                freqMap.Add(nums[i],0);
            }
            freqMap[nums[i]]++;
        }
        
        int single = freqMap.FirstOrDefault(x => x.Value == 1).Key;
        
        return single;
        
    }
}