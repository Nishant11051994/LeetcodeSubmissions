public class Cache
{
    public int timestamp;
    public string value;
    public Cache(int x,string y)
    {
        timestamp = x;
        value = y;
    }
}
public class TimeMap {

    Dictionary<string,List<Cache>> keyTimeStampValueMap;
    /** Initialize your data structure here. */
    public TimeMap() 
    {
        keyTimeStampValueMap = new Dictionary<string,List<Cache>>();
    }
    
    public void Set(string key, string value, int timestamp) 
    {
        if(!keyTimeStampValueMap.ContainsKey(key))
        {
            keyTimeStampValueMap.Add(key,new List<Cache>());
        }
        keyTimeStampValueMap[key].Add(new Cache(timestamp,value));
    }
    
    public string Get(string key, int timestamp) 
    {
        if(!keyTimeStampValueMap.ContainsKey(key)) return string.Empty;
        
        if(timestamp < keyTimeStampValueMap[key].First().timestamp)
        {
            return "";
        }
        if(timestamp > keyTimeStampValueMap[key].Last().timestamp)
        {
            return keyTimeStampValueMap[key].Last().value;
        }        
        return BinarySearch(keyTimeStampValueMap[key],timestamp);        
    }
    private string BinarySearch(List<Cache> list,int timeStamp)
    {
        int start = 0;
        int end = list.Count-1;     
        int index = -1;
        while(start <= end)
        {
            int mid = start + (end-start)/2;
            if(list[mid].timestamp > timeStamp)
            {
                end = mid - 1;
            }
            else 
            {
                index = mid;
                start = mid + 1;
            }
        }  
        return list[index].value;
       /* while(start <= end)
        {
            int mid = start + (end-start)/2;
            if(list[mid].timestamp == timeStamp ||
              (mid < list.Count-1 && list[mid].timestamp < timeStamp && list[mid+1].timestamp > timeStamp))
            {
                return list[mid].value;
            }
            else if(list[mid].timestamp > timeStamp)
            {
                end = mid - 1;
            }
            else
            {
                start = mid+1;
            }
        }    
        */
        return "";
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */