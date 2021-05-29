public class Solution {
    public int FindKthPositive(int[] arr, int k) 
    {
        if(arr == null || arr.Length == 0) return 0;
        
        int count = 0;
        int currPositive = 1;
        
        HashSet<int> set = new HashSet<int>(arr);
        
        while(count < k)
        {
            if(!set.Contains(currPositive))
            {
                count++;
            }
            currPositive++;
        }
        
        return currPositive-1;
    }
}