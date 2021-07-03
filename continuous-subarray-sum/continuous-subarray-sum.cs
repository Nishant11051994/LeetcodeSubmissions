//https://leetcode.com/problems/continuous-subarray-sum/discuss/143224/C%3A-Three-Solutions.-Easy-to-understand.
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) 
    {
       Dictionary<int,int> map = new Dictionary<int,int>();
        
       map[0] = -1;
        
       int prefixSum = 0;
        
       for(int i = 0 ; i < nums.Length ; i++)
       {
           prefixSum += nums[i];
           
           if( k != 0)
           {
               prefixSum = prefixSum % k;
           }
           
           if(map.ContainsKey(prefixSum))
           {
               if(i - map[prefixSum] > 1) return true;
           }
           else
           {
               map[prefixSum] = i;
           }           
       }
       return false;
    }
}