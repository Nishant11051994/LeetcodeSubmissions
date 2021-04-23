public class Solution {
    int[] arr;
    int length;
    public int FindKthLargest(int[] nums, int k) 
    {
        if(nums == null || nums.Length == 0) return 0;
        int n = nums.Length;
        int result = 0;
        
        arr = new int[n];
        
        for(int i = 0 ; i < n ; i++)
        {
            arr[i] = nums[i];
            length++;
        }
        
        for(int i = (n - 1)/2 ; i >= 0 ; i--)
        {
            Heapify(i);
        }
        
        for(int i = 0 ; i < k ; i++)
        {
            result = DeleteAndReturnMax();
        }
        return result;
    }
    private int DeleteAndReturnMax()
    {
        if(length == 0) return Int32.MinValue;
        
        int max = arr[0];
        arr[0] = arr[length-1];
        Heapify(0);
        length--;
        return max;
    }
    private void Heapify(int i)
    {       
        while( i < length)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;        
            int max = i;
            
            if(left < length && arr[left] > arr[max])
            {
                max = left;
            }
            if(right < length && arr[right] > arr[max])
            {
                max = right;
            }
            if(max != i)
            {
                int temp = arr[max];
                arr[max] = arr[i];
                arr[i] = temp;
                i = max;
            }
            else break;                      
        }        
    }
}