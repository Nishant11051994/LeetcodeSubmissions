public class Solution {
    public int[] TwoSum(int[] numbers, int target) 
    {
        if(numbers.Length < 2) return null;
        int[] result = new int[2];
         
        for(int i = 0 ; i < numbers.Length ; i++)
        {
            int res = BinarySearch(numbers,target-numbers[i]);
            if(res != -1 && res != i)
            {
               result[0] = i+1;
               result[1] = res+1;
               break;
            }
        }
        Array.Sort(result);
        return result;
    }
    private int BinarySearch(int[] num,int target)
    {
        int lo = 0;
        int hi = num.Length-1;
        
        while(lo <= hi)
        {
            int mid = (lo + hi)/2;
            if(num[mid] == target)
            {
                return mid;
            }
            else if(num[mid] < target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }
        return -1;
    }
}