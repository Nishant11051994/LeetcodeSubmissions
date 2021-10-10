public class Solution {
    public bool CanReorderDoubled(int[] arr) 
    {
        if(arr == null || arr.Length == 0)
        {
            return false;
        }
        
        Dictionary<int,int> map = new Dictionary<int,int>();
        
        for(int i = 0 ; i < arr.Length ; i++)
        {
            if(!map.ContainsKey(arr[i]))
            {
                map.Add(arr[i],0);
            }
            map[arr[i]]++;
        }
        
        Array.Sort(arr);
        
        for(int i = 0 ; i < arr.Length ; i++)
        {
            if(map[arr[i]] > 0)
            {
                var pair = 2 * arr[i];
                if(map.ContainsKey(pair) && map[pair] > 0)
                {
                    map[arr[i]]--;
                    map[pair]--;
                }
            }
        }
        
        return map.Values.All(x => x == 0);
    }
}