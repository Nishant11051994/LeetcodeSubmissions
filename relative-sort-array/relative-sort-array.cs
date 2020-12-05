public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) 
    {
        
        if(arr1 == null || arr2 == null || arr1.Length == 0 || arr2.Length == 0) return null;
        
        int[] result = new int[arr1.Length];
        Dictionary<int,int> freqMap = new Dictionary<int,int>();
        
        foreach(int ele in arr1)
        {
            if(!freqMap.ContainsKey(ele))
            {
                freqMap.Add(ele,0);
            }
            freqMap[ele]++;
        }        
        int index = 0;
        for(int i = 0 ; i < arr2.Length ; i++)
        {
            int count = freqMap[arr2[i]];
            while(count!=0)
            {
                arr1[index++] = arr2[i];
                count--;
            }
            freqMap[arr2[i]] = 0;
        }
        
        freqMap = freqMap.OrderBy(x => x.Key).ToDictionary(x=> x.Key,x =>x.Value);        
        foreach(var val in freqMap)
        {
            int count = val.Value;
            while(count!=0)
            {
                arr1[index++] = val.Key;
                count--;
            }
        }
        
        return arr1;
    }
}
