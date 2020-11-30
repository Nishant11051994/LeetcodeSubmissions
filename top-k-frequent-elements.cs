public class Solution {
    int[] arr;
    int length;
    Dictionary<int,int> freqMap;
    public int[] TopKFrequent(int[] nums, int k) 
    {
        List<int> result = new List<int>();
        if(nums == null || k == 0) return result.ToArray();
        
        freqMap = new Dictionary<int,int>();
        
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(freqMap.ContainsKey(nums[i]))
            {
                freqMap[nums[i]]++;
            }
            else
            {
                freqMap.Add(nums[i],1);
            }
        }        
        arr = new int[freqMap.Count];
        length = 0;
        int index = 0;
        
        foreach(var item in freqMap)
        {
            arr[index++] = item.Key;
            length++;
        }        
        for(int i = (arr.Length - 1)/2 ; i >= 0 ; i--)
        {
            Heapify(i);
        }       
        for(int i = k ; k >0 ; k--)
        {
            result.Add(GetAndDeleteMax());
        }    
        return result.ToArray();
    }
    private int GetAndDeleteMax()
    {
        if(length > 0)
        {
            int max = arr[0];
            arr[0] = arr[length-1];
            length--;
            Heapify(0);
