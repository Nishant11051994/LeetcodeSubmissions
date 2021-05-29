public class Solution {
    public int FindKthPositive(int[] arr, int k) 
    {
        if(arr == null || arr.Length == 0) return 0;
        
        
        if(k <= arr[0] - 1) return k;
        
        // Deduct k 
        k -= arr[0] - 1;
        
        for(int i = 0 ; i < arr.Length-1; i++)
        {
            int currDiff = arr[i+1] - arr[i] - 1;
            if(currDiff >= k)
            {
                return arr[i] + k;               
            }
            k -= currDiff;
        }        
        return arr[arr.Length-1] + k;
        
    }
}